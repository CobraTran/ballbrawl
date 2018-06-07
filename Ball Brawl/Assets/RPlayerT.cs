using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPlayerT : MonoBehaviour { 

    public float Movespeed;
    public float Jumpforce;

    public bool grounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float stopSpeed;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }


    // Update is called once per frame
    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-Movespeed * Time.deltaTime, rb2d.velocity.y);
        }
        else if (Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(Movespeed * Time.deltaTime, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x * stopSpeed, rb2d.velocity.y);
        }


        if (Input.GetKey("down") && grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, Jumpforce * Time.deltaTime);
        }




        if (Input.GetKey("up") && grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, Jumpforce * Time.deltaTime);
        }



    }


}
