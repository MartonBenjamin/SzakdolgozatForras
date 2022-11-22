using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public int dps = 5;
    private void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        try
        {
            PlayerStats stats = other.GetComponent<PlayerStats>();
            if (stats.CurrentHealth > 0)
                stats.CurrentHealth -= dps * Time.deltaTime;
        }
        catch
        {

        }
    }

}
