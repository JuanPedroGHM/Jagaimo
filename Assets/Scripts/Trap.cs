using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	// Use this for initialization
	public Player player;
	public bool active;
	void Start () {
		player = FindObjectOfType<Player> ();
		active = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		
		if (col.gameObject.name == "Character" && active) {
			Debug.Log ("Triggerd Trap");
			SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer> ();
			sprite.color = new Color (0, 0, 0);


			player.HealthSystem.Damage(10);
			active = false;

		}
	}
}
