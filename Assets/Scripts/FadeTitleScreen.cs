using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTitleScreen : MonoBehaviour
{
    private float fadeOutMoment = 2f;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time>fadeOutMoment)
	    {
	        Destroy(gameObject);
	    }
	}
}
