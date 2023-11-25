using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIConditionIsLookingAt : BaseAICondition
{
    public GameObject ObjToCheck;
    public GameObject ObjToLookAt;

    [Range(0.5f, 1f)]
    public float Accuracy = 0.8f;
    // Update is called once per frame
    public override void OnUpdate()
    {
        var latPos1 = ObjToLookAt.transform.position;
        latPos1.y = 0;
        var latPos2 = ObjToCheck.transform.position;
        latPos2.y = 0;
        var perfectLookatVector = (latPos1 - latPos2).normalized;
        var dot = Vector3.Dot(ObjToCheck.transform.forward, perfectLookatVector);
        Condition = dot > Accuracy;
    }
}
