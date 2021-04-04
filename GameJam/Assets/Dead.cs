using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    // Start is called before the first frame update

    private Movement movement;
    private Jump jump;

    private Animator animator;

    [SerializeField]
    private GameObject DeadScreen;

    void Start()
    {
        movement = GetComponent<Movement>();
        jump = GetComponent<Jump>();
    }

    public void PlayerDead()
    {
        movement.enabled = false;
        jump.enabled = false;
        animator.SetTrigger("Dead");
    }

    public void ShowDeadScreen()
    {
        DeadScreen.SetActive(true);
    }



}
