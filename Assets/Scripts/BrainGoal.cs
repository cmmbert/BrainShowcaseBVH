using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainGoal : MonoBehaviour
{
    [Serializable]
    public class ConditionExt
    {
        public BaseAICondition Condition;
        public bool DesiredState = true;
    }
    public string Name;
    public List<ConditionExt> Conditions = new List<ConditionExt>();
    public List<BaseAIAction> Actions = new List<BaseAIAction>();
    public bool AddConditionsToCompletionConds = false;
    public List<ConditionExt> CompletionConds = new List<ConditionExt>();

    private void Start()
    {
        if (AddConditionsToCompletionConds)
        {
            foreach (var cond in Conditions)
            {
                var complCond = new ConditionExt();
                complCond.DesiredState = !cond.DesiredState;
                complCond.Condition = cond.Condition;
                CompletionConds.Add(complCond);
            }
        }
    }
    public bool ConditionsMet()
    {
        var allCondsMet = true;
        foreach (var cond in Conditions)
        {
            cond.Condition.OnUpdate();
            if (cond.Condition.Condition != cond.DesiredState)
            {
                allCondsMet = false;
                break;
            }
        }
        return allCondsMet;
    }

    public bool Completed()
    {
        var allCondsMet = true;
        foreach (var cond in CompletionConds)
        {
            cond.Condition.OnUpdate();
            if (cond.Condition.Condition != cond.DesiredState)
            {
                allCondsMet = false;
                break;
            }
        }
        return allCondsMet;
    }

}
