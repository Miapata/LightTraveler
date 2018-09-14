using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
    
   
    public float speed;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody2D;
    public GameObject fireBall;
    public float jumpForce;
    private float horizontal;
    
	
	// Update is called once per frame
	void Update ()
	{
	    horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(horizontal*speed*Time.deltaTime,0,0);
	    if (horizontal < 0)
	    {
	        spriteRenderer.flipX = true;
	    }
	    if (horizontal > 0)
	    {
	        spriteRenderer.flipX = false;
	    }

	    if (Input.GetKeyDown(KeyCode.Space))
	    {
            rigidBody2D.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
	    }

	    if (Input.GetMouseButtonDown(0))
	    {
	        Instantiate(fireBall, transform.position,Quaternion.Euler(0,0,90));
	    }
    }



}
