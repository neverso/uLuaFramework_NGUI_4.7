using UnityEngine;
using System.Collections.Generic;
using System;
using System.Xml;
using UnityEngine.Events;
using Config.ConfigObj;

namespace Config
{
    public class ConfigMgr
    {

        private static ConfigMgr _instance;


        //string path = Application.dataPath + "/StreamingAssets/Config/";

        //string prePath = ".xml";

        Dictionary<string, Type> types;

        public static ConfigMgr Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigMgr();
                }

                return _instance;
            }
        }

        private ConfigMgr()
        {

        }

        void InitConfig()
        {
            types = new Dictionary<string, Type>();
            RegType<IconConfig>(IconConfig.urlKey);
        }

        void RegType<T>(string key)
        {
            types.Add(key, typeof(T));
        }


        /// <summary>
        /// 解析配置
        /// </summary>
        public void Parse()
        {
            TextAsset xmlAsset = Resources.Load<TextAsset>("Config/" + "IconConfig");
            if (xmlAsset != null)
            {
                //Loom.RunAsync(() =>
                //{
                try
                {
                    //Debug.Log(" --->> xmlAsset : " + xmlAsset.text);
                    IconConfig.Parse(xmlAsset);
                }
                catch (Exception err)
                {
                    Debug.LogError(" IconConfig : " + err.Message);

                }

            }
            else
            {
                Debug.Log(" --->> xmlAsset null !!!");
            }

        }

    }
}

