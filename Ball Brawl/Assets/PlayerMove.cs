using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float Movespeed;
    public float Jumpforce;

    public GameObject ground;

    public string up;
    public string down;
    public string left;
    public string right;

    public bool grounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float stopSpeed;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
		
	}

   
    // Update is called once per frame
    void FixedUpdate () {
        

        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (grounded)
        {
            ground = Physics2D.OverlapCircle(groundCheck.position, checkRadius).gameObject;
        } else
        {
            ground = null;
        }

        Vector2 move = new Vector2();

        if (Input.GetKey(left))
        {
            move = new Vector2(-Movespeed * Time.deltaTime, rb2d.velocity.y);
        } else if (Input.GetKey(right))
        {
            move = new Vector2(Movespeed * Time.deltaTime, rb2d.velocity.y);
        } else
        {
            move = new Vector2(rb2d.velocity.x * stopSpeed, rb2d.velocity.y);
        }

        if (Input.GetKey(down))
        {
            move = new Vector2(rb2d.velocity.x, rb2d.velocity.y -Movespeed/3 * Time.deltaTime);
        }

        if (Input.GetKey(up) && grounded)
        {
            move = new Vector2(rb2d.velocity.x, Jumpforce * Time.deltaTime );
        }
        

        //setvelocity surface effector workaround
        if (ground && ground.GetComponent<surfaceEffect>())
        {

            surfaceEffect surface = ground.GetComponent<surfaceEffect>();
            move += surface.effect;

        }

        rb2d.velocity = move;

    }
    

}
