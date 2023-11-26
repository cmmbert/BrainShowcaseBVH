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
    [SerializeField]
    private string Name;
    [SerializeField]
    private List<ConditionExt> Conditions = new List<ConditionExt>();
    [SerializeField]
    private List<BaseAIAction> Actions = new List<BaseAIAction>();
    [SerializeField]
    private bool AddConditionsToCompletionConds = false;
    [SerializeField]
    private List<ConditionExt> CompletionConds = new List<ConditionExt>();

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

    public void OnUpdate()
    {
        foreach (var action in Actions)
        {
            action.OnUpdate();
        }
    }

    public void OnExit()
    {
        foreach (var action in Actions)
        {
            action.OnExit();
        }
    }

    public void OnEntry()
    {
        foreach (var action in Actions)
        {
            action.OnEntry();
        }
    }

}
