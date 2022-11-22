using Assets.Scripts.Combat_Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodable : MonoBehaviour
{
    Granade values;
    void Start()
    {
        Invoke("Explode", values.delay);
    }

    protected void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, values.radius); //Getting colliders in range

        foreach (Collider nearCollider in colliders)
        {
            Rigidbody rig = nearCollider.GetComponent<Rigidbody>();
            if (rig != null)
            {
                rig.AddExplosionForce(values.explosionForce, this.transform.position, values.radius, 1f, ForceMode.Impulse);
                float dist = Vector3.Distance(nearCollider.transform.position, this.transform.position);
                try
                {
                    PlayerStats stats = nearCollider.GetComponent<PlayerStats>();
                    float finalDamage = (values.damage - (dist * (values.damage / values.radius)));
                    stats.CurrentHealth -= finalDamage;
                    Debug.Log("Damaged: " + finalDamage);
                }
                catch
                {
                    Debug.Log("Player Stats not found");
                }
            }
        }
        if (values.effect != null)
            Object.Destroy(Instantiate(values.effect, this.transform.position, this.transform.rotation), values.delay + 1f); //Playing effect at the throwable location
        Debug.Log("boom");
        Destroy(this.gameObject);  //Destroying throwable

    }
}
