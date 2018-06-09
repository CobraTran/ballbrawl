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

    public bool walledRight;
    public bool walledLeft;
    public Transform wallCheckR;
    public Transform wallCheckL;
    public float wallFriction;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
		
	}

   
    // Update is called once per frame
    void FixedUpdate () {
        
        //ground checking
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (grounded)
        {
            ground = Physics2D.OverlapCircle(groundCheck.position, checkRadius).gameObject;
        } else
        {
            ground = null;
        }

        Vector2 move = new Vector2();

        //movement keys
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
            move = new Vector2(rb2d.velocity.x, rb2d.velocity.y - Movespeed/3 * Time.deltaTime);
            if(walledLeft || walledRight) {
                move.y += wallFriction * Time.deltaTime;
                Debug.Log("fricc");
            }
        }
        if (Input.GetKey(up) && grounded){
            move = new Vector2(rb2d.velocity.x, Jumpforce * Time.deltaTime );
        }


        //wall jumping
        walledRight = Physics2D.OverlapCircle(wallCheckR.position, checkRadius, whatIsGround);
        walledLeft = Physics2D.OverlapCircle(wallCheckL.position, checkRadius, whatIsGround);
        if (Input.GetKey(up) && walledRight) {
            move = new Vector2(-Jumpforce * Time.deltaTime, Jumpforce * Time.deltaTime);
        } else if (Input.GetKey(up) && walledLeft) {
            move = new Vector2(Jumpforce * Time.deltaTime, Jumpforce * Time.deltaTime);
        } else if (walledLeft || walledRight && !Input.GetKey(down)) {
            move.y = rb2d.velocity.y + wallFriction * Time.deltaTime;
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
