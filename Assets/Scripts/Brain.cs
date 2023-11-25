using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public List<BrainGoal> Goals;

    private BrainGoal _currentGoal;
    private BrainGoal CurrentGoal {
        get { return _currentGoal; }
        set
        {
            if(_currentGoal)
                foreach (var goal in _currentGoal.Actions)
                {
                    goal.OnExit();
                }

            _currentGoal = value;

            if(_currentGoal)
                foreach (var goal in _currentGoal.Actions)
                {
                    goal.OnEntry();
                }
        }
    }


    private void Update()
    {
        //if (CurrentGoal && CurrentGoal.Completed()) Debug.Log(CurrentGoal.name + " completed");
        if (CurrentGoal != null)
        {
            foreach (var goal in CurrentGoal.Actions)
            {
                goal.OnUpdate();
            }

            if (CurrentGoal.Completed())
                NewGoal();
        }
        else
        {
            NewGoal();
        }
    }

    private void NewGoal()
    {
        BrainGoal newGoal = null;
        foreach (var goal in Goals)
        {
            if (goal.ConditionsMet())
            {
                newGoal = goal;
                break;
            }
        }
        CurrentGoal = newGoal;
    }
}
