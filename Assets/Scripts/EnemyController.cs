using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public AudioClip destroySound;
	// Use this for initialization
    public void DestroyMe(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(destroySound,position);
    }
}
