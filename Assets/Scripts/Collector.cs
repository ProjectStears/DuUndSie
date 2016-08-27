using UnityEngine;
using System.Collections;
using System.Threading;

public class Collector : MonoBehaviour
{
    private float fuel;
    private float oxygen;
    private float energy;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            Collectable col = other.GetComponent<Collectable>();

            fuel   += col.Fuel;
            oxygen += col.Oxygen;
            energy += col.Energy;

            col.Kill();
        }
    }
}
