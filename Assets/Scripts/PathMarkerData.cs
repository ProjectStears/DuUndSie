using UnityEngine;
using System.Collections;

public class PathMarkerData : MonoBehaviour
{
    public float speedToMarkerModifier;


    void Start()
    {
        if (Config.DebugShowPathMarkers)
        {
            var go = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere), this.transform) as GameObject;
            go.transform.position = this.transform.position;
        }
    }
}
