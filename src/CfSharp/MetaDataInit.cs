using System.Collections.Generic;
using Newtonsoft.Json;

namespace CfSharp
{
    public class MetaData
    {
        [JsonProperty(PropertyName = "AWS::CloudFormation::Init")]
        public Init Init { get; set; } = new Init();

        [JsonProperty(PropertyName = "files")]
        public Dictionary<string, File> Files { get; set; }

        public Services Services { get; set; }

        public object Comment { get; set; }
    }

    public class Services
    {
        [JsonProperty(PropertyName = "windows")]
        public Dictionary<string, Service> Windows { get; set; }

        [JsonProperty(PropertyName = "sysvinit")]
        public Dictionary<string, Service> Sysvinit { get; set; }
    }

    public class Init : Dictionary<string, object>
    {
        [JsonProperty(PropertyName = "configSets")]
        public ConfigSets ConfigSets = new ConfigSets();

        public Packages Packages { get; set; }

        public Config Config(string name)
        {
            Config config = new Config();

            this.Add(name, config);

            return config;
        }
    }


    public class Service
    {
        public object EnsureRunning { get; set; }

        public object Enabled { get; set; }


    }

    public class File
    {
        public object Content { get; set; }

        public object Source { get; set; }

        public object Encoding { get; set; }

        public object Group { get; set; }

        public object Owner { get; set; }

        public object Mode { get; set; }

        public object Authentication { get; set; }

        public object Context { get; set; }
    }

    public class Packages
    {
        [JsonProperty(PropertyName = "yum")]
        public Dictionary<string, List<object>> Yum { get; set; }

        [JsonProperty(PropertyName = "rubygems")]
        public Dictionary<string, List<object>> Rubygems { get; set; }

        [JsonProperty(PropertyName = "rpm")]
        public Dictionary<string, List<object>> Rpm { get; set; }

        [JsonProperty(PropertyName = "python")]
        public Dictionary<string, List<object>> Python { get; set; }

        [JsonProperty(PropertyName = "msi")]
        public Dictionary<string, List<object>> Msi { get; set; }

        [JsonProperty(PropertyName = "apt")]
        public Dictionary<string, List<object>> Apt { get; set; }

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
