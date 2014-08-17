﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu__IRC
{
    static class Languages
    {
        public static Dictionary<string, string> languages = new Dictionary<string, string>()
        {
            {"English","ENG"},
            {"简体中文","CHS"},
            {"繁體中文","CHT"},
        };

        public static string GetString(string language, string strName)
        {
            string str = String.Empty;
            string idx = language + "_" + strName;
            try
            {
                str = languageContent[idx];
            }
            catch (KeyNotFoundException)
            {
                idx = "lang_" + strName;
                try
                {
                    str = languageContent[idx];
                }
                catch (KeyNotFoundException)
                {
#if DEBUG
                    System.Windows.Forms.MessageBox.Show("Missing String: " + idx);
#endif
                }
            }
            return str;
        }

        public static Dictionary<string, string> languageContent = new Dictionary<string, string>()
        {
            {"lang_UI_ToolStrip_Channels", "Channels"},
            {"lang_UI_ToolStrip_Language", "Language"},
            {"lang_UI_Login_Label_IRC_Password", "IRC Password"},
            {"lang_UI_Login_CheckBox_Remember_Password", "Remember Password"},
            {"lang_UI_Login_Button_Login", "Login"},
            {"lang_UI_Button_SendMessage", "Send"},
            {"lang_Ping_Label", "Ping: {0:F0}ms"},
            {"lang_Message_Welcome","Visit https://osu.ppy.sh/p/ircauth?action=allow&ip=osu!IRC and click 'Authorise IRC connection' to get your password"},
            {"lang_Message_Login_Wrong_Password","Login Fail! IRC Password Mismatch!"},
            {"lang_Message_Login_Logging_In","Logging in... ..."},
            {"lang_Message_Login_Success","Login Success!"},
            {"lang_Message_Login_Help","You can type /help to view command instructions"},
            {"lang_Message_Error_ChannelNotExist","The channel is not exist."},
            {"lang_Message_Error_UserNotExist","The user is not currently online."},
            {"lang_Message_Channel_Joining","Attempting to join {0}..."},
            {"lang_Message_Channel_Joined","Joined {0}!"},
            {"lang_Message_Channel_Message","[{0}] {1}: "},
            {"lang_Message_Channel_Message2","{0}"},
            {"lang_Message_Channel_Action","[{0}] "},
            {"lang_Message_Channel_Action2","*{0} {1}"},
            {"lang_Message_Channel_Not_Joined","You have not join {0} yet!"},
            {"lang_Message_PM_Message","[PM:{0}] {1} "},
            {"lang_Message_PM_Message2","{0}"},
            {"lang_Message_Help_Index","Command Help:"},
            {"lang_Message_Help_1a","/help"},
            {"lang_Message_Help_1b"," View this help."},
            {"lang_Message_Help_2a","/join <Channel>"},
            {"lang_Message_Help_2b"," Join a channel [ Example: /join #osu ]"},
            {"lang_Message_Help_3a","/part <Channel>"},
            {"lang_Message_Help_3b"," Leave a channel [ Example: /part #osu ]"},
            {"lang_Message_Help_4a","/me <Action>"},
            {"lang_Message_Help_4b"," Perform a third-person action."},
            {"lang_Message_Help_5a","/addfriend <Name>"},
            {"lang_Message_Help_5b"," Add a friend to the list [ Example: /addfriend BanchoBot ]"},
            {"lang_Message_Help_6a","/delfriend <Name>"},
            {"lang_Message_Help_6b"," Delete a friend from the list [ Example: /delfriend BanchoBot ]"},
            {"lang_Message_Command_me_Empty_Parameter","/me <Action>"},
            {"lang_Message_Command_join_Empty_Parameter","/join <Channel>"},
            {"lang_Message_Command_part_Empty_Parameter","/part <Channel>"},
            {"lang_Message_Command_addfriend_Exist","{0} is already on your list"},
            {"lang_Message_Command_delfriend_Not_Exist","{0} doesn't exist on your list"},

            {"ENG_UI_ToolStrip_Channels", "Channels"},
            {"ENG_UI_ToolStrip_Language", "Language"},
            {"ENG_UI_Login_Label_IRC_Password", "IRC Password"},
            {"ENG_UI_Login_CheckBox_Remember_Password", "Remember Password"},
            {"ENG_UI_Login_Button_Login", "Login"},
            {"ENG_UI_Button_SendMessage", "Send"},
            {"ENG_Ping_Label", "Ping: {0:F0}ms"},
            {"ENG_Message_Welcome","Visit https://osu.ppy.sh/p/ircauth?action=allow&ip=osu!IRC and click 'Authorise IRC connection' to get your password"},
            {"ENG_Message_Login_Wrong_Password","Login Fail! IRC Password Mismatch!"},
            {"ENG_Message_Login_Logging_In","Logging in... ..."},
            {"ENG_Message_Login_Success","Login Success!"},
            {"ENG_Message_Login_Help","You can type /help to view command instructions"},
            {"ENG_Message_Error_ChannelNotExist","The channel is not exist."},
            {"ENG_Message_Error_UserNotExist","The user is not currently online."},
            {"ENG_Message_Channel_Joining","Attempting to join {0}..."},
            {"ENG_Message_Channel_Joined","Joined {0}!"},
            {"ENG_Message_Channel_Message","[{0}] {1}: "},
            {"ENG_Message_Channel_Message2","{0}"},
            {"ENG_Message_Channel_Action","[{0}] "},
            {"ENG_Message_Channel_Action2","*{0} {1}"},
            {"ENG_Message_Channel_Not_Joined","You have not join {0} yet!"},
            {"ENG_Message_PM_Message","[PM:{0}] {1} "},
            {"ENG_Message_PM_Message2","{0}"},
            {"ENG_Message_Help_Index","Command Help:"},
            {"ENG_Message_Help_1a","/help"},
            {"ENG_Message_Help_1b"," View this help."},
            {"ENG_Message_Help_2a","/join <Channel>"},
            {"ENG_Message_Help_2b"," Join a channel [ Example: /join #osu ]"},
            {"ENG_Message_Help_3a","/part <Channel>"},
            {"ENG_Message_Help_3b"," Leave a channel [ Example: /part #osu ]"},
            {"ENG_Message_Help_4a","/me <Action>"},
            {"ENG_Message_Help_4b"," Perform a third-person action."},
            {"ENG_Message_Help_5a","/addfriend <Name>"},
            {"ENG_Message_Help_5b"," Add a friend to the list [ Example: /addfriend BanchoBot ]"},
            {"ENG_Message_Help_6a","/delfriend <Name>"},
            {"ENG_Message_Help_6b"," Delete a friend from the list [ Example: /delfriend BanchoBot ]"},
            {"ENG_Message_Command_me_Empty_Parameter","/me <Action>"},
            {"ENG_Message_Command_join_Empty_Parameter","/join <Channel>"},
            {"ENG_Message_Command_part_Empty_Parameter","/part <Channel>"},
            {"ENG_Message_Command_addfriend_Exist","{0} is already on your list"},
            {"ENG_Message_Command_delfriend_Not_Exist","{0} doesn't exist on your list"},

            {"CHT_UI_ToolStrip_Channels", "頻道"},
            {"CHT_UI_ToolStrip_Language", "語言"},
            {"CHT_UI_Login_Label_IRC_Password", "IRC密碼"},
            {"CHT_UI_Login_CheckBox_Remember_Password", "記住密碼"},
            {"CHT_UI_Login_Button_Login", "登入"},
            {"CHT_UI_Button_SendMessage", "發送"},
            {"CHT_Ping_Label", "延時: {0:F0}ms"},
            {"CHT_Message_Welcome","你可以在 https://osu.ppy.sh/p/ircauth?action=allow&ip=osu!IRC 點擊 'Authorise IRC connection' 來取得你的IRC密碼"},
            {"CHT_Message_Login_Wrong_Password","登入失敗 IRC密碼無效!"},
            {"CHT_Message_Login_Logging_In","登入中... ..."},
            {"CHT_Message_Login_Success","登入成功!"},
            {"CHT_Message_Login_Help","你可以輸入/help查看指令幫助"},
            {"CHT_Message_Error_ChannelNotExist","該頻道不存在"},
            {"CHT_Message_Error_UserNotExist","該用戶不在線上"},
            {"CHT_Message_Channel_Joining","嘗試加入頻道 {0}..."},
            {"CHT_Message_Channel_Joined","你加入了 {0}!"},
            {"CHT_Message_Channel_Message","[{0}] {1}: "},
            {"CHT_Message_Channel_Message2","{0}"},
            {"CHT_Message_Channel_Action","[{0}] "},
            {"CHT_Message_Channel_Action2","*{0} {1}"},
            {"CHT_Message_Channel_Not_Joined","你尚未加入 {0}!"},
            {"CHT_Message_PM_Message","[PM:{0}] {1} "},
            {"CHT_Message_PM_Message2","{0}"},
            {"CHT_Message_Help_Index","指令幫助:"},
            {"CHT_Message_Help_1a","/help"},
            {"CHT_Message_Help_1b"," 查看此幫助."},
            {"CHT_Message_Help_2a","/join <Channel>"},
            {"CHT_Message_Help_2b"," 加入頻道 [ 例子: /join #osu ]"},
            {"CHT_Message_Help_3a","/part <Channel>"},
            {"CHT_Message_Help_3b"," 離開頻道 [ 例子: /part #osu ]"},
            {"CHT_Message_Help_4a","/me <Action>"},
            {"CHT_Message_Help_4b"," 以第三人稱發送自己的動作訊息"},
            {"CHT_Message_Help_5a","/addfriend <Name>"},
            {"CHT_Message_Help_5b"," 增加一個常用聯絡人到列表中 [ 例子: /addfriend BanchoBot ]"},
            {"CHT_Message_Help_6a","/delfriend <Name>"},
            {"CHT_Message_Help_6b"," 從常用聯絡人列表刪除指定對象 [ 例子: /delfriend BanchoBot ]"},
            {"CHT_Message_Command_me_Empty_Parameter","/me <Action>"},
            {"CHT_Message_Command_join_Empty_Parameter","/join <Channel>"},
            {"CHT_Message_Command_part_Empty_Parameter","/part <Channel>"},
            {"CHT_Message_Command_addfriend_Exist","{0} 已在你的列表中"},
            {"CHT_Message_Command_delfriend_Not_Exist","{0} 不存在你的列表中"},

            {"CHS_UI_ToolStrip_Channels", "频道"},
            {"CHS_UI_ToolStrip_Language", "语言"},
            {"CHS_UI_Login_Label_IRC_Password", "IRC验证码"},
            {"CHS_UI_Login_CheckBox_Remember_Password", "记住验证码"},
            {"CHS_UI_Login_Button_Login", "登录"},
            {"CHS_UI_Button_SendMessage", "发送"},
            {"CHS_Ping_Label", "延时: {0:F0}毫秒"},
            {"CHS_Message_Welcome","访问 https://osu.ppy.sh/p/ircauth?action=allow&ip=osu!IRC 并点击 'Authorise IRC connection' 获取你的IRC验证码"},
            {"CHS_Message_Login_Wrong_Password","登录失败 密码错误!"},
            {"CHS_Message_Login_Logging_In","登录中... ..."},
            {"CHS_Message_Login_Success","登录成功!"},
            {"CHS_Message_Login_Help","你可以输入/help查看指令帮助"},
            {"CHS_Message_Error_ChannelNotExist","该频道不存在"},
            {"CHS_Message_Error_UserNotExist","该用户不在线"},
            {"CHS_Message_Channel_Joining","尝试加入 {0} 频道..."},
            {"CHS_Message_Channel_Joined","你加入了 {0}!"},
            {"CHS_Message_Channel_Message","[{0}] {1}: "},
            {"CHS_Message_Channel_Message2","{0}"},
            {"CHS_Message_Channel_Action","[{0}] "},
            {"CHS_Message_Channel_Action2","*{0} {1}"},
            {"CHS_Message_Channel_Not_Joined","你尚未加入 {0}!"},
            {"CHS_Message_PM_Message","[PM:{0}] {1} "},
            {"CHS_Message_PM_Message2","{0}"},
            {"CHS_Message_Help_Index","指令帮助:"},
            {"CHS_Message_Help_1a","/help"},
            {"CHS_Message_Help_1b"," 查看此帮助."},
            {"CHS_Message_Help_2a","/join <Channel>"},
            {"CHS_Message_Help_2b"," 加入频道 [ 例子: /join #osu ]"},
            {"CHS_Message_Help_3a","/part <Channel>"},
            {"CHS_Message_Help_3b"," 加入频道 [ 例子: /part #osu ]"},
            {"CHS_Message_Help_4a","/me <Action>"},
            {"CHS_Message_Help_4b"," 以第三人称发送自己的动作信息"},
            {"CHS_Message_Help_5a","/addfriend <Name>"},
            {"CHS_Message_Help_5b"," 增加常用联络人到列表中 [ 例子: /addfriend BanchoBot ]"},
            {"CHS_Message_Help_6a","/delfriend <Name>"},
            {"CHS_Message_Help_6b"," 删除自定常用联络人 [ 例子: /delfriend BanchoBot ]"},
            {"CHS_Message_Command_me_Empty_Parameter","/me <Action>"},
            {"CHS_Message_Command_join_Empty_Parameter","/join <Channel>"},
            {"CHS_Message_Command_part_Empty_Parameter","/part <Channel>"},
            {"CHS_Message_Command_addfriend_Exist","{0} 已在你的列表里"},
            {"CHS_Message_Command_delfriend_Not_Exist","{0} 不在你的列表里"},

        };

    }
}