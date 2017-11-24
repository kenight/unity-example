using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventOnCollisionBase : MonoBehaviour
{
    public When when = When.Enter;
    public bool enableCompare = false;
    public string compareFor = "Player";
    public UnityEvent unityEvent;

    public enum When
    {
        Enter,
        Exit,
        Stay
    }
}
