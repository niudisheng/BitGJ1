using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public List<GameObject> interactionGameobject = new List<GameObject>();
    Dictionary<string, GameObject> imageDir = new Dictionary<string, GameObject>();
    private GameObject startInteraction;
    public string startName;

    private void Awake()
    {
        AddInteraction();
        TrunInteractionOn(startName);
    }
    public void TrunInteractionOn(string name)
    {
        startInteraction = imageDir[name];
        startInteraction.SetActive(true);
    }
    public void AddInteraction()
    {
        foreach (GameObject gameObject in interactionGameobject)
        {
            imageDir.Add(gameObject.name, gameObject);
        }
    }
}
