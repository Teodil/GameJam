using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rigidbody;
    private Jump jump;
    private Vector2 right;

    [SerializeField]
    private float speed = 5f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        right = transform.right * speed * Input.GetAxis("Horizontal");

        rigidbody.velocity = right;
        

    }


    public void Jump(Vector2 jumpForce)
    {
        rigidbody.velocity += jumpForce;
    }

}
