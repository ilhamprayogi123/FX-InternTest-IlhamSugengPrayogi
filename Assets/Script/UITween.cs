using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITween : MonoBehaviour
{
    [SerializeField]

    GameObject gameTitle, startButton, exitButton;

    public float IntroMenuSFXTimer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayIntroMenu());
        LeanTween.scale(gameTitle, new Vector3(1f, 1f, 1f), 4f).setDelay(.25f).setEase(LeanTweenType.easeInOutElastic);
        LeanTween.scale(startButton, new Vector3(1f, 1f, 1f), 4f).setDelay(.5f).setEase(LeanTweenType.easeInOutElastic);
        LeanTween.scale(exitButton, new Vector3(1f, 1f, 1f), 4f).setDelay(.5f).setEase(LeanTweenType.easeInOutElastic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayIntroMenu()
    {
        yield return new WaitForSeconds(IntroMenuSFXTimer);
        AudioController.Play("MenuIntroSFX");
    }
}
