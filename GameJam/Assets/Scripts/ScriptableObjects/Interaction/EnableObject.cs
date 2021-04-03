using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnableObject", menuName = "Interaction", order = 51)]
public class EnableObject : InteractActions
{
    [SerializeField]
    private GameObject toEnable;

    public override void ToDoAction()
    {
        if (toEnable.active)
        {
            toEnable.SetActive(false);
        }
        else
        {
            toEnable.SetActive(true);
        }
    }

}
