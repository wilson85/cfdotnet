using System;
using System.Collections.Generic;

namespace CfSharp
{
    public class TargetGroup : IEntity, IEntityValue
    {
        private readonly string _name;

        public TargetGroup(string name)
        {
            _name = name;
        }

        public string Type { get; } = "AWS::ElasticLoadBalancingV2::TargetGroup";

        public TargetGroupProperties Properties { get; set; } = new TargetGroupProperties();

        public object Value  => new EntityReference(_name);

        public TargetGroup Tags(string name, object value)
        {
            Properties.Tags.Add(new Tag(name, value));

            return this;
        }

        public TargetGroup Tags(string name, IEntityValue value) => Tags(name, value.Value);

        public TargetGroup Protocol(Protocol protocol)
        {
            Properties.Protocol = Enum.GetName(typeof(Protocol), protocol);

            return this;
        }

        public TargetGroup Port(IEntityValue port) => Port((int)port.Value);

        public TargetGroup Port(int port)
        {
            Properties.Port = port;

            return this;
        }

        public TargetGroup VpcId(object vpcId)
        {
            Properties.VpcId = vpcId;

            return this;
        }

        public TargetGroup VpcId(IEntityValue vpcId) => VpcId(vpcId.Value);

        public TargetGroup HealthCheckIntervalSeconds(int seconds)
        {
            Properties.HealthCheckIntervalSeconds = seconds;
            return this;
        }

        public TargetGroup HealthCheckPath(object path)
        {
            Properties.HealthCheckPath = path;
            return this;
        }

        public TargetGroup HealthCheckPort(int port)
        {
            Properties.HealthCheckPort = port;

            return this;
        }

        public TargetGroup HealthCheckProtocol(Protocol protocol)
        {
            Properties.HealthCheckProtocol = Enum.GetName(typeof(Protocol), protocol);

            return this;
        }

        public TargetGroup HealthCheckTimeoutSeconds(int seconds)
        {
            Properties.HealthCheckTimeoutSeconds = seconds;

            return this;
        }

        public TargetGroup HealthyThresholdCount(int count)
        {
            Properties.HealthyThresholdCount = count;

            return this;
        }

        public TargetGroup UnhealthyThresholdCount(int count)
        {
            Properties.UnhealthyThresholdCount = count;

            return this;
        }

        public TargetGroup Matcher(string statusCode)
        {
            Properties.Matcher.HttpCode = statusCode;

            return this;
        }

        public TargetGroup DeregistrationDelayTimeoutSeconds(int seconds)
        {
            Properties.TargetGroupAttributes.Add(
                new EntityKeyValue("deregistration_delay.timeout_seconds", seconds.ToString()));

            return this;
        }

        public TargetGroup StickinessEnabled(bool enabled)
        {
            Properties.TargetGroupAttributes.Add(
                new EntityKeyValue("stickiness.enabled", enabled.ToString()));

            return this;
        }

        public TargetGroup StickinessLbCookieDurationSeconds(int seconds)
        {
            Properties.TargetGroupAttributes.Add(
                new EntityKeyValue("stickiness.lb_cookie.duration_seconds", seconds.ToString()));

            return this;
        }

        public TargetGroup StickinessType(StickinessType type)
        {
            Properties.TargetGroupAttributes.Add(
                new EntityKeyValue("stickiness.lb_cookie.duration_seconds", Enum.GetName(typeof(StickinessType), type)));

            return this;
        }

        public string GetName()
        {
            return _name;
        }
    }

    public enum StickinessType
    {
        lb_cookie
    }

    public enum Protocol
    {
        HTTP,
        HTTPS
    }

    public class TargetGroupProperties
    {
        public List<Tag> Tags { get; set; } = new List<Tag>();

        public object Protocol { get; set; }

        public object Port { get; set; }

        public object VpcId { get; set; }

        public object HealthCheckIntervalSeconds { get; set; }

        public object HealthCheckPath { get; set; }

        public object HealthCheckPort { get; set; }

        public object HealthCheckProtocol { get; set; }

        public object HealthCheckTimeoutSeconds { get; set; }

        public object HealthyThresholdCount { get; set; }

        public object UnhealthyThresholdCount { get; set; }

        public Matcher Matcher { get; set; } = new Matcher();

        public List<EntityKeyValue> TargetGroupAttributes { get; set; } = new List<EntityKeyValue>();



    }

    public class Matcher
    {
        public object HttpCode { get; set; }
    }
}
