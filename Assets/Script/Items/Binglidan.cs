using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Binglidan : MonoBehaviour
{
    public GameObject son;
    public ItemChangeSpriteWithoutPlayer ItemChangeSpriteWithoutPlayer;
    public SpriteRenderer ItemRenderer;
    private void Update()
    {
        if (ItemChangeSpriteWithoutPlayer.sprites[2] == ItemRenderer.sprite)
        {
            son.SetActive(true);
            Destroy(gameObject);
        }
    }
}
