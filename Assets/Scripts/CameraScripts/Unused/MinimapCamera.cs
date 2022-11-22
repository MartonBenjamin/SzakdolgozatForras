using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Transform target;
    public int distance = 70;
    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPosition = target.position;
            newPosition.y = target.position.y + distance;
            transform.position = newPosition;
        }
    }
}
