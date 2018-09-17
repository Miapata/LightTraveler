using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public void Start()
    {

    }
    public enum States
    {
        Patrolling,
        Attack
    }

    public States enemyState;

    public AudioClip destroySound;
    // Use this for initialization
    public void DestroyMe(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(destroySound, position);
    }

    public void StateCheck()
    {
        switch (enemyState)
        {

            case States.Patrolling:
                break;

            case States.Attack:
                break;

        }
    }


}
