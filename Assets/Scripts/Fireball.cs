using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public GameObject fireBallLight;
    public Vector2 velocity;
    public float fireBallSpeed;

    private Vector3 mousePosition;
	// Use this for initialization
	void Start ()
	{

        InvokeRepeating("CheckVelocity",0,0.1f);
	    Vector2 target =Camera.main.ScreenToWorldPoint(Input.mousePosition);
	    float AngleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
	    // Get Angle in Degrees
	    float AngleDeg = (180 / Mathf.PI) * AngleRad;
	    // Rotate Object
	    this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg+90);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	    velocity = mousePosition -transform.position;
	    velocity.Normalize();
	    velocity *= fireBallSpeed;
	    rigidBody.velocity = velocity;
        Destroy(gameObject,5);
	}


    void CheckVelocity()
    {
        if (rigidBody.velocity == Vector2.zero)
        {
            fireBallLight.transform.parent = GameManager.instance.lightContainer.transform;
            fireBallLight.SendMessage("Fade");
            CancelInvoke();
            Destroy(gameObject);
        }
    }

    //Jesus Christ 
    // Update is called once per frame
   void  OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().DestroyMe(transform.position);
            Destroy(other.gameObject);
            
            Destroy(gameObject);
        }
    }
}
