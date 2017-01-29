using System;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts
{
    public class Hero :ScriptableObject
    {
        public String HeroName;
        public Sprite CharacterSprite;
        public AnimatorController CharacterAnimator;
        public float Walkspeed;
        public float MaxHealth;

        public override string ToString()
        {
            return HeroName + " Walkspeed: " + Walkspeed + " MaxHealth: " + MaxHealth;
        }
    }
}