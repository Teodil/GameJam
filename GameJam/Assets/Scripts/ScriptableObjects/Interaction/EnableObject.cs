using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnableObject", menuName = "EnableObject", order = 51)]
public class EnableObject : InteractActions
{

    public override void ToDoAction(GameObject InteractTo, bool MakeOnce)
    {
        Debug.Log("Дейсвтие свершилось");
        if (!MakeOnce)
        {
            if (InteractTo.active)
            {
                InteractTo.SetActive(false);
            }
            else
            {
                InteractTo.SetActive(true);
            }
        }
        _MakeOnce = MakeOnce; 
    }

}
