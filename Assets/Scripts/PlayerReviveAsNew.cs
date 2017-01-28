using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReviveAsNew : MonoBehaviour
{
    public GameObject Player;

    public List<Hero> Heroes;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.R))
	    {
	        Revive(Heroes[1], transform);
	    }
	}

    public void Revive(Hero newHero, Transform spawnPosition)
    {
        Debug.Log(newHero.ToString());
        Player.transform.position = spawnPosition.position;
        Player.GetComponent<Movement>().speed = newHero.Walkspeed;
        Player.GetComponent<HealthSystem>().maxHealth = newHero.MaxHealth;
        Player.GetComponent<HealthSystem>().SetMaxHealth();

        Player.GetComponent<SpriteRenderer>().sprite = newHero.CharacterSprite;
        Player.GetComponent<Animator>().runtimeAnimatorController = newHero.CharacterAnimator;
    }
}