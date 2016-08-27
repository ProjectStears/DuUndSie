using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{
    public float Fuel;
    public float Oxygen;
    public float Energy;

    public ParticleSystem DeathParticleSystem;

    public void Kill()
    {
        if (DeathParticleSystem != null)
        {
            Instantiate(DeathParticleSystem, this.transform.position, Quaternion.identity);
        }

        GameObject.Destroy(this.gameObject);
    }
}
