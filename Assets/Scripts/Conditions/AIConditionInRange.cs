using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIConditionInRange : BaseAICondition
{
    public float Distance = 3;

    public Transform ObjA;
    public Transform ObjB;
    public override void OnUpdate()
    {
        Condition = (ObjA.position - ObjB.position).magnitude < Distance;
    }
}
