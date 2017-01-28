using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class PlayerHealthSystem : HealthSystem
    {
        public FlyingSword FlyingSword;
        private Corpse corpseToRevive;

        private bool dead;

        protected override void Die()
        {
            if (dead)
            {
                return;
            }
            dead = true;
            gameObject.SetActive(false);
            corpseToRevive = FindObjectOfType<Corpse>();
            if (corpseToRevive==null)
            {
               SceneManager.LoadScene(0);
               return;
            }

            var flyingSword = Instantiate(FlyingSword,transform.position,transform.rotation);
            flyingSword.PlayerHealthSystem = this;
            Debug.Log(corpseToRevive);
            flyingSword.Target = corpseToRevive.transform;
        }




        public void Revive()
        {
            if (corpseToRevive==null) return;
            FindObjectOfType<CameraController>().player = gameObject;

            transform.position = corpseToRevive.transform.position;
            SetNewHeroVariables();


            dead = false;
            gameObject.SetActive(true);

            var corpses = FindObjectsOfType<Corpse>();
            foreach (var corpse in corpses)
            {
                Destroy(corpse.gameObject);
            }
        }

        private void SetNewHeroVariables()
        {
            var NewHero = corpseToRevive.Hero;
            Debug.Log(NewHero.ToString());
            GetComponent<Movement>().speed = NewHero.Walkspeed;
            GetComponent<HealthSystem>().maxHealth = NewHero.MaxHealth;
            GetComponent<HealthSystem>().SetMaxHealth();

            GetComponent<SpriteRenderer>().sprite = NewHero.CharacterSprite;
            GetComponent<Animator>().runtimeAnimatorController = NewHero.CharacterAnimator;
        }
    }
}