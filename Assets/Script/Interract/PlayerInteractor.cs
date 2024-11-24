using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractor : MonoBehaviour
{
    public CharacterBase Player;
    public Vector2 interactArea;
    public Vector2 centerOffSet;
    public float interactDistance;
    public Vector2 interactDir;
    public bool canInteract;
    public LayerMask NpcLayer;
    private void Update()
    {
        interactDir = Player.direction;
    }
    private void FixedUpdate()
    {
         canInteract = Physics2D.BoxCast(transform.position+(Vector3)centerOffSet, interactArea,0,interactDir,interactDistance, NpcLayer);
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position+(Vector3)centerOffSet,interactDistance);
    }
}
