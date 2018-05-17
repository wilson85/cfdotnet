using System;
using System.Collections.Generic;

namespace CfSharp
{
    public class Listener : IEntity, IEntityValue
    {
        public const string CFType = "AWS::ElasticLoadBalancingV2::Listener";
        public string Type => CFType;

        private readonly string _name;
        private readonly Stack _stack;

        public Listener()
        {

        }

        public Listener(Stack stack, string name)
        {
            _name = name;
            stack.Resources.Add(_name, this);
            _stack = stack;
        }


        public ListenerProperties Properties { get; set; } = new ListenerProperties();

        public Listener Certificates(string arn)
            => Certificates(new StringEntityValue(arn));

        public Listener Certificates(IEntityValue value)
        {
            Properties.Certificates.Add(new ListenerCertificate(value));

            return this;
        }

        public Listener LoadBalancerArn(IEntityValue arn)
         => LoadBalancerArn(arn.GetValue());

        public Listener LoadBalancerArn(object loadBalancerArn)
        {
            Properties.LoadBalancerArn = loadBalancerArn;

            return this;
        }

        public Listener DefaultAction(IEntityValue targetGroupArn, object type)
        {
            Properties.DefaultActions = new ListenerAction(targetGroupArn.GetValue(), type);

            return this;
        }

        public Listener Port(int port)
        {
            Properties.Port = port;

            return this;
        }

        public Listener Protocol(Protocol protocol)
        {
            Properties.Protocol = Enum.GetName(typeof(Protocol), protocol);

            return this;
        }

        public Listener Rules(string name, Action<ListenerRule> config)
        {
            var rule = new ListenerRule(name, _stack);
            config(rule);

            return this;
        }

        public string GetName()
        {
            return _name;
        }

        public object GetValue()
        {
            return new EntityReference(_name);
        }
    }

    public class ListenerAction
    {
        public ListenerAction(object targetGroupArn, object type)
        {
            TargetGroupArn = targetGroupArn;
            Type = type;
        }

        public object TargetGroupArn { get; set; }

        public object Type { get; set; }
    }

    public class ListenerProperties
    {
        public object LoadBalancerArn { get; set; }

        public object DefaultActions { get; set; }

        public int Port { get; set; }

        public string Protocol { get; set; }

        public List<ListenerCertificate> Certificates { get; } = new List<ListenerCertificate>();

    }

    public class ListenerCertificate
    {
        public ListenerCertificate(IEntityValue value)
        {
            CertificateArn = value.GetValue();
        }

        public object CertificateArn { get; }
    }
}
