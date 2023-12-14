using System.Collections.Generic;

public class Rules
{
    public List<Rule> RuleList { get; } = new List<Rule>();
    
    public void AddRule(Rule rule)
    {
        RuleList.Add(rule);
    }
}