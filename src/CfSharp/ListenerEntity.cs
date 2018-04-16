using System;
using System.Collections.Generic;

namespace CfSharp
{
    public class ListenerEntity : IEntity
    {
        private readonly string _name;
        private readonly Stack _stack;

        public ListenerEntity(Stack stack, string name)
        {
            _name = name;
            stack.Resources.Add(_name, this);
            _stack = stack;
        }

        public string Type { get; } = "AWS::ElasticLoadBalancingV2::Listener";

        public ListenerProperties Properties { get; set; } = new ListenerProperties();

        public ListenerEntity Certificate(string arn)
            => Certificate(new StringEntityValue(arn));

        public ListenerEntity Certificate(IEntityValue value)
        {
            Properties.Certificates.Add(new ListenerCertificate(value));

            return this;
        }

        public ListenerEntity LoadBalancerArn(IEntityValue arn)
         => LoadBalancerArn(arn.Value);

        public ListenerEntity LoadBalancerArn(object arn)
        {
            Properties.LoadBalancerArn = arn;

            return this;
        }

        public ListenerEntity DefaultAction(IEntityValue targetGroupArn, object type)
        {
            Properties.DefaultActions = new ListenerAction(targetGroupArn.Value, type);

            return this;
        }

        public ListenerEntity Port(int port)
        {
            Properties.Port = port;

            return this;
        }

        public ListenerEntity Protocol(Protocol protocol)
        {
            Properties.Protocol = Enum.GetName(typeof(Protocol), protocol);

            return this;
        }

        public ListenerEntity Rules(string name, Action<ListenerRule> config)
        {
            var rule = new ListenerRule(name,_stack);
            config(rule);
            
            return this;
        }

        public string GetName()
        {
            return _name;
        }
    }

    public class ListenerAction
    {
        public ListenerAction(object targetGroupArn, object type)
        {

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
            CertificateArn = value.Value;
        }

        public object CertificateArn { get; }
    }
}
