using Meebey.SmartIrc4net;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace osu__IRC
{

    public partial class Form1 : Form
    {
        private delegate void Delegates(); Delegates delegates;
        private delegate void ControlDelegate_listBoxTargetList(); ControlDelegate_listBoxTargetList listBoxTargetList_Delegate;
        private delegate void ControlDelegate_richTextBoxMessage(); ControlDelegate_richTextBoxMessage richTextBoxMessage_Delegate;
        private delegate void ControlDelegate_labelPing(); ControlDelegate_labelPing labelPing_Delegate;
        private delegate void FormEventDelegate_FormFlash(); FormEventDelegate_FormFlash formFlash_Delegate;

        List<string> Friends = new List<string>();

        public static IrcClient irc;

        public Form1()
        {
            InitializeComponent();
        }

        #region IRC Callback
        public void OnIrcRegistered(object sender, EventArgs e)
        {
            appendMessage(Languages.GetString(Properties.Settings.Default.Language, "Message_Login_Success"), Color.FromArgb(154, 247, 108), true, false);
            appendMessage(Languages.GetString(Properties.Settings.Default.Language, "Message_Login_Help"), Color.FromArgb(154, 247, 108), true, false);
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
            if (Properties.Settings.Default.Friends != null)
            {
                Friends = Properties.Settings.Default.Friends.Cast<string>().ToList();
                string[] friends = new string[Friends.Count];
                Friends.CopyTo(friends, 0);
                listBoxTargetList.Items.AddRange(friends);
            }
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

            foreach (ToolStripDropDownItem item in channelsToolStripMenuItem.DropDownItems)
            {
                item.Click += delegate
                {
                    if (irc != null && irc.IsRegistered)
                    {
                        irc.RfcJoin(item.Text);
                        appendMessage(String.Format(Languages.GetString(Properties.Settings.Default.Language, "Message_Channel_Joining"), item.Text), Color.FromArgb(240, 128, 128), true, false);
                    }
                };
            }
        }

        public void OnIrcChannelMessage(object sender, IrcEventArgs e)
        {
            //message = Encoding.Default.GetString(Encoding.Default.GetBytes(message));
            appendMessage(String.Format(Languages.GetString(Properties.Settings.Default.Language, "Message_Channel_Message"), e.Data.Channel, e.Data.Nick), Color.FromArgb(255, 240, 154), false, true);
            appendMessage(String.Format(Languages.GetString(Properties.Settings.Default.Language, "Message_Channel_Message2"), e.Data.Message), Color.White, true, false);
        }

        public void OnIrcChannelAction(object sender, ActionEventArgs e)
        {
            appendMessage(String.Format(Languages.GetString(Properties.Settings.Default.Language, "Message_Channel_Action"), e.Data.Channel), Color.FromArgb(255, 240, 154), false, true);
            appendMessage(String.Format(Languages.GetString(Properties.Settings.Default.Language, "Message_Channel_Action2"), e.Data.Nick, e.ActionMessage), Color.White, true, false);
        }

        public void OnIrcPrivateMessage(object sender, IrcEventArgs e)
        {
            appendMessage(String.Format(Languages.GetString(Properties.Settings.Default.Language, "Message_PM_Message"), e.Data.Nick, e.Data.Nick), Color.FromArgb(255, 223, 46), false, true);
            appendMessage(String.Format(Languages.GetString(Properties.Settings.Default.Language, "Message_PM_Message2"), e.Data.Message), Color.White, true, false);

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
                appendMessage(Languages.GetString(Properties.Settings.Default.Language, "Message_Login_Wrong_Password"), Color.FromArgb(255, 0, 0), true, false);
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
                appendMessage(Languages.GetString(Properties.Settings.Default.Language, "Message_Error_ChannelNotExist"), Color.FromArgb(255, 0, 0), true, false);
                return;
            }
            if (e.Data.ReplyCode == ReplyCode.ErrorNoSuchNickname)
            {
                appendMessage(Languages.GetString(Properties.Settings.Default.Language, "Message_Error_UserNotExist"), Color.FromArgb(255, 0, 0), true, false);
                return;
            }
#if DEBUG
            appendMessage("[DEBUG] IRC Error Message: " + e.Data.Message, Color.FromArgb(255, 0, 0), true, false);
#endif
        }


        #endregion

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

            List<string> channels = new List<string>{
                    "#announce",
                    "#arabic",
                    "#bulgarian",
                    "#cantonese",
                    "#chinese",
                    "#ctb",
                    "#czechoslovak",
                    "#dutch",
                    "#english",
                    "#filipino",
                    "#finnish",
                    "#french",
                    "#german",
                    "#greek",
                    "#hebrew",
                    "#help",
                    "#hungarian",
                    "#indonesian",
                    "#italian",
                    "#japanese",
                    "#korean",
                    "#lobby",
                    "#malaysian",
                    "#minecraft",
                    "#modhelp",
                    "#modreqs",
                    "#osu",
                    "#osumania",
                    "#polish",
                    "#portuguese",
                    "#romanian",
                    "#russian",
                    "#skandinavian",
                    "#spanish",
                    "#taiko",
                    "#thai",
                    "#turkish",
                    "#videogames",
                    "#vietnamese"
                };
            foreach (string channel in channels)
            {
                channelsToolStripMenuItem.DropDownItems.Add(channel);
            }

            foreach (KeyValuePair<string,string> language in Languages.languages)
            {
                languageToolStripMenuItem.DropDownItems.Add(language.Key);
            }

            foreach (ToolStripDropDownItem item in languageToolStripMenuItem.DropDownItems)
            {
                item.Click += delegate
                {
                    Properties.Settings.Default.Language = Languages.languages[item.Text];
                    Properties.Settings.Default.Save();
                    InitializeNewLanguage();
                };
            }
            InitializeNewLanguage();
        }

        private void InitializeNewLanguage()
        {
            channelsToolStripMenuItem.Text = Languages.GetString(Properties.Settings.Default.Language, "UI_ToolStrip_Channels");
            languageToolStripMenuItem.Text = Languages.GetString(Properties.Settings.Default.Language, "UI_ToolStrip_Language");
            label2.Text = Languages.GetString(Properties.Settings.Default.Language, "UI_Login_Label_IRC_Password");
            checkBoxRememberPassword.Text = Languages.GetString(Properties.Settings.Default.Language, "UI_Login_CheckBox_Remember_Password");
            buttonLogin.Text = Languages.GetString(Properties.Settings.Default.Language, "UI_Login_Button_Login");
            buttonSendMessage.Text = Languages.GetString(Properties.Settings.Default.Language, "UI_Button_SendMessage");

            if (buttonLogin.Visible)
            {
                richTextBoxMessage.SelectionFont = richTextBoxMessage.Font;
                richTextBoxMessage.Text = Languages.GetString(Properties.Settings.Default.Language, "Message_Welcome") + Environment.NewLine;
            }
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
                    richTextBoxMessage.AppendText(String.Format("{0}:{1} ", DateTime.Now.Hour.ToString("D2"), DateTime.Now.Minute.ToString("D2")));
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
            if (String.IsNullOrEmpty(textBoxIRCPassword.Text)) return;

            buttonLogin.Enabled = false;
            textBoxIRCPassword.Enabled = false;

            appendMessage(Languages.GetString(Properties.Settings.Default.Language, "Message_Login_Logging_In"), Color.FromArgb(154, 247, 108), true, false);
            irc = new IrcClient()
            {
                Encoding = Encoding.UTF8,
                SendDelay = 100,
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
            irc.OnChannelPassiveSynced += new IrcEventHandler(OnIrcChannelPassiveSynced);
            irc.OnPong += new PongEventHandler(OnIrcReplyPing);

            irc.Connect("irc.ppy.sh", 6667);
            irc.Login("", "", 0, "", textBoxIRCPassword.Text);
            new Thread(new ThreadStart(irc.Listen)).Start();
        }

        private void OnIrcChannelPassiveSynced(object sender, IrcEventArgs e)
        {

        }

        private void OnIrcChannelActiveSynced(object sender, IrcEventArgs e)
        {
            appendMessage(String.Format(Languages.GetString(Properties.Settings.Default.Language, "Message_Channel_Joined"), e.Data.Channel), Color.FromArgb(154, 205, 50), true, false);
            listBoxTargetList_Delegate = delegate()
            {
                string[] joinedChannel = new string[irc.JoinedChannels.Count];
                irc.JoinedChannels.CopyTo(joinedChannel, 0);
                listBoxTargetList.Items.Clear();
                listBoxTargetList.Items.AddRange(joinedChannel);
                string[] friends = new string[Friends.Count];
                Friends.CopyTo(friends, 0);
                listBoxTargetList.Items.AddRange(friends);
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

                cmd[0] = cmd[0].ToLower();

                if (cmd[0] == "/help")
                {
                    richTextBoxMessage.DeselectAll();
                    richTextBoxMessage.SelectionStart = richTextBoxMessage.Text.Length;
                    richTextBoxMessage.ScrollToCaret();

                    richTextBoxMessage.SelectionColor = Color.FromArgb(154, 205, 50);
                    richTextBoxMessage.AppendText(Languages.GetString(Properties.Settings.Default.Language, "Message_Help_Index"));
                    richTextBoxMessage.AppendText(Environment.NewLine);
                    for (int i = 1; i <= 6; i++)
                    {
                        richTextBoxMessage.SelectionColor = Color.FromArgb(255, 69, 0);
                        richTextBoxMessage.AppendText(Languages.GetString(Properties.Settings.Default.Language, "Message_Help_" + i + "a"));
                        richTextBoxMessage.SelectionColor = Color.White;
                        richTextBoxMessage.AppendText(Languages.GetString(Properties.Settings.Default.Language, "Message_Help_" + i + "b"));
                        richTextBoxMessage.AppendText(Environment.NewLine);
                    }
                    richTextBoxMessage.SelectionStart = richTextBoxMessage.Text.Length;
                    richTextBoxMessage.ScrollToCaret();
                }
                else if (cmd[0] == "/me")
                {
                    if (String.IsNullOrWhiteSpace(parameter))
                    {
                        appendMessage(Languages.GetString(Properties.Settings.Default.Language, "Message_Command_me_Empty_Parameter"), Color.FromArgb(255, 69, 0), true, false);
                        return;
                    }
                    sendMessageCooldownTime += 5;
                    if (!irc.JoinedChannels.Contains(textBoxSendTo.Text))
                    {
                        appendMessage(String.Format(Languages.GetString(Properties.Settings.Default.Language, "Message_Channel_Not_Joined"), textBoxSendTo.Text), Color.FromArgb(255, 69, 0), true, false);
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
                else if (cmd[0] == "/join")
                {
                    if (String.IsNullOrWhiteSpace(parameter))
                    {
                        appendMessage(Languages.GetString(Properties.Settings.Default.Language, "Message_Command_join_Empty_Parameter"), Color.FromArgb(255, 69, 0), true, false);
                        return;
                    }
                    string channel = parameter;
                    if (channel.First() != '#')
                        channel = "#" + channel;
                    irc.RfcJoin(channel);
                    appendMessage(String.Format(Languages.GetString(Properties.Settings.Default.Language, "Message_Channel_Joining"), channel), Color.FromArgb(240, 128, 128), true, false);
                }
                else if (cmd[0] == "/part")
                {
                    if (String.IsNullOrWhiteSpace(parameter))
                    {
                        appendMessage(Languages.GetString(Properties.Settings.Default.Language, "Message_Command_part_Empty_Parameter"), Color.FromArgb(255, 69, 0), true, false);
                        return;
                    }
                    string channel = parameter;
                    if (channel.First() != '#')
                        channel = "#" + channel;
                    if (!irc.JoinedChannels.Contains(channel))
                    {
                        appendMessage(String.Format(Languages.GetString(Properties.Settings.Default.Language, "Message_Channel_Not_Joined"), channel), Color.FromArgb(255, 69, 0), true, false);
                        return;
                    }
                    irc.RfcPart(channel, Priority.High);
                    Properties.Settings.Default.JoinedChannel.Remove(channel);
                    Properties.Settings.Default.Save();
                    listBoxTargetList.Items.Remove(channel);
                    appendMessage("Left " + channel + "...", Color.FromArgb(240, 128, 128), true, false);
                }
                else if (cmd[0] == "/addfriend")
                {
                    if (Friends.Contains(parameter.Replace(' ', '_'), StringComparer.CurrentCultureIgnoreCase))
                    {
                        appendMessage(String.Format(Languages.GetString(Properties.Settings.Default.Language, "Message_Command_addfriend_Exist"), parameter.Replace(' ', '_')), Color.FromArgb(255, 69, 0), true, false);
                        return;
                    }
                    else
                    {
                        Friends.Add(parameter.Replace(' ', '_'));
                    }
                    string[] joinedChannel = new string[irc.JoinedChannels.Count];
                    irc.JoinedChannels.CopyTo(joinedChannel, 0);
                    listBoxTargetList.Items.Clear();
                    listBoxTargetList.Items.AddRange(joinedChannel);
                    string[] friends = new string[Friends.Count];
                    Friends.CopyTo(friends, 0);
                    listBoxTargetList.Items.AddRange(friends);

                    Properties.Settings.Default.Friends = new System.Collections.Specialized.StringCollection();
                    Properties.Settings.Default.Friends.AddRange(Friends.ToArray());
                    Properties.Settings.Default.Save();
                }
                else if (cmd[0] == "/delfriend")
                {
                    if (Friends.Contains(parameter.Replace(' ', '_'), StringComparer.CurrentCultureIgnoreCase))
                    {
                        foreach (string friend in Friends.ToArray())
                        {
                            if (String.Compare(friend, parameter.Replace(' ', '_'), true) == 0)
                            {
                                Friends.Remove(friend);
                            }
                        }
                    }
                    else
                    {
                        appendMessage(String.Format(Languages.GetString(Properties.Settings.Default.Language, "Message_Command_delfriend_Not_Exist"), parameter.Replace(' ', '_')), Color.FromArgb(255, 69, 0), true, false);
                        return;
                    }
                    string[] joinedChannel = new string[irc.JoinedChannels.Count];
                    irc.JoinedChannels.CopyTo(joinedChannel, 0);
                    listBoxTargetList.Items.Clear();
                    listBoxTargetList.Items.AddRange(joinedChannel);
                    string[] friends = new string[Friends.Count];
                    Friends.CopyTo(friends, 0);
                    listBoxTargetList.Items.AddRange(friends);

                    Properties.Settings.Default.Friends = new System.Collections.Specialized.StringCollection();
                    Properties.Settings.Default.Friends.AddRange(Friends.ToArray());
                    Properties.Settings.Default.Save();
                }
                else
                {
                    appendMessage(Languages.GetString(Properties.Settings.Default.Language, "Message_Command_Unknown"), Color.FromArgb(255, 69, 0), true, false);
                }
                textBoxMessage.Text = String.Empty;
                return;
            }
            if (sendMessageCooldownTime >= 24)
            {
                appendMessage(Languages.GetString(Properties.Settings.Default.Language, "Message_Speak_Too_Fast"), Color.FromArgb(255, 69, 0), true, false);
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
                    appendMessage(String.Format(Languages.GetString(Properties.Settings.Default.Language, "Message_Channel_Not_Joined"), textBoxSendTo.Text), Color.FromArgb(255, 69, 0), true, false);
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
                labelPing.Text = String.Format(Languages.GetString(Properties.Settings.Default.Language, "Ping_Label"), ping);
                if (ping > 500) labelPing.ForeColor = Color.FromArgb(255, 44, 44);
                else if (ping > 300) labelPing.ForeColor = Color.FromArgb(255, 255, 0);
                else labelPing.ForeColor = Color.FromArgb(144, 238, 144);
            };
            labelPing.Invoke(labelPing_Delegate);
        }

        private void sendMessageCooldownTimer_Tick(object sender, EventArgs e)
        {
            if (sendMessageCooldownTime > 0) sendMessageCooldownTime--;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (irc != null)
            {
                Properties.Settings.Default.JoinedChannel = irc.JoinedChannels;
                Properties.Settings.Default.Friends = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Friends.AddRange(Friends.ToArray());
                Properties.Settings.Default.Save();
            }
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