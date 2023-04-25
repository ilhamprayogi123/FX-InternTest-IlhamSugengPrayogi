using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabButton : MonoBehaviour
{
    public GameObject panel;

    public GameObject subPanel;

    public bool triviaOn = false;

    // Start is called before the first frame update
    void Start()
    {
        // panel = GameObject.Find("WorldCanvas");
        subPanel.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (triviaOn == true)
        {
            Debug.Log("Muncul Dong");
            panel.SetActive(true);
        }
        */
    }

    public void PanelButton()
    {
        Debug.Log("Apakah Bisa");
        AudioController.Play("ResetSFX");
        panel.SetActive(true);
    }

    public void ClosePanelTrivia()
    {
        AudioController.Play("BackSFX");
        subPanel.transform.localScale = new Vector3(0, 0, 0);
    }
}
