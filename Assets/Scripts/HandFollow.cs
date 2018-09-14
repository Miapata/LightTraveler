using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFollow : MonoBehaviour {

    // Point you want to have sword rotate around
    public Transform hand;
    // how far you want the sword to be from point
    public float armLength = 1f;
    public bool outsideDeadzone;
    private Vector3 mousePosition;
    private Vector3 newPosition;
    void Start()
    {
        
        // if the sword is child object, this is the transform of the character (or hand)
        hand = transform.parent.transform;
    }
    void Update()
    {
        if (outsideDeadzone)
        {
            // Get the direction between the hand and mouse (aka the target position)
            Vector3 handToMouseDir =
                Camera.main.ScreenToWorldPoint(Input.mousePosition) - hand.position;
            handToMouseDir.z = 0; // zero z axis since we are using 2d
            // we normalize the new direction so you can make it the arm's length
            // then we add it to the hand's position
            transform.position = hand.position + (armLength * handToMouseDir.normalized);
        }
        else
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition = new Vector3(mousePosition.x,mousePosition.y,0);
            transform.position = newPosition;
        }
    }
}
