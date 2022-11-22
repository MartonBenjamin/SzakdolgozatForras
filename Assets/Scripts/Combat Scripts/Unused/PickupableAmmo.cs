using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableAmmo : MonoBehaviour
{
    public int amount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<AmmoSystem>() != null)
        {
            Destroy(this.gameObject);
            
            AmmoSystem helper = other.GetComponent<AmmoSystem>();
            helper.AmmoPickUp(amount);
        }
        
    }
}
