using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gayser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private ParticleSystem particle;

    [SerializeField]
    private float reloadTime = 5f;
    [SerializeField]
    private float currentReloadTime = 1;


    private bool isPlay = false;

    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        particle.Play();
    }


    private void FixedUpdate()
    {
        if (currentReloadTime > 0)
            currentReloadTime -= 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentReloadTime <= 0 && !isPlay)
        {
            isPlay = true;
            particle.Play();
        }

        if (!particle.IsAlive() && currentReloadTime<=0)
        {
            currentReloadTime = reloadTime;
            isPlay = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (particle.IsAlive() && collision.tag=="Player")
        {
            Dead dead = collision.gameObject.GetComponent<Dead>();
            dead.PlayerDead();
        }   
    }

}
