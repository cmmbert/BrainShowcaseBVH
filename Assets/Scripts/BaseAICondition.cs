using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAICondition : MonoBehaviour
{
    public bool Condition = false;

    public virtual void OnUpdate() { }
}
