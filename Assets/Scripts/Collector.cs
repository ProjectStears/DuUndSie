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

    // Use this for initialization
    void Start()
    {
        OxygenSlider = GameObject.Find("O2Slider").GetComponent<Slider>();
        FuelSlider = GameObject.Find("FuelSlider").GetComponent<Slider>();
        EnergySlider = GameObject.Find("ESlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        oxygen -= oxygenReduction * Time.deltaTime;
        fuel -= fuelReduction * Time.deltaTime;
        energy -= energyReduction * Time.deltaTime;

        OxygenSlider.value = oxygen;
        FuelSlider.value = fuel;
        EnergySlider.value = energy;
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
