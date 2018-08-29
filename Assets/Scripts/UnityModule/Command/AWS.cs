using System.Collections.Generic;
using UnityModule.Settings;

// ReSharper disable UseStringInterpolation

namespace UnityModule.Command
{
    public static class AWS
    {
        private enum CommandType
        {
            S3
        }

        private static readonly Dictionary<CommandType, string> COMMAND_MAP = new Dictionary<CommandType, string>
        {
            {CommandType.S3, "s3"}
        };

        private static class Runner
        {
            public static string Run(CommandType commandType, IReadOnlyCollection<string> argumentMap = null)
            {
                var handedArgumentMap = argumentMap == null ? new List<string>() : new List<string>(argumentMap);
                handedArgumentMap.Add($"--profile {AWSSetting.GetOrDefault().AWSProfile}");

                return Runner<string>.Run(
                    AWSSetting.GetOrDefault().PathToCommand,
                    COMMAND_MAP[commandType],
                    handedArgumentMap);
            }
        }

        public static class S3
        {
            public enum AccessControlListType
            {
                Private,
                PublicRead,
                PublicReadWrite
            }

            private enum SubCommandType
            {
                Copy,
                List
            }

            private static readonly Dictionary<SubCommandType, string> SUB_COMMAND_MAP =
                new Dictionary<SubCommandType, string>
                {
                    {SubCommandType.Copy, "cp"},
                    {SubCommandType.List, "ls"}
                };

            private static readonly Dictionary<AccessControlListType, string> ACL_MAP =
                new Dictionary<AccessControlListType, string>
                {
                    {AccessControlListType.Private, "private"},
                    {AccessControlListType.PublicRead, "public-read"},
                    {AccessControlListType.PublicReadWrite, "public-read-write"}
                };

            public static string Copy(string path1, string path2,
                AccessControlListType accessControlListType = AccessControlListType.Private)
            {
                return Runner.Run(
                    CommandType.S3,
                    new List<string>
                    {
                        SUB_COMMAND_MAP[SubCommandType.Copy],
                        path1,
                        path2,
                        $"--acl {ACL_MAP[accessControlListType]}"
                    }
                );
            }

            public static string List(string path)
            {
                return Runner.Run(
                    CommandType.S3,
                    new List<string>
                    {
                        SUB_COMMAND_MAP[SubCommandType.List],
                        path
                    }
                );
            }
        }
    }
}