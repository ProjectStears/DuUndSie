using UnityEngine;
using System.Collections.Generic;

public class PathMovement : MonoBehaviour {

    private GameObject pathRoot;
    private List<Transform> pathElements = new List<Transform>();

    private int currentPathTarget;
    private float currentTravelTime;

    private float travelTime;

	// Use this for initialization
	void Start () {
        pathRoot = GameObject.FindGameObjectWithTag("Path");

	    for (int i = 0; i < pathRoot.transform.childCount; i++)
	    {
	        Transform ip = pathRoot.transform.GetChild(i);
            if (ip.tag == "PathMarker")
                pathElements.Add(ip);
	    }

	    this.transform.position = pathElements[currentPathTarget].position;
	    this.transform.rotation = pathElements[currentPathTarget].rotation;

        travelTime = Vector3.Distance(pathElements[currentPathTarget].position, pathElements[currentPathTarget + 1].position) / Config.TravelTimePerUnit * pathElements[currentPathTarget + 1].GetComponent<PathMarkerData>().speedToMarkerModifier;

        currentPathTarget++;
	}
	
	// Update is called once per frame
	void Update () {

	    if (currentPathTarget < pathElements.Count)
	    {
	        Transform startPathTarget = pathElements[currentPathTarget - 1];
	        Transform endPathTarget = pathElements[currentPathTarget];

            currentTravelTime += Time.deltaTime;
            if (currentTravelTime > travelTime)
            {
                currentTravelTime = travelTime;
            }

            float tp = currentTravelTime / travelTime;
            float tr = tp * tp * tp * (tp * (6f * tp - 15f) + 10f); //Smoothstep


            this.transform.position = Vector3.Lerp(startPathTarget.position, endPathTarget.position, tp);
            this.transform.rotation = Quaternion.Lerp(startPathTarget.rotation, endPathTarget.rotation, tr);

            if (tp >= 1 && pathElements.Count > currentPathTarget +1)
            {
                travelTime = Vector3.Distance(pathElements[currentPathTarget].position, pathElements[currentPathTarget + 1].position) / Config.TravelTimePerUnit * pathElements[currentPathTarget + 1].GetComponent<PathMarkerData>().speedToMarkerModifier;
                currentPathTarget++;
                currentTravelTime = 0;
            }
        }
	    else
	    {
	        Debug.LogWarning("No more path!");
	    }

	}
}
