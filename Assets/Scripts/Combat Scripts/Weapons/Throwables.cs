using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwables : MonoBehaviour
{
    public GameObject effect;
    public float delay = 5f;
    public float damage = 10f;
    public float explosionForce = 12f;
    public float radius = 15f;
    private void Start()
    {
        Invoke("Explode", delay);
        Debug.Log("Bomb counting activated");
    }
    protected void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius); //Getting colliders in range

        foreach (Collider nearCollider in colliders)
        {
            Rigidbody rig = nearCollider.GetComponent<Rigidbody>();
            if (rig != null)
            {
                float dist = Vector3.Distance(nearCollider.transform.position, transform.position);
                rig.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
                try
                {
                    PlayerStats stats = nearCollider.GetComponent<PlayerStats>();
                    float finalDamage = (damage - (dist * (damage / radius)));
                    if (finalDamage < 0)
                        finalDamage = 0;
                    stats.CurrentHealth -= finalDamage;
                    Debug.Log("Damaged: " + finalDamage);
                }
                catch
                {
                    Debug.Log("Player Stats not found");
                }
            }
        }
        if(effect != null)
            Object.Destroy(Instantiate(effect, transform.position, transform.rotation),delay+1f); //Playing effect at the throwable location
        Debug.Log("boom");
        Destroy(gameObject);  //Destroying throwable
        
    }
}
