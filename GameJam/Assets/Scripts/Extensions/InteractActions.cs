using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractActions : ScriptableObject
{

    internal bool _MakeOnce = false;

    public virtual void ToDoAction(GameObject gameObject, bool MakeOnce)
    {
        Debug.Log("Интерация");
    }
}
