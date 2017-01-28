using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class FlyingSword : MonoBehaviour {

    [NonSerialized]
    public Transform Target;
    [NonSerialized]
    public PlayerHealthSystem PlayerHealthSystem;


    private MoveTowards _moveTowards;

    // Use this for initialization
    void Start ()
    {
        Target = new GameObject().transform;
        _moveTowards = GetComponent<MoveTowards>();
        _moveTowards.Target = Target;
        FindObjectOfType<CameraController>().player = gameObject;
    }
	
    // Update is called once per frame
	void Update () {
	    if (Vector3.Distance(transform.position, Target.position) <= 1)
	    {

	        PlayerHealthSystem.Revive();
	        Destroy(this);
	    }
	}

}
