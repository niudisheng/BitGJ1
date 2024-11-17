using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Attack : MonoBehaviour
{
    public float damage;
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<Character>()?.TakeDamage(this);
    }
}
