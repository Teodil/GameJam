using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractArea : MonoBehaviour
{
    [SerializeField]
    private ScriptableObject ActionToDo;
    private Interaction playerInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerInteract = collision.GetComponent<Interaction>();
            playerInteract.Interact += ToDo;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerInteract.Interact -= ToDo;
        }
    }

    private void ToDo()
    {
        Debug.Log("Взмаимодествие");
    }
}
