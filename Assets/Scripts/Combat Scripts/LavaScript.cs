using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    int i = 0;
    public int dmg = 1;
    private void OnTriggerStay(Collider other)
    {

        var target = other.gameObject;
        i++;
        if (i==5)
        {
            target.transform.GetComponent<PlayerStats>().CurrentHealth-=dmg;
            i = 0;
        }
    
    }
}
