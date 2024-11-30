using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ComputerItem : MonoBehaviour
{
    public GameObject son;
    public ItemChangeSpriteWithoutPlayer ItemChangeSpriteWithoutPlayer;
    public SpriteRenderer SpriteRenderer;
    private void Update()
    {
        if (ItemChangeSpriteWithoutPlayer.sprites[2]==SpriteRenderer.sprite)
        {
            son.SetActive(true);
        }
    }

}
