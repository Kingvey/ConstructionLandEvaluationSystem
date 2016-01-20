using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.IO;

using System.Configuration;
using System.Xml;

namespace ConstructionLandEvaluationSystem
{
    public class ConfigurationHelper
    {
        /*
        #region ConnectionStrings节点操作
        /// <summary>
        /// 根据键值获取配置文件
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetAppSettingKeyValue(string key)
        {
            string val = string.Empty;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
                val = ConfigurationManager.AppSettings[key];
            return val;
        }
        public static string GetConfig(string key, string defaultValue)
        {
            string val = defaultValue;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
                val = ConfigurationManager.AppSettings[key];
            if (val == null)
                val = defaultValue;
            return val;
        }

        /// <summary>
        /// 获取所有配置文件
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAppSettingsAllKeys()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (string key in ConfigurationManager.AppSettings.AllKeys)
                dict.Add(key, ConfigurationManager.AppSettings[key]);
            return dict;
        }

        /// <summary>
        /// 写配置文件,如果节点不存在则自动创建
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="value">值</param>
        /// /// <param name="dict">键值集合</param>
        /// <returns></returns>
        public static bool SetAppSettingsKey(string key, string value)
        {
            try
            {
                Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (!conf.AppSettings.Settings.AllKeys.Contains(key))
                    conf.AppSettings.Settings.Add(key, value);
                else
                    conf.AppSettings.Settings[key].Value = value;
                conf.Save();
                return true;
            }
            catch { return false; }
        }
        public static bool SetAppSettingsKeys(Dictionary<string, string> dict)
        {
            try
            {
                if (dict == null || dict.Count == 0)
                    return false;
                Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                foreach (string key in dict.Keys)
                {
                    if (!conf.AppSettings.Settings.AllKeys.Contains(key))
                        conf.AppSettings.Settings.Add(key, dict[key]);
                    else
                        conf.AppSettings.Settings[key].Value = dict[key];
                }
                conf.Save();
                return true;
            }
            catch { return false; }
        }
        #endregion
        */

        #region AppSettings节点操作
        /// <summary>
        /// 根据键值获取配置文件
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetAppSettingKeyValue(string key)
        {
            string val = string.Empty;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
                val = ConfigurationManager.AppSettings[key];
            return val;
        }
        public static string GetAppSettingKeyValue(string key, string defaultValue)
        {
            string val = defaultValue;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
                val = ConfigurationManager.AppSettings[key];
            if (val == null)
                val = defaultValue;
            return val;
        }

        /// <summary>
        /// 获取所有配置文件
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAppSettingsAllKeys()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (string key in ConfigurationManager.AppSettings.AllKeys)
                dict.Add(key, ConfigurationManager.AppSettings[key]);
            return dict;
        }

        /// <summary>
        /// 写配置文件,如果节点不存在则自动创建
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="value">值</param>
        /// /// <param name="dict">键值集合</param>
        /// <returns></returns>
        public static bool SetAppSettingsKey(string key, string value)
        {
            try
            {
                Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (!conf.AppSettings.Settings.AllKeys.Contains(key))
                    conf.AppSettings.Settings.Add(key, value);
                else
                    conf.AppSettings.Settings[key].Value = value;
                conf.Save(ConfigurationSaveMode.Modified);
                return true;
            }
            catch { return false; }
        }
        public static bool SetAppSettingsKeys(Dictionary<string, string> dict)
        {
            try
            {
                if (dict == null || dict.Count == 0)
                    return false;
                Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                foreach (string key in dict.Keys)
                {
                    if (!conf.AppSettings.Settings.AllKeys.Contains(key))
                        conf.AppSettings.Settings.Add(key, dict[key]);
                    else
                        conf.AppSettings.Settings[key].Value = dict[key];
                }
                conf.Save(ConfigurationSaveMode.Modified);
                return true;
            }
            catch { return false; }
        }
        #endregion

        //通过访问Xml文件方式更新Config节点
        public static bool UpdateNoteValue(string nodeName, string key, string value)
        {
            bool isSucceed = false;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");

                System.Xml.XmlNode xNode;
                System.Xml.XmlElement xElemip;
                System.Xml.XmlElement xElem2;
                xNode = xmlDoc.SelectSingleNode("//" + nodeName);
                xElemip = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='"+key+"']");
                if (xElemip != null) xElemip.SetAttribute("value", value);
                else
                {
                    xElem2 = xmlDoc.CreateElement("add");
                    xElem2.SetAttribute("key", key);
                    xElem2.SetAttribute("value", value);
                    xNode.AppendChild(xElem2);
                }

                xmlDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return isSucceed;
        }
    }
}
