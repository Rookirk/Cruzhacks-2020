using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
//ARSubsystems

public class ARTapToPlaceObjects : MonoBehaviour
{
	public GameObject objectToPlace;
	public GameObject placementIndicator;

	private ARSessionOrigin arOrigin;
	private GameObject distanceIndicator;
	private Text textDisplay;

	private Pose placementPose;
	private bool placementPoseIsValid = false;

	private Pose firstPosition;
	private Pose secondPosition;

    // Start is called before the first frame update
    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        distanceIndicator = GameObject.Find("DistanceIndicator");
        textDisplay = distanceIndicator.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if(placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
        	PlaceObject();
        }
    }

    private void PlaceObject(){
    	Instantiate(objectToPlace, placementPose.position, placementPose.rotation);

    	if(firstPosition == null){
    		firstPosition = placementPose;
    	}
    	else{
    		secondPosition = placementPose;
    		textDisplay.text = Vector3.Distance(firstPosition.position, secondPosition.position).ToString();
    	}
    }

    private void UpdatePlacementPose(){
    	var center = new Vector3(0.5f, 0.5f);
    	var screenCenter = Camera.main.ViewportToScreenPoint(center);
    	var hits = new List<ARRaycastHit>();
    	var arOriginRaycast = arOrigin.GetComponent<ARRaycastManager>();
    	arOriginRaycast.Raycast(screenCenter, hits, TrackableType.Planes);

    	placementPoseIsValid = hits.Count > 0;
    	if(placementPoseIsValid){
    		placementPose = hits[0].pose;

    		var cameraForward = Camera.main.transform.forward;
    		var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
    		placementPose.rotation = Quaternion.LookRotation(cameraBearing);
    	}
    }

    private void UpdatePlacementIndicator(){
    	if(placementPoseIsValid){
    		placementIndicator.SetActive(true);
    		placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
    	}
    	else{
    		placementIndicator.SetActive(false);
    	}
    }
}
