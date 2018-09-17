using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    
   
    public float speed;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody2D;
    public GameObject fireBall;
    public Tilemap tileMap;
    public float jumpForce;
    public float fireRate;

    private float nextEventTime;
    private float horizontal;

    private void Start()
    {
        nextEventTime = Time.time+fireRate;
    }
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

	    if (Input.GetMouseButton(0))
	    {
	        if (nextEventTime <= Time.time)
	        {
	            nextEventTime = Time.time+fireRate;
	            Instantiate(fireBall, transform.position, Quaternion.Euler(0, 0, 90));
	        }
	    }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider != null)
        {
            if (other.collider.tag == "TileMap")
            {
                Vector3Int local = Vector3Int.FloorToInt(transform.InverseTransformPoint(transform.position));
                
                TileBase tile = tileMap.GetTile(local);
                print(tile);
            }
        }
    }



}
