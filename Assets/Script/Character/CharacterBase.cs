using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public Animator anim;
    public int maxHealth;
    private int currentHealth;
    public Rigidbody2D rb;
    public float height;
    public PlayerStateMachine stateMachine;
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void heal(int healAmount)
    {
        currentHealth += healAmount;
    }
}
