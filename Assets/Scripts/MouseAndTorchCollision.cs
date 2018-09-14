using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAndTorchCollision : MonoBehaviour
{

    public HandFollow handFollow;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != null)
        {
            print(other.gameObject);
            handFollow.outsideDeadzone = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject != null)
        {
            print(other.gameObject);
            handFollow.outsideDeadzone = true;
        }

    }
}
