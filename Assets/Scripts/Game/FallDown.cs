using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.velocity = -rb.velocity;
        if (other.GetComponent<PlayerStats>() != null)
        {
            
            other.GetComponent<PlayerStats>().Death();
        }

    }
}
