using UnityEngine;

namespace Assets.Scripts
{
    public class WalkDirection : MonoBehaviour
    {
        private int _moveDirection=0;
        
        private float speedx;
        private float speedy;
        private Animator myAnimator;
        private bool facingRight = false;
		private Sword sword;
		
		private bool canMove = true;
        // Use this for initialization
        void Start ()
        {

            myAnimator = gameObject.GetComponent<Animator>();
			sword = FindObjectOfType<Sword> ();
        }
	
        // Update is called once per frame
        void Update ()
        {
	

            float inputx = Input.GetAxis("Horizontal");
			float inputy  = Input.GetAxis("Vertical");
			Vector2 speed = new Vector2 (inputx, inputy);
			//nur eine Änderung wenn in eine Andere Richtung gedrückt wird
			if (speed.magnitude > 0.6) {
				speedx = inputx;
				speedy = inputy;
			}
		


            if (speedx > 0)
            {
                if (!facingRight)
                    Flip();
            }
            else
            {
                if (facingRight)
                    Flip();
            }




        }

        private void FixedUpdate()
        {
            
            myAnimator.SetFloat("speedX", speedx);
            myAnimator.SetFloat("speedY", speedy);
        }
        void Flip()
        {
            // Switch the way the player is labelled as facing
            facingRight = !facingRight;

            // Multiply the player's x local scale by -1
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

			//Transform sword to flip with the character.
//			Vector3 swordScale = sword.transform.localScale;
//			swordScale.x *= -1;
//			sword.transform.localScale = swordScale;
        }
    }
}
