using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Jump : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rigidbody;
    private Animator animator;
    
    [SerializeField]
    private float Force = 50f;
    [SerializeField]
    private float timer = 1;
    [SerializeField]
    private float maxTime = 2f;

    public bool IsJumping { get; private set; }



    void Start()
    {
        IsJumping = false;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.velocity.y == 0)
        {
            IsJumping = false;
            animator.SetBool("IsFalling", false);
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
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
                animator.SetTrigger("Jump");
                IsJumping = true;
            }
        }
        if (rigidbody.velocity.y < 0)
        {
            IsJumping = true;
            animator.SetBool("IsFalling", true);
        }
        else
            animator.SetBool("IsFalling", false);

    }
}
