using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabUITween : MonoBehaviour
{
    [SerializeField]
    GameObject animateButton, resetButton, panelButton;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(animateButton, new Vector3(1.0f, 1.0f, 1.0f), 1).setEase(LeanTweenType.easeOutBounce);
        LeanTween.scale(resetButton, new Vector3(1.0f, 1.0f, 1.0f), 1).setEase(LeanTweenType.easeOutBounce);
        LeanTween.scale(panelButton, new Vector3(1.0f, 1.0f, 1.0f), 1).setEase(LeanTweenType.easeOutBounce);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
