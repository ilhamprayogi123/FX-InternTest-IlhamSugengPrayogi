using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectButton : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent();
    public GameObject button;
    //public GameObject cam;

    //public Transform lookAtMe;

    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //cam = GameObject.FindGameObjectWithTag("MainCamera");

        //lookAtMe = cam.transform.Find("MainCamera").gameObject;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                unityEvent.Invoke();
            }
        }
    }
}
