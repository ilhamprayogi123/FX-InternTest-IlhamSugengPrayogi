using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriviaPanelScript : MonoBehaviour
{
    PrefabButton prefabUiButton;
    GameObject panelTrv;
    GameObject panelTrivia;

    GameObject panelSub;

    bool trivia = false;

    // Start is called before the first frame update
    void Start()
    {
        prefabUiButton = GetComponent<PrefabButton>();
        Debug.Log("iso kan ya ?");
        //panelTrv = GameObject.FindGameObjectWithTag("PanelInfo");
        //panelTrivia = prefabUiButton.panel;
        panelTrivia = GameObject.Find("WorldCanvas");
        panelSub = GameObject.Find("PanelTrivia");

        // panelSub.SetActive(false);

        Debug.Log("Ini Bisa");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (panelTrivia != null && trivia == true)
        {
            
            if (trivia == true)
            {
                panelSub.SetActive(true);
            }
            else
            {
                panelSub.SetActive(false);
            }
            
            panelSub.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            panelSub.SetActive(false);
        }
        */
    }

    private void OnMouseDown()
    {
        setTriviaPanel();
    }

    public void setTriviaPanel()
    {
        Debug.Log("Gak Iso A ");
        // panelTrivia.SetActive(true);
        // prefabUiButton.PanelButton();
        // panelTrv.gameObject.SetActive(true);
        // panelTrivia.gameObject.SetActive(true);
        // prefabUiButton.triviaOn = true;
        AudioController.Play("PanelSFX");
        LeanTween.scale(panelSub, new Vector3(1.0f, 1.0f, 1.0f), 1).setEase(LeanTweenType.easeOutBounce);
        Debug.Log("Inikan");
    }

    public void ClosePanel()
    {
        AudioController.Play("BackSFX");
        LeanTween.scale(panelSub, new Vector3(0.0f, 0.0f, 0.0f), 1).setEase(LeanTweenType.easeInBounce);
    }
}
