using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractArea : MonoBehaviour
{
    [SerializeField]
    private InteractActions ActionToDo;
    [SerializeField]
    private GameObject InteractTo;
    [SerializeField]
    private bool MakeOnce = false;


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Стоит в зоне действия");
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
                ActionToDo.ToDoAction(InteractTo,MakeOnce);
        }

    }
}
