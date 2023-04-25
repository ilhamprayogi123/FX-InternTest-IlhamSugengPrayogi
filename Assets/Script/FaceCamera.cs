using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    // public Transform lookAtMe;

    // private Transform localTransform;

    // Start is called before the first frame update
    void Start()
    {
        // localTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (lookAtMe)
        {
            localTransform.LookAt(2 * localTransform.position - lookAtMe.position);
        }
        */

        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }
}
