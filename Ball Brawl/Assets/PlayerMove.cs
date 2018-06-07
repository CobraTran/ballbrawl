using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float Movespeed;
    public float Jumpforce;

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

        if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-Movespeed * Time.deltaTime, rb2d.velocity.y);
        } else if (Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(Movespeed * Time.deltaTime, rb2d.velocity.y);
        } else
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x * stopSpeed, rb2d.velocity.y);
        }

        if (Input.GetKey("s"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y -Movespeed/3 * Time.deltaTime);
        }
   





            if (Input.GetKey("w") && grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, Jumpforce * Time.deltaTime );
        }

    

    }
    

}
