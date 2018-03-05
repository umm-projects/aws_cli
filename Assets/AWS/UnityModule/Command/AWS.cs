
using System.Collections.Generic;
using UnityModule.Settings;

namespace UnityModule.Command {

    public static class AWS {

        private enum CommandType {
            S3,
        }

        private static readonly Dictionary<CommandType, string> COMMAND_MAP = new Dictionary<CommandType, string>() {
            { CommandType.S3, "s3" },
        };

        public static class S3 {

            private enum SubCommandType {
                Copy,
            }

            private static readonly Dictionary<SubCommandType, string> SUB_COMMAND_MAP = new Dictionary<SubCommandType, string>() {
                { SubCommandType.Copy, "cp" },
            };

            public static string Copy(string path1, string path2) {
                return Runner<string>.Run(
                    EnvironmentSetting.Instance.Path.CommandAws,
                    COMMAND_MAP[CommandType.S3],
                    new List<string>() {
                        SUB_COMMAND_MAP[SubCommandType.Copy],
                        path1,
                        path2
                    }
                );
            }

        }

    }


}