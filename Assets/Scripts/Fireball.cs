using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Rigidbody2D rigidBody;

    public Vector2 velocity;
	// Use this for initialization
	void Start () {
		rigidBody.AddForce(velocity, ForceMode2D.Impulse);
        Destroy(gameObject,5);
	}
    //Jesus Christ 
    // Update is called once per frame
   void  OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
