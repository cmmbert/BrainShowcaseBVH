using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionRotateTo : BaseAIAction
{
    public GameObject ObjToTurn;
    public GameObject ObjToLookAt;
    public float RotationSpeed = 100;
    public Animator Animator;

    public override void OnEntry()
    {
        base.OnEntry();
        Animator.SetBool("isRunning", true);
    }

    public override void OnExit()
    {
        base.OnExit();
        Animator.SetBool("isRunning", false);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        var perfectLookatVector = (ObjToLookAt.transform.position - ObjToTurn.transform.position).normalized;
        var cross = Vector3.Cross(ObjToTurn.transform.forward, perfectLookatVector).normalized;
        float sign = cross.y > 0 ? 1 : -1;
        ObjToTurn.transform.Rotate(new Vector3(0, RotationSpeed * Time.deltaTime * sign, 0));
    }
}
