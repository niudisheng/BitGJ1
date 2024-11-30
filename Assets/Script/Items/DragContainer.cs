using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragContainer : MonoBehaviour
{
    public Vector3 endPos;
    public Vector3 startPos;
    private DragItem dragItem;
    public Vector3 RotateVector;
    
    [ContextMenu("Record Drag")]
    public void RecordDrag()
    {
        dragItem = GetComponentInChildren<DragItem>();
        endPos = transform.position; 
        startPos = dragItem.gameObject.transform.position;
        RotateVector = transform.rotation.eulerAngles;
        
    }
}
