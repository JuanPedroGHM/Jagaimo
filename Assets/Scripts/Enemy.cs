using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [NonSerialized]
    public Player Player;
    public HealthSystem HealthSystem;
    private MoveTowards _moveTowards;


	// Use this for initialization
	void Start ()
	{
	    Player = FindObjectOfType<Player>();
	    _moveTowards = GetComponent<MoveTowards>();
	    _moveTowards.Target = Player.transform;
	}
}