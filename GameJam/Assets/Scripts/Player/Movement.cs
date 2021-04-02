using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rigidbody;
    private float right;

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float JumpForce = 20f;

    [SerializeField]
    private float timerFoDoubleClick = 0;
    [SerializeField]
    private float maxTimeForDoubleClick = 0.2f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
                right = speed * Input.GetAxis("Horizontal");
                rigidbody.velocity = new Vector2(right, rigidbody.velocity.y);
                timerFoDoubleClick += Time.deltaTime;
        }
        if((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) && timerFoDoubleClick < maxTimeForDoubleClick)
        {
            timerFoDoubleClick = 0;
            rigidbody.AddForce(new Vector2(5 * Input.GetAxis("Horizontal"), 0), ForceMode2D.Impulse);
        }


    }



    public void Jump(float jumpForce)
    {
        Debug.Log("прышок сила " + jumpForce);
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        Debug.Log(rigidbody.velocity);
    }

}
