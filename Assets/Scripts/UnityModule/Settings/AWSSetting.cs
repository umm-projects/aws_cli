using System;
using UnityEngine;

namespace UnityModule.Settings
{
    public class AWSSetting : Setting<AWSSetting>, IEnvironmentSetting
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
        [SerializeField] private string pathToCommand = (
            !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(EnvironmentKeyCommandAWS))
                ? Environment.GetEnvironmentVariable(EnvironmentKeyCommandAWS)
                : DefaultCommandPathAWS
        );

        /// <summary>
        /// aws コマンドのパス
        /// </summary>
        public string PathToCommand => pathToCommand;

        /// <summary>
        /// デフォルトの aws プロフィール名
        /// </summary>
        private const string DefaultAWSProfile = "default";

        /// <summary>
        /// aws プロフィール名を設定している環境変数のキー
        /// c.f. https://docs.aws.amazon.com/ja_jp/cli/latest/userguide/cli-multiple-profiles.html
        /// </summary>
        private const string EnvironmentKeyAWSProfile = "AWS_PROFILE";

        /// <summary>
        /// aws プロフィール名の実態
        /// </summary>
        [SerializeField] private string awsProfile = (
            !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(EnvironmentKeyAWSProfile))
                ? Environment.GetEnvironmentVariable(EnvironmentKeyAWSProfile)
                : DefaultAWSProfile
        );

        /// <summary>
        /// aws プロフィール名
        /// </summary>
        public string AWSProfile => awsProfile;

#if UNITY_EDITOR
        [UnityEditor.MenuItem("Assets/Create/Settings/AWS Setting")]
        public static void CreateSettingAsset()
        {
            CreateAsset();
        }
#endif
    }
}