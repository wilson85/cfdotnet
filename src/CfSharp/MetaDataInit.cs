using System.Collections.Generic;
using Newtonsoft.Json;

namespace CfSharp
{
    public class MetaData
    {
        [JsonProperty(PropertyName = "AWS::CloudFormation::Init")]
        public Init Init { get; set; } = new Init();
    }

    public class Init : Dictionary<string, object>
    {
        [JsonProperty(PropertyName = "configSets")]
        public ConfigSets ConfigSets = new ConfigSets();

        public Config Config(string name)
        {
            Config config = new Config();

            this.Add(name, config);

            return config;
        }
    }

    public class ConfigSets : Dictionary<string, Config>
    {

    }

    public class Config
    {
        [JsonProperty(PropertyName = "commands")]
        public Dictionary<string, ConfigCommands> Commands { get; set; } = new Dictionary<string, ConfigCommands>();



        public ConfigCommands Command(string name)
        {
            ConfigCommands cmd = new ConfigCommands();

            Commands.Add(name, cmd);

            return cmd;
        }

        public class ConfigCommands
        {
            public ConfigCommands Command(object command)
            {
                CommandProp = command;
                return this;
            }

            public ConfigCommands Environment(string name, object env)
            {
                Env.Add(name, env);
                return this;
            }

            public ConfigCommands Cwd(object cwd)
            {
                CwdProp = cwd;
                return this;
            }

            public ConfigCommands Test(object test)
            {
                TestProp = test;
                return this;
            }

            public ConfigCommands IgnoreError(bool ignoreError)
            {
                IgnoreErrorProp = ignoreError;
                return this;
            }

            public ConfigCommands WaitAfterCompletion(object waitAfterCompletion)
            {
                WaitAfterCompletionProp = waitAfterCompletion;
                return this;
            }

            [JsonProperty(PropertyName = "command")]
            public object CommandProp { get; set; }

            [JsonProperty(PropertyName = "env")]
            public Dictionary<string, object> Env { get; set; } = new Dictionary<string, object>();

            [JsonProperty(PropertyName = "cwd")]
            public object CwdProp { get; set; }

            [JsonProperty(PropertyName = "test")]
            public object TestProp { get; set; }

            [JsonProperty(PropertyName = "ignoreError")]
            public bool IgnoreErrorProp { get; set; }

            [JsonProperty(PropertyName = "waitAfterCompletion")]
            public object WaitAfterCompletionProp { get; set; }
        }
    }
}
