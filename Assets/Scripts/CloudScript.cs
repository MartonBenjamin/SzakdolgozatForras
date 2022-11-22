using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{

    void FixedUpdate()
    {
        this.transform.Translate(new Vector3(Random.Range(0.01f, 0.1f), Random.Range(0.01f, 0.1f), Random.Range(0.01f, 0.1f))*Time.deltaTime);
    }
}
