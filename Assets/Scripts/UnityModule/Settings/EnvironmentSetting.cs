using System;
using UnityEngine;

namespace UnityModule.Settings {

    public partial class EnvironmentSetting {

        public partial class EnvironmentSetting_Path {

            /// <summary>
            /// デフォルトの aws コマンドパス
            /// </summary>
            private const string DEFAULT_COMMAND_PATH_AWS = "/usr/local/bin/aws";

            /// <summary>
            /// aws コマンドへのパスを保存している環境変数のキー
            /// </summary>
            private const string ENVIRONMENT_KEY_COMMAND_AWS = "COMMAND_AWS";

            /// <summary>
            /// aws コマンドのパスの実体
            /// </summary>
            [SerializeField]
            private string commandAws;

            /// <summary>
            /// aws コマンドのパス
            /// </summary>
            public string CommandAws {
                get {
                    if (string.IsNullOrEmpty(this.commandAws)) {
                        this.commandAws = Environment.GetEnvironmentVariable(ENVIRONMENT_KEY_COMMAND_AWS);
                    }
                    if (string.IsNullOrEmpty(this.commandAws)) {
                        this.commandAws = DEFAULT_COMMAND_PATH_AWS;
                    }
                    return this.commandAws;
                }
            }

        }

    }

}