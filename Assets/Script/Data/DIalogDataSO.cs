using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data/DialogDataSO" , menuName = "Data/DialogData")]
public class DIalogDataSO : ScriptableObject
{
    public TextAsset TextAsset;
    public string thisNPC;
    public string otherNPC;
    public bool isPause;
}
