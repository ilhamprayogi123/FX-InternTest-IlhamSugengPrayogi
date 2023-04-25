using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    FadeInOutScript fade;

    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<FadeInOutScript>();

        fade.FadeOut();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
