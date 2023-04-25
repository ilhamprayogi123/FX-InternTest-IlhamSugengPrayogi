using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    FadeInOutScript fadeInOut;

    // Start is called before the first frame update
    void Start()
    {
        fadeInOut = FindObjectOfType<FadeInOutScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ChangeScene()
    {
        fadeInOut.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("AR Scene");
    }

    public IEnumerator BackScene()
    {
        fadeInOut.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Start Scene");
    }

    public void ARButton()
    {
        AudioController.Play("StartSFX");
        StartCoroutine(ChangeScene());
    }

    public void BackButton()
    {
        AudioController.Play("BackSFX");
        StartCoroutine(BackScene());
    }

    public void Exit()
    {
        
        AudioController.Play("BackSFX");
        fadeInOut.FadeIn();
        Application.Quit();
    }
}
