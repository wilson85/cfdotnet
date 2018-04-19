using System.Collections.Generic;

namespace CfSharp
{
    public class Alarm : IEntity
    {
        private readonly string _name;
        private readonly Stack _stack;

        public Alarm(Stack stack, string name)
        {
            _name = name;
            _stack = stack;
            _stack.Resources.Add(_name, this);
        }

        public string Type { get; } = "AWS::CloudWatch::Alarm";

        public AlarmProperties Properties { get; } = new AlarmProperties();

        public Alarm ActionsEnabled(bool enabled)
        {
            Properties.ActionsEnabled = enabled;
            return this;
        }

        public Alarm Actions(string action)
        {
            Properties.AlarmActions.Add(action);
            return this;
        }

        public Alarm OKActions(string action)
        {
            Properties.OKActions.Add(action);
            return this;
        }

        public Alarm Description(string description)
        {
            Properties.AlarmDescription = description;
            return this;
        }

        public Alarm AlarmName(object name)
        {
            Properties.AlarmName = name;
            return this;
        }

        public Alarm ComparisonOperator(string op)
        {
            Properties.ComparisonOperator = op;
            return this;
        }

        public Alarm MetricName(string metric)
        {
            Properties.MetricName = metric;
            return this;
        }

        public Alarm Statistic(string stat)
        {
            Properties.Statistic = stat;
            return this;
        }

        public Alarm Namespace(string ns)
        {
            Properties.Namespace = ns;
            return this;
        }

        public Alarm Period(int period)
        {
            Properties.Period = period.ToString();
            return this;
        }

        public Alarm EvaluationPeriods(int period)
        {
            Properties.EvaluationPeriods = period.ToString();
            return this;
        }

        public Alarm Threshold(int threshold)
        {
            Properties.Threshold = threshold;
            return this;
        }

        public Alarm Dimensions(AlarmDimension dimension)
        {
            Properties.Dimensions.Add(dimension);
            return this;
        }

        public string GetName()
        {
            return _name;
        }




    }

    public class AlarmDimension
    {
        public object Name { get; set; }

        public object Value { get; set; }
    }

    public class AlarmProperties
    {
        public bool ActionsEnabled { get; set; }

        public List<object> AlarmActions { get; set; } = new List<object>();

        public object AlarmDescription { get; set; }

        public object AlarmName { get; set; }

        public object ComparisonOperator { get; set; }

        public object EvaluateLowSampleCountPercentile { get; set; }

        public object EvaluationPeriods { get; set; }

        public object ExtendedStatistic { get; set; }

        public List<object> InsufficientDataActions { get; set; } = new List<object>();

        public object MetricName { get; set; }

        public object Namespace { get; set; }

        public List<object> OKActions { get; set; } = new List<object>();

        public object Period { get; set; }

        public object Statistic { get; set; }

        public object Threshold { get; set; }

        public object TreatMissingData { get; set; }

        public object Unit { get; set; }

        public List<AlarmDimension> Dimensions { get; set; } = new List<AlarmDimension>();
    }

}
