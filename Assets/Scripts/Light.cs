using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using JetBrains.Annotations;
using UnityEngine;

public class Light : MonoBehaviour {
    public UnityEngine.Light lightComponent;
    public float fadeSpeed;
    float velocity;
  
	
	// Update is called once per frame
	void CustomUpdate () {
	    if (lightComponent.intensity > 0)
	    {
	        lightComponent.intensity = Mathf.SmoothDamp(lightComponent.intensity, 0, ref velocity, fadeSpeed);
	    }
	}

    void Fade()
    {
        Destroy(gameObject,10);
        InvokeRepeating("CustomUpdate", 0, 0.02f);
    }
}
