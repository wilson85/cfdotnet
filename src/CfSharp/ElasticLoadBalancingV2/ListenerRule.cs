using System;
using System.Collections.Generic;

namespace CfSharp
{
    public class ListenerRule : IEntity
    {
        private readonly string _name;
        private readonly Stack _stack;

        public ListenerRule(string name, Stack stack)
        {
            _name = name;
            _stack = stack;
            _stack.Resources.Add(name, this);
        }

        public string Type { get; } = "AWS::ElasticLoadBalancingV2::ListenerRule";

        public ListenerRuleProperties Properties { get; set; } = new ListenerRuleProperties();

        public ListenerRule ListenerArn(object listenerArn)
        {
            Properties.ListenerArn = listenerArn;
            return this;
        }

        public ListenerRule Conditions(string field, string value)
        {
            Properties.Conditions.Add(new ListenerRuleCondition(field, value));

            return this;
        }

        public ListenerRule Actions(object targetGroupArn, ListenerRuleActionType type)
        {
            Properties.Actions.Add(new ListenerAction(targetGroupArn, Enum.GetName(typeof(ListenerRuleActionType), type)));

            return this;
        }

        public string GetName()
        {
            return _name;
        }
    }

    public enum ListenerRuleActionType
    {
        forward
    }

    public class ListenerRuleProperties
    {
        public object ListenerArn { get; set; }

        public List<ListenerRuleCondition> Conditions { get; set; } = new List<ListenerRuleCondition>();

        public List<ListenerAction> Actions { get; set; } = new List<ListenerAction>();

        public object Priority { get; set; }
    }

    public class ListenerRuleCondition
    {
        public ListenerRuleCondition(object field, object value)
        {
            Field = field;
            // only ever allowed 1 value..
            Values.Add(value);
        }

        public object Field { get; set; }

        public List<object> Values { get; set; } = new List<object>();
    }
}
