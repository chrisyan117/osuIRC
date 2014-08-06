using Meebey.SmartIrc4net;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace osu__IRC
{
    public partial class Form1 : Form
    {
        private delegate void Delegates();
        Delegates delegates;

        private delegate void ControlDelegate_listBoxTargetList();
        ControlDelegate_listBoxTargetList listBoxTargetList_Delegate;

        private delegate void ControlDelegate_richTextBoxMessage();
        ControlDelegate_richTextBoxMessage richTextBoxMessage_Delegate;

        private delegate void ControlDelegate_labelPing();
        ControlDelegate_labelPing labelPing_Delegate;



        public static IrcClient irc;

        public Form1()
        {
            InitializeComponent();
            richTextBoxMessage.SelectionFont = richTextBoxMessage.Font;
        }

        public void OnIrcRegistered(object sender, EventArgs e)
        {
            appendMessage("Login Success!", Color.FromArgb(154, 247, 108), true, false);
            appendMessage("You can type /help to view instructions", Color.FromArgb(154, 247, 108), true, false);
            appendMessage("You can type /join <Channel> to join a channel", Color.FromArgb(154, 247, 108), true, false);
            if (checkBoxRememberPassword.Checked)
            {
                Properties.Settings.Default.RememberPassword = true;
                Properties.Settings.Default.RememberPassword_Password = textBoxIRCPassword.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.RememberPassword = false;
                Properties.Settings.Default.RememberPassword_Password = String.Empty;
                Properties.Settings.Default.Save();
            }
            delegates = delegate()
            {
                textBoxIRCPassword.Visible = false;
                label2.Visible = false;
                buttonLogin.Visible = false;
                checkBoxRememberPassword.Visible = false;
                textBoxSendTo.Visible = true;
                textBoxMessage.Visible = true;
                buttonSendMessage.Visible = true;
                listBoxTargetList.Visible = true;
                textBoxSendTo.Text = Properties.Settings.Default.LastTarget;
                textBoxMessage.Focus();
            };
            if (Properties.Settings.Default.JoinedChannel != null)
            {
                foreach (string channel in Properties.Settings.Default.JoinedChannel)
                {
                    irc.RfcJoin(channel, Priority.High);
                }
            }
            textBoxIRCPassword.Invoke(delegates);
            irc.PingInterval = 3;
            irc.RfcPing("irc.ppy.sh");
        }

        public void OnIrcChannelMessage(object sender, IrcEventArgs e)
        {
            //message = Encoding.Default.GetString(Encoding.Default.GetBytes(message));
            appendMessage("[" + e.Data.Channel + "] " + e.Data.Nick + ": ", Color.FromArgb(255, 240, 154), false, true);
            appendMessage(e.Data.Message, Color.White, true, false);
        }

        public void OnIrcChannelAction(object sender, ActionEventArgs e)
        {
            appendMessage("[" + e.Data.Channel + "] ", Color.FromArgb(255, 240, 154), false, true);
            appendMessage("*" + e.Data.Nick + " " + e.ActionMessage, Color.White, true, false);
        } 

        public void OnIrcPrivateMessage(object sender, IrcEventArgs e)
        {
            appendMessage("[PM:" + e.Data.Nick + "] " + e.Data.Nick + " ", Color.FromArgb(255, 223, 46), false, true);
            appendMessage(e.Data.Message, Color.White, true, false);

            /*Stream[] messageSound = new Stream[1] {Properties.Resources.msg};
            Audio soundplayer = new Audio();
            soundplayer.Play(messageSound[0], AudioPlayMode.Background);*/
        }

        public void OnIrcError(object sender, Meebey.SmartIrc4net.ErrorEventArgs e)
        {

#if DEBUG
            appendMessage("[DEBUG] IRC Error: " + e.Data.Message, Color.FromArgb(255, 0, 0), true, false);
#endif
        }

        public void OnIrcErrorMessage(object sender, IrcEventArgs e)
        {
            if (e.Data.ReplyCode == ReplyCode.ErrorPasswordMismatch)
            {
                appendMessage("Login Fail! IRC Password Mismatch!", Color.FromArgb(255, 0, 0), true, false);
                delegates = delegate()
                {
                    buttonLogin.Enabled = true;
                    textBoxIRCPassword.Enabled = true;
                };
                buttonLogin.Invoke(delegates);
                return;
            }
            if (e.Data.ReplyCode == ReplyCode.ErrorNoSuchChannel)
            {
                appendMessage("The channel is not exist.", Color.FromArgb(255, 0, 0), true, false);
                return;
            }
            if (e.Data.ReplyCode == ReplyCode.ErrorNoSuchNickname)
            {
                appendMessage("The user is not currently online.", Color.FromArgb(255, 0, 0), true, false);
                return;
            }
#if DEBUG
            appendMessage("[DEBUG] IRC Error Message: " + e.Data.Message, Color.FromArgb(255, 0, 0), true, false);
#endif
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberPassword)
            {
                textBoxIRCPassword.Text = Properties.Settings.Default.RememberPassword_Password;
                textBoxIRCPassword.DeselectAll();
                textBoxIRCPassword.SelectionStart = textBoxIRCPassword.Text.Length;
                checkBoxRememberPassword.Checked = true;
                buttonLogin.Focus();
            }
            appendMessage("Visit https://osu.ppy.sh/p/ircauth?action=allow&ip=osu!IRC and click 'Authorise IRC connection' to get your password", Color.White, true, false);
        }

        private void appendMessage(string str, Color color = new Color(), bool newline = false, bool timestamp = false)
        {
            if (color.IsEmpty)
            {
                color = Color.White;
            }
            richTextBoxMessage_Delegate = delegate()
            {
                richTextBoxMessage.DeselectAll();
                richTextBoxMessage.SelectionStart = richTextBoxMessage.Text.Length;
                richTextBoxMessage.ScrollToCaret();
                if (timestamp == true)
                {
                    richTextBoxMessage.SelectionColor = Color.White;
                    richTextBoxMessage.AppendText(DateTime.Now.Hour.ToString("D2") + ":" + DateTime.Now.Minute.ToString("D2") + " ");
                }
                richTextBoxMessage.SelectionColor = color;
                richTextBoxMessage.AppendText(str);
                if (newline) richTextBoxMessage.AppendText(Environment.NewLine);
                richTextBoxMessage.SelectionStart = richTextBoxMessage.Text.Length;
                richTextBoxMessage.ScrollToCaret();
            };
            richTextBoxMessage.Invoke(richTextBoxMessage_Delegate);
        }

        private void textBoxIRCPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && buttonLogin.Enabled)
                buttonLogin_Click(null, null);
            if (e.KeyCode == Keys.Escape)
                textBoxIRCPassword.Text = String.Empty;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (buttonSendMessage.Enabled && e.KeyCode == Keys.Enter)
                buttonSendMessage_Click(null, null);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxIRCPassword.Text))
            {
                appendMessage("Please check your Password!", Color.FromArgb(255, 69, 0));
                return;
            }

            buttonLogin.Enabled = false;
            textBoxIRCPassword.Enabled = false;

            appendMessage("Logging in... ...", Color.FromArgb(154, 247, 108));
            irc = new IrcClient()
            {
                Encoding = Encoding.UTF8,
                SendDelay = 200,
                ActiveChannelSyncing = true
            };
            //irc.OnQueryMessage += new IrcEventHandler(OnIrcQueryMessage);
            irc.OnError += new Meebey.SmartIrc4net.ErrorEventHandler(OnIrcError);
            irc.OnErrorMessage += new IrcEventHandler(OnIrcErrorMessage);
            irc.OnRegistered += new EventHandler(OnIrcRegistered);
            irc.OnChannelMessage += new IrcEventHandler(OnIrcChannelMessage);
            irc.OnQueryMessage += new IrcEventHandler(OnIrcPrivateMessage);
            irc.OnChannelAction += new ActionEventHandler(OnIrcChannelAction);
            irc.OnChannelActiveSynced += new IrcEventHandler(OnIrcChannelActiveSynced);
            irc.OnPong += new PongEventHandler(OnIrcReplyPing);

            irc.Connect("irc.ppy.sh", 6667);
            irc.Login("", "", 0, "", textBoxIRCPassword.Text);
            new Thread(new ThreadStart(irc.Listen)).Start();
        }

        private void OnIrcChannelActiveSynced(object sender, IrcEventArgs e)
        {
            appendMessage("Joined " + e.Data.Channel + "!", Color.FromArgb(154, 205, 50), true, false);
            listBoxTargetList_Delegate = delegate()
            {
                string[] JoinedChannel = new string[irc.JoinedChannels.Count];
                irc.JoinedChannels.CopyTo(JoinedChannel, 0);
                listBoxTargetList.Items.Clear();
                listBoxTargetList.Items.AddRange(JoinedChannel);
            };
            listBoxTargetList.Invoke(listBoxTargetList_Delegate);
            Properties.Settings.Default.JoinedChannel = irc.JoinedChannels;
            Properties.Settings.Default.Save();
        }

        private static int sendMessageCooldownTime;
        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            textBoxSendTo.Text = textBoxSendTo.Text.Replace(' ', '_');
            string message = textBoxMessage.Text;
            if (String.IsNullOrWhiteSpace(message))
            {
                return;
            }
            if (message.First() == '/')
            {
                string[] cmd;
                cmd = message.Split(' ');

                string parameter = message.Remove(0, cmd[0].Length).TrimStart(' ').TrimEnd(' ');

                if (cmd[0] == "/help")
                {
                    richTextBoxMessage.DeselectAll();
                    richTextBoxMessage.SelectionStart = richTextBoxMessage.Text.Length;
                    richTextBoxMessage.ScrollToCaret();

                    richTextBoxMessage.SelectionColor = Color.FromArgb(154, 205, 50);
                    richTextBoxMessage.AppendText("Command Help:\n");

                    richTextBoxMessage.SelectionColor = Color.FromArgb(255, 69, 0);
                    richTextBoxMessage.AppendText("/help");
                    richTextBoxMessage.SelectionColor = Color.White;
                    richTextBoxMessage.AppendText(" View this help.\n");

                    richTextBoxMessage.SelectionColor = Color.FromArgb(255, 69, 0);
                    richTextBoxMessage.AppendText("/join <Channel>");
                    richTextBoxMessage.SelectionColor = Color.White;
                    richTextBoxMessage.AppendText(" Join a channel [ Example: /join #osu ]\n");

                    richTextBoxMessage.SelectionColor = Color.FromArgb(255, 69, 0);
                    richTextBoxMessage.AppendText("/part <Channel>");
                    richTextBoxMessage.SelectionColor = Color.White;
                    richTextBoxMessage.AppendText(" Leave a channel [ Example: /part #osu ]\n");

                    richTextBoxMessage.SelectionColor = Color.FromArgb(255, 69, 0);
                    richTextBoxMessage.AppendText("/me <Action>");
                    richTextBoxMessage.SelectionColor = Color.White;
                    richTextBoxMessage.AppendText(" Perform a third-person action.\n");

                    richTextBoxMessage.SelectionStart = richTextBoxMessage.Text.Length;
                    richTextBoxMessage.ScrollToCaret();
                }
                else if (cmd[0] == "/me")
                {
                    if (String.IsNullOrWhiteSpace(parameter))
                    {
                        appendMessage("/me <Action>", Color.FromArgb(255,69,0),true,false);
                        return;
                    }
                    sendMessageCooldownTime += 5;
                    if (!irc.JoinedChannels.Contains(textBoxSendTo.Text))
                    {
                        appendMessage("You have not join " + textBoxSendTo.Text + " yet!", Color.FromArgb(255, 69, 0), true, false);
                        return;
                    }
                    irc.SendMessage(SendType.Action, textBoxSendTo.Text, parameter);
                    if (textBoxSendTo.Text.First() == '#')
                    {
                        appendMessage("[" + textBoxSendTo.Text + "] ", Color.FromArgb(240, 128, 128), false, true);
                        appendMessage("*" + irc.Nickname + " " + parameter, Color.White, true, false);
                    }
                    else
                    {
                        appendMessage("[PM:" + textBoxSendTo.Text + "] ", Color.FromArgb(240, 128, 128), false, true);
                        appendMessage("*" + irc.Nickname + " " + parameter, Color.White, true, false);
                    }
                }
                else if (cmd[0] == "/ping")
                {
                    irc.PingInterval = 10;
                    irc.RfcPing("irc.ppy.sh");
                }
                else if (cmd[0] == "/join")
                {
                    if (String.IsNullOrWhiteSpace(parameter))
                    {
                        appendMessage("/join <Channel>", Color.FromArgb(255, 69, 0), true, false);
                        return;
                    }
                    string channel = parameter;
                    if (channel.First() != '#')
                        channel = "#" + channel;
                    irc.RfcJoin(channel);
                    appendMessage("Attempting to join " + channel + "...", Color.FromArgb(240, 128, 128), true, false);
                }
                else if (cmd[0] == "/part")
                {
                    if (String.IsNullOrWhiteSpace(parameter))
                    {
                        appendMessage("/part <Channel>", Color.FromArgb(255, 69, 0), true, false);
                        return;
                    }
                    string channel = parameter;
                    if (channel.First() != '#')
                        channel = "#" + channel;
                    if (!irc.JoinedChannels.Contains(channel))
                    {
                        appendMessage("You have not join " + channel + " yet!", Color.FromArgb(255, 69, 0), true, false);
                        return;
                    }
                    irc.RfcPart(channel,Priority.High);
                    Properties.Settings.Default.JoinedChannel.Remove(channel);
                    Properties.Settings.Default.Save();
                    listBoxTargetList.Items.Remove(channel);
                    appendMessage("Left " + channel + "...", Color.FromArgb(240, 128, 128), true, false);
                }
                else
                {
                    appendMessage("Unknown command! Please check /help", Color.FromArgb(255, 69, 0), true, false);
                }
                textBoxMessage.Text = String.Empty;
                return;
            }
            if (sendMessageCooldownTime >= 24)
            {
                appendMessage("You speak too fast! Please slow down or you may be muted by BanchoBot.", Color.FromArgb(255, 69, 0), true, false);
                return;
            }
            if (String.IsNullOrWhiteSpace(textBoxSendTo.Text))
            {
                textBoxSendTo.Focus();
                return;
            }
            sendMessageCooldownTime += 5;

            if (textBoxSendTo.Text.First() == '#')
            {
                if (!irc.JoinedChannels.Contains(textBoxSendTo.Text))
                {
                    appendMessage("You have not join " + textBoxSendTo.Text + " yet!", Color.FromArgb(255, 69, 0), true, false);
                    return;
                }
                appendMessage("[" + textBoxSendTo.Text + "] " + irc.Nickname + ": ", Color.FromArgb(240, 128, 128), false, true);
            }
            else
            {
                appendMessage("[PM:" + textBoxSendTo.Text + "] " + irc.Nickname + ": ", Color.FromArgb(240, 128, 128), false, true);
            }
            appendMessage(message, Color.White, true, false);

            irc.SendMessage(SendType.Message, textBoxSendTo.Text, message, Priority.High);
            textBoxMessage.Text = String.Empty;
            textBoxMessage.Focus();
        }

        private void OnIrcReplyPing(object sender, PongEventArgs e)
        {
            double ping = e.Lag.TotalMilliseconds;
            labelPing_Delegate = delegate()
            {
                labelPing.Text = "Ping: " + ping.ToString("F0") + "ms";
                if (ping > 500) labelPing.ForeColor = Color.FromArgb(255, 0, 0);
                else if (ping > 300) labelPing.ForeColor = Color.FromArgb(255, 255, 0);
                else labelPing.ForeColor = Color.FromArgb(0, 255, 0);
            };
            labelPing.Invoke(labelPing_Delegate);
        }

        private void sendMessageCooldownTimer_Tick(object sender, EventArgs e)
        {
            if (sendMessageCooldownTime > 0) sendMessageCooldownTime--;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.JoinedChannel = irc.JoinedChannels;
            Properties.Settings.Default.Save();
            Environment.Exit(Environment.ExitCode);
        }

        private void listBoxOnlineUser_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxTargetList.SelectedItem != null)
            {
                textBoxSendTo.Text = listBoxTargetList.SelectedItem.ToString();
                listBoxTargetList.ClearSelected();
                textBoxMessage.Focus();
            }
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void checkBoxRememberPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRememberPassword.Checked == false)
            {
                textBoxIRCPassword.Text = String.Empty;
                Properties.Settings.Default.RememberPassword = false;
                Properties.Settings.Default.RememberPassword_Password = String.Empty;
                Properties.Settings.Default.Save();
            }
        }

        private void textBoxSendTo_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LastTarget = textBoxSendTo.Text;
            Properties.Settings.Default.Save();
        }
    }
}