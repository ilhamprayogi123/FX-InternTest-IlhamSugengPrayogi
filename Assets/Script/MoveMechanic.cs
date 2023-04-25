using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;
using UnityEngine.XR.ARSubsystems;

public class MoveMechanic : MonoBehaviour
{
    private Vector3 oriScale;
    private Quaternion originalPose;
    private Vector3 originalPosition;
    private float originalDistance;

    private Vector2 lastPos;
    public float rotationSpeed = 1;
    ARPlacement arPlace;
    private Touch touchZero, touchOne;

    // Start is called before the first frame update
    void Start()
    {
        //originalPose = arPlace.PlacementPose.rotation;
        //originalPosition = arPlace.PlacementPose.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            touchZero = Input.GetTouch(0);

            switch (touchZero.phase)
            {
                case TouchPhase.Began:
                    lastPos = touchZero.position;
                    break;
                case TouchPhase.Moved:
                    var rotationX = (touchZero.position.x - lastPos.x * rotationSpeed);
                    transform.Rotate(Vector3.up, -rotationX, Space.World);

                    lastPos = touchZero.position;
                    break;
            }
        }

        PinchToScale();
    }

    void PinchToScale()
    {
        if (Input.touchCount == 2)
        {
            touchZero = Input.GetTouch(0);
            touchOne = Input.GetTouch(1);

            if (touchZero.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled || touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled)
            {
                return;
            }

            if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
            {
                originalDistance = Vector2.Distance(touchZero.position, touchOne.position);
                // oriScale = arPlace.originalScale;
            }
            else
            {
                var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

                if (Mathf.Approximately(originalDistance, 0))
                {
                    return;
                }

                var factor = currentDistance / originalDistance;
                this.gameObject.transform.localScale = oriScale * factor;
            }

        }
    }

    public void resetPos()
    {
        /*
        this.gameObject.transform.position = new Vector3(0, 0, 0);
        this.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        */
        AudioController.Play("ResetSFX");
        this.gameObject.transform.position = originalPosition;
        this.gameObject.transform.rotation = originalPose;
        this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
