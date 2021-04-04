﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gayser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float reloadBublesTime = 5f;
    [SerializeField]
    private float currentReloadBublesTime = 5f;

    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentReloadBublesTime > 0)
        {
            currentReloadBublesTime -= 1 * Time.deltaTime;
        }
        else
        {
            animator.SetTrigger("Start");
            currentReloadBublesTime = reloadBublesTime;
        }
    }

private void OnTriggerStay2D(Collider2D collision)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("steam") && collision.tag=="Player")
        {
            Dead dead = collision.gameObject.GetComponent<Dead>();
            dead.PlayerDead();
        }   
    }

}
