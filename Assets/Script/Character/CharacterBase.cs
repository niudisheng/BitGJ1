using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void heal(int healAmount)
    {
        currentHealth += healAmount;
    }
}
