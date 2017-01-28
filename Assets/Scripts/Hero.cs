using UnityEditor.Animations;
using UnityEngine;

public class Hero :ScriptableObject
{
    public Sprite CharacterSprite;
    public AnimatorController CharacterAnimator;
    public float Walkspeed;
    public float MaxHealth;
}