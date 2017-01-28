using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSword : MonoBehaviour {

    [NonSerialized]
    public Player Player;
    private MoveTowards _moveTowards;
    // Use this for initialization
    void Start ()
    {
        Player = FindObjectOfType<Player>();
        _moveTowards = GetComponent<MoveTowards>();
        _moveTowards.Target = Player.transform;
    }
	
    // Update is called once per frame
	void Update () {
		
	}
}
