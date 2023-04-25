using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotorActivate : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RotActivate()
    {
        animator.SetBool("IsRotActive", true);
    }

    public void RotorAct()
    {
        animator.SetBool("RotorActivate", true);
    }

    public void RudActivate()
    {
        animator.SetBool("IsRudActivate", true);
    }

    public void FlyActivate()
    {
        animator.SetBool("IsFlying", true);
    }

    public void FlyHeli()
    {
        AudioController.Play("AnimateSFX");
        animator.SetBool("IsFly", true);
    }

    public void RotorON()
    {
        animator.SetBool("IsRotorOn", true);
    }
}
