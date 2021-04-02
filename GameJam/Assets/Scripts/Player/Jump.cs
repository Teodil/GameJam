using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Jump : MonoBehaviour
{
    // Start is called before the first frame update

    
    public OnJumpEvent jumpEvent;

    [SerializeField]
    private float Force = 50f;
    [SerializeField]
    private float timer = 1;
    [SerializeField]
    private float maxTime = 2f;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            timer += Time.deltaTime;
            if (timer > maxTime)
                timer = maxTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            float jumpForce = timer * Force;
            timer = 1;
            jumpEvent.Invoke(jumpForce);
        }
    }
}
