using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAIAction : MonoBehaviour
{
    public virtual void OnEntry() { }
    public virtual void OnUpdate() { }
    public virtual void OnExit() { }
}
