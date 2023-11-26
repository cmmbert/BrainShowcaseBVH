using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIActionMoveToObject : BaseAIAction
{
    [SerializeField]
    private GameObject ObjToMoveTo;
    [SerializeField]
    private NavMeshAgent NavMeshAgent;
    [SerializeField]
    private Animator Animator;

    private void Awake()
    {
        if(ObjToMoveTo == null)
            Debug.LogError("Please add a gameobject to ObjToMoveTo on " + gameObject.name);

        if (NavMeshAgent == null)
        {
            NavMeshAgent = GetComponent<NavMeshAgent>();
            if(NavMeshAgent == null)
            {
                Debug.LogError("Please add a NavMeshAgent to " + gameObject.name);
            }
        }
    }
    public override void OnEntry()
    {
        base.OnEntry();
        Animator.SetBool("isRunning", true);
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        NavMeshAgent.destination = ObjToMoveTo.transform.position;
    }

    public override void OnExit()
    {
        base.OnExit();
        Animator.SetBool("isRunning", false);
        NavMeshAgent.ResetPath();
    }

}
