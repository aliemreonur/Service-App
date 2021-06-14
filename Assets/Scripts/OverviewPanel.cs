using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverviewPanel : MonoBehaviour, IPanel
{
    //this panel acts as a summary data gathered in previous panels. 
    //to change the panels during runtime, we need to reference them from the inspector.


    public Text caseNumberTitle;
    public Text nameTitle;
    public Text dateTitle;
    public Text locationTitle;
    public Text locationNotes;
    public RawImage photoTaken;
    public Text photoNotes;

    private void OnEnable()
    {
        caseNumberTitle.text = "CASE NUMBER " + UIManager.Instance.activeCase.caseID;
    }

    public void ProcessInfo()
    {

    }
}
