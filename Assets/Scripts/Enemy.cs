using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class Enemy : MonoBehaviour
{
    [NonSerialized]
    public Player Player;
	[NonSerialized]
    public HealthSystem HealthSys;
    protected MoveTowards _moveTowards;


	// Use this for initialization
	protected virtual void Start ()
	{
		HealthSys = GetComponent<HealthSystem> ();
	    Player = FindObjectOfType<Player>();
	    _moveTowards = GetComponent<MoveTowards>();
	    _moveTowards.Target = Player.transform;
	}
}