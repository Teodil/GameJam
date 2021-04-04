using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    [SerializeField]
    private Dead playerDead;

    [SerializeField]
    private bool ToShowDeadAnim = false;

    // Start is called before the first frame update
    void Start()
    {
        playerDead = GameObject.FindGameObjectWithTag("Player").GetComponent<Dead>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (ToShowDeadAnim)
            {
                playerDead.PlayerDead();
            }
            else
            {
                playerDead.ShowDeadScreen();
            }
        }
    }



}
