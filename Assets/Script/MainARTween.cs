using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainARTween : MonoBehaviour
{
    [SerializeField]
    GameObject exitButton;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(exitButton, new Vector3(1.0f, 1.0f, 1.0f), 1).setEase(LeanTweenType.easeOutBounce);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
