using System;
using UnityEngine;

namespace UnityModule.Settings
{
    public class AWSSetting : Setting<AWSSetting>
    {
        /// <summary>
        /// デフォルトの aws コマンドパス
        /// </summary>
        private const string DefaultCommandPathAWS = "/usr/local/bin/aws";

        /// <summary>
        /// aws コマンドへのパスを保存している環境変数のキー
        /// </summary>
        private const string EnvironmentKeyCommandAWS = "COMMAND_AWS";

        /// <summary>
        /// aws コマンドのパスの実体
        /// </summary>
        [SerializeField] private string pathToCommand;

        /// <summary>
        /// aws コマンドのパス
        /// </summary>
        public string PathToCommand
        {
            get
            {
                if (string.IsNullOrEmpty(pathToCommand))
                {
                    pathToCommand = Environment.GetEnvironmentVariable(EnvironmentKeyCommandAWS);
                }

                if (string.IsNullOrEmpty(pathToCommand))
                {
                    pathToCommand = DefaultCommandPathAWS;
                }

                return pathToCommand;
            }
#if UNITY_EDITOR
        [UnityEditor.MenuItem("Assets/Create/Settings/AWS Setting")]
        public static void CreateSettingAsset()
        {
            CreateAsset(true);
        }
#endif
    }
}