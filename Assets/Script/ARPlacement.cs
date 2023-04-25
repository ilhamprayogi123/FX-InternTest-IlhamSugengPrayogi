using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARPlacement : MonoBehaviour
{
    public GameObject arObjectToSpawn;
    //public GameObject placementIndicator;
    private GameObject spawnedObject;
    private Vector3 originalPlace;
    private Vector2 touchPosition;
    public Quaternion originalRotation;
    float currentDistance;
    private float oriDistance;
    private Vector3 oriScale;
    private Vector2 oriPosition;
    // private Touch touchZero, touchOne;
    private Vector2 touchZero, touchOne;
    private Touch zeroTouch, oneTouch;
    private Quaternion oriRotation;
    private Quaternion rotateY;
    private float rotateSpeed = 0.1f;

    bool object_Spawned;
    bool firstPinch = true;

    // public Vector3 originalScale;
    // public Pose PlacementPose;
    private ARRaycastManager ArRaycastManager;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // private bool placementPoseIsValid = false;

    private void Awake()
    {
        ArRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        // object_Spawned = false;
        // ArRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;
        if (Input.touchCount > 0)
        {
            RotateSwipe();
        }

        // if(ArRaycastManager.Raycast)

        TouchSpawn();
        PinchScale();
        /*
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
        }
        else
        {
            // spawnedObject.transform.position = PlacementPose.position;
        }
        */
        // UpdatePlacementPose();
        // UpdatePlacementIndicator();
    }
    
    void RotateSwipe()
    {
        zeroTouch = Input.GetTouch(0);

        if (zeroTouch.phase == TouchPhase.Moved)
        {
            rotateY = Quaternion.Euler(0f, -zeroTouch.deltaPosition.x * rotateSpeed, 0f);

            spawnedObject.transform.rotation = rotateY * spawnedObject.transform.rotation;
        }
    }
    
    void TouchSpawn()
    {
        
        if (Input.touchCount > 0 && !object_Spawned)
        {
            if (ArRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitpose = hits[0].pose;
                spawnedObject = Instantiate(arObjectToSpawn, hitpose.position, hitpose.rotation);
                oriPosition = hitpose.position;
                oriRotation = hitpose.rotation;
                object_Spawned = true;
            }
        }
        
        /*
        if (ArRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPos = hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(arObjectToSpawn, hitPos.position, hitPos.rotation);
                //spawnedObject.transform.localScale = new Vector3(0, 0, 0);
                oriPosition = hitPos.position;
                oriRotation = hitPos.rotation;
                //LeanTween.scale(spawnedObject, new Vector3(0.025f, 0.025f, 0.025f), 0.5f).setEase(LeanTweenType.easeOutBounce);
            }
            else
            {
                spawnedObject.transform.position = hitPos.position;
            }
        }
       */
    }

    void PinchScale()
    {
        /*
        if (Input.touchCount == 2 && object_Spawned)
        {
            touchZero = Input.GetTouch(0).position;
            touchOne = Input.GetTouch(1).position;
            currentDistance = touchOne.magnitude - touchZero.magnitude;
            if (firstPinch)
            {
                oriDistance = currentDistance;
                firstPinch = false;
            }
        }
        if (currentDistance != oriDistance)
        {
            Vector3 scaleValue = spawnedObject.transform.localScale * (currentDistance / oriDistance);
            spawnedObject.transform.localScale = scaleValue;
            oriDistance = currentDistance;
        }
        */
        
        if (Input.touchCount == 2)
        {
            zeroTouch = Input.GetTouch(0);
            oneTouch = Input.GetTouch(1);

            if (zeroTouch.phase == TouchPhase.Ended || zeroTouch.phase == TouchPhase.Canceled || 
                oneTouch.phase == TouchPhase.Ended || oneTouch.phase == TouchPhase.Canceled)
            {
                return;
            }

            if (zeroTouch.phase == TouchPhase.Began || oneTouch.phase == TouchPhase.Began)
            {
                oriDistance = Vector2.Distance(zeroTouch.position, oneTouch.position);
                oriScale = spawnedObject.transform.localScale;
            }
            else
            {
                var currentDistance = Vector2.Distance(zeroTouch.position, oneTouch.position);
                if (Mathf.Approximately(oriDistance, 0))
                {
                    return;
                }

                var factor = currentDistance / oriDistance;
                spawnedObject.transform.localScale = oriScale * factor;
            }
        }
        
    }
    /*
    void UpdatePlacementIndicator()
    {
        if (spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }
    */
    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        ArRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        // placementPoseIsValid = hits.Count > 0;
        
        /*
        if (placementPoseIsValid)
        {
            // PlacementPose = hits[0].pose;
        }
        */
    }

    void ARPlaceObject()
    {
        Debug.Log("Bisa nggak sih");
        // UiButtonActive = true;
        // spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
        spawnedObject.transform.localScale = new Vector3(0, 0, 0);
        // originalPlace = PlacementPose.position;
        // originalRotation = PlacementPose.rotation;
        LeanTween.scale(spawnedObject, new Vector3(0.01f, 0.01f, 0.01f), 1).setEase(LeanTweenType.easeOutBounce);
        // animator.SetBool("IsSpawn", true);
    }

    public void ResetPlaceFunc()
    {
        /*
        resetPlace = true;
        resetPose = true;
        resetScale = true;
        */
        Debug.Log("Bisa lah...");

        /*
        spawnedObject.transform.position = originalPlace;
        spawnedObject.transform.rotation = originalRotation;
        */
        this.gameObject.transform.localScale = new Vector3(0, 0, 0);
        this.gameObject.transform.position = oriPosition;
        this.gameObject.transform.rotation = oriRotation;
    }

    public void SpawnObject()
    {
        // spawnedObject = Instantiate(arObjectToSpawn) as GameObject;
        Debug.Log("Bisa lah...");
        // UiButtonActive = true;
        // spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
        spawnedObject.transform.localScale = new Vector3(0, 0, 0);
        // originalPlace = PlacementPose.position;
        // originalRotation = PlacementPose.rotation;
        Debug.Log(originalPlace);
        LeanTween.scale(spawnedObject, new Vector3(0.025f, 0.025f, 0.025f), 3).setEase(LeanTweenType.easeOutBounce);
        // animator.SetBool("IsSpawn", true);
    }
}
