using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : ItemToDisplay
{
    public override void UseItem()
    {
        GameObject player = GameObject.FindWithTag("Player");
        foreach (Transform child in player.transform)
        {
            if (child.name == "Hat")
            {
                player.GetComponent<Animator>().Play("Idle");
                child.gameObject.SetActive(true); 
            }
        }
    }
}
