using System;
using UnityEngine;
using UnityEngine.UI;

namespace AssemblyCSharp
{
	public class PlayerHealthUI: MonoBehaviour
	{

		private HealthSystem healthSys;
		private Image img;

		void Start(){
			healthSys = GameObject.FindObjectOfType<Player>().HealthSystem;

			img = gameObject.GetComponent<Image> ();
		}

		void Update(){

			float percentage = healthSys.health / healthSys.maxHealth;

			img.fillAmount = percentage;
			if (percentage <= 0.25) {
				img.color = new Color (100, 0, 0);
			} else {
				img.color = new Color (0, 100, 0);
			}

		}
	}
}

