using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public float oxygen;
    public float fuel;
    public float energy;

    public float oxygenReduction;
    public float fuelReduction;
    public float energyReduction;

    private Slider OxygenSlider;
    private Slider FuelSlider;
    private Slider EnergySlider;

    private PathMovement pathMovement;
    public GameObject loosetext;
    public GameObject wintext;

    private bool gogogo;

    // Use this for initialization
    void Start()
    {
        gogogo = true;

        OxygenSlider = GameObject.Find("O2Slider").GetComponent<Slider>();
        FuelSlider = GameObject.Find("FuelSlider").GetComponent<Slider>();
        EnergySlider = GameObject.Find("ESlider").GetComponent<Slider>();

        pathMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PathMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gogogo)
        {
            oxygen -= oxygenReduction*Time.deltaTime;
            fuel -= fuelReduction*Time.deltaTime;
            energy -= energyReduction*Time.deltaTime;
        }
        OxygenSlider.value = oxygen;
        FuelSlider.value = fuel;
        EnergySlider.value = energy;

        if (energy < 1 || energy > 99 || fuel < 1 || fuel > 99 || oxygen < 1 || oxygen > 99)
        {
            if (loosetext != null)
                loosetext.SetActive(true);
            pathMovement.Stop();
            gogogo = false;
        }

        Debug.Log(this.transform.position.z);

        if (this.transform.position.z > 474)
        {
            if (wintext != null)
                wintext.SetActive(true);
            pathMovement.Stop();
            gogogo = false;
            Debug.Log("Mööp");
            
        }

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
