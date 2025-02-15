using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coat : ItemToDisplay
{
    public override void UseItem()
    {
        GameObject player = GameObject.FindWithTag("Player");
        foreach (Transform child in player.transform)
        {
            if (child.name == "Coat")
            {
                player.GetComponent<Animator>().Play("Idle");
                child.gameObject.SetActive(true); 
            }
        }
    }
}
