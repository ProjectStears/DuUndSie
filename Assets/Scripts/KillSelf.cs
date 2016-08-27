using UnityEngine;
using System.Collections;

public class KillSelf : MonoBehaviour
{

    public float timer;
    private float curTimer;

	// Use this for initialization
	void Start () {

	    if (timer != 0)
	    {
	        curTimer = timer;
	    }
	    else
	    {
	        curTimer = 5;
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timer -= Time.deltaTime;
        if (timer < 0)
            Destroy(this.gameObject);
	}
}
