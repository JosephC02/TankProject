using System;
using System.Collections.Generic;

public class Rule
{
    private string _antecedentA;
    private string _antecedentB;
    private Type _consequence;
    private Predicate _predicate;

    public enum Predicate
    {
        And,
        Or,
        NAnd
    }

    public Rule(string antecedentA, string antecedentB, Type consequence, Predicate predicate)
    {
        _antecedentA = antecedentA;
        _antecedentB = antecedentB;
        _consequence = consequence;
        _predicate = predicate;
    }

    public Type CheckRule(Dictionary<string, bool> facts)
    {
        return _predicate switch
        {
            Predicate.And => facts[_antecedentA] && facts[_antecedentB] ? _consequence : null,
            Predicate.Or => facts[_antecedentA] || facts[_antecedentB] ? _consequence : null,
            Predicate.NAnd => !facts[_antecedentA] && !facts[_antecedentB] ? _consequence : null,
            _ => null
        };
    }
}