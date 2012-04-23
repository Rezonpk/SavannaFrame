using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannaFrame.Classes
{
    /// <summary>
    /// Class present count of rules for production 
    /// </summary>
    class Rule
    {
        // id правила
        public int RuleId { get; set; }
        // Имя правила
        public string RuleName { get; set; }
        // Объяснения для правила
        public string Reason { get; set; }
        // список поссылок
        public List<RuleCondition> RuleCondutions;
        // список заклюений
        public List<RuleEnd> RuleEnds;

        public Rule()
        {
            RuleCondutions = new List<RuleCondition>();
            RuleEnds = new List<RuleEnd>();
        }

    }

    /// <summary>
    /// Class present condition in rule
    /// </summary>
    class RuleCondition
    {
        // id поссылки
        public int ConditionId { get; set; }
        // Имя переменной
        public string Variable { get; set; }
        // Значение переменной
        public string Value { get; set; }

        public RuleCondition()
        {
            Variable = "unknown";
            Value = "none";
        }
    }

    /// <summary>
    /// Class present end of rule
    /// </summary>
    class RuleEnd
    {
        // id заключения
        public int EndId { get; set; }
        // Имя переменной
        public string Variable { get; set; }
        // Значение переменной
        public string Value { get; set; }

        public RuleEnd()
        {
            Variable = "unknown";
            Value = "none";
        }
    }

}
