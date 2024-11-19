using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public float invulnerableDuration;
    public float invulnerableCounter;
    public bool invulnerable;
    public GameObject myself;
    public Play2DInput playertest;
    public Player player;
    public UnityEvent Ondie;
    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(Attack attacker)
    {
        if (invulnerable)
            return;
        if (currentHealth - attacker.damage > 0)
        {
            currentHealth -= attacker.damage;
            Triggerinvulnerable();
            
        }
        else
        {
            currentHealth = 0;
            if(myself.CompareTag("gold"))
            {
                Ondie?.Invoke();
            }
            if(myself.CompareTag("Player"))
            {
                playertest.Disable();
            }
        }
    }
    public void TakeDamage(RangedAttack attacker)
    {
        if (invulnerable)
            return;
        if(player!=null)
        {
            if (!player.isDefend)
            {
                if (currentHealth - attacker.damage > 0)
                {
                    currentHealth -= attacker.damage;
                    Triggerinvulnerable();

                }
                else
                {
                    currentHealth = 0;
                    if (myself.CompareTag("gold"))
                    {
                        Ondie?.Invoke();
                    }
                    if (myself.CompareTag("Player"))
                    {
                        playertest.Disable();
                    }
                }
            }
            else
            {
                if (currentHealth - attacker.damage/2 > 0)
                {
                    currentHealth -= attacker.damage/2;
                    Triggerinvulnerable();

                }
                else
                {
                    currentHealth = 0;
                    if (myself.CompareTag("gold"))
                    {
                        Ondie?.Invoke();
                    }
                    if (myself.CompareTag("Player"))
                    {
                        playertest.Disable();
                    }
                }
            }
        }
        else
        {
            if (currentHealth - attacker.damage > 0)
            {
                currentHealth -= attacker.damage;
                Triggerinvulnerable();

            }
            else
            {
                currentHealth = 0;
                if (myself.CompareTag("gold"))
                {
                    Ondie?.Invoke();
                }
                if (myself.CompareTag("Player"))
                {
                    playertest.Disable();
                }
            }
        }

    }
    private void Update()
    {
        if (invulnerable)
        {
            invulnerableCounter -= Time.deltaTime;
        }
        if (invulnerableCounter <= 0)
        {
            invulnerable = false;
        }
    }
    private void Triggerinvulnerable()
    {
        if (!invulnerable)
        {
            invulnerable = true;
            invulnerableCounter = invulnerableDuration;
        }
    }
    public void DestroyMyself()
    {
          Destroy(this);
    }
    public void EnemyTlak()
    {
        invulnerableCounter = 1;
        invulnerable = true;
    }
}
