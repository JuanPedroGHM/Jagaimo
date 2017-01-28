using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReviveAsNew : MonoBehaviour
{
    public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Revive(Hero newHero)
    {
        Player.GetComponent<Movement>().speed = newHero.Walkspeed;
        Player.GetComponent<HealthSystem>().maxHealth = newHero.MaxHealth;
        Player.GetComponent<HealthSystem>().SetToMaxHealth();
    }
}