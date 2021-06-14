using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UI Manager instance is null");
            }
            return _instance;
        }
    }

    public Case activeCase;
    public ClientInfoPanel clientInfoPanel;
    public GameObject borderPanel;

    private void Awake()
    {
        _instance = this;
    }

    public void CreateCase()
    {
        activeCase = new Case();
        int randomCaseID = Random.Range(0, 1000);
        activeCase.caseID = " " + randomCaseID;

        clientInfoPanel.gameObject.SetActive(true);
        borderPanel.SetActive(true);
    }

}
