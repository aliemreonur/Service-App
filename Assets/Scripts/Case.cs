using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
//to make it visible in the inspector
public class Case
{
    public string caseID;
    public string name;
    public string date;
    public string location;
    public string locationNotes;
    public RawImage photoTaken;
    public string photoNotes;
}
