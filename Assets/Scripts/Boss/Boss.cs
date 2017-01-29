using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Boss : Enemy
{
    public Hero fathero;

    // Use this for initialization
	protected override void Start()
	{
        base.Start();
	    FindObjectOfType<SoundManager>().PlaySound("Boss_Spawn");
	    _moveTowards.Walkspeed = fathero.Walkspeed;
	}
}