using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graves : MonoBehaviour
{
    public GameObject[] graves;
    
    public GameObject getRandomGrave()
    {
        return graves[Random.Range(0, graves.Length)];
    }
}
