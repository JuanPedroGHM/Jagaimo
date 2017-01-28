using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBoss : Enemy
{
    public Hero fathero;

    // Use this for initialization
	protected override void Start()
	{
        base.Start();
	    HealthSys.maxHealth = fathero.MaxHealth;
	    _moveTowards.Walkspeed = fathero.Walkspeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}