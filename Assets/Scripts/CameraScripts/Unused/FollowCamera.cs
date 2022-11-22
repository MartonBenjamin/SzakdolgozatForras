using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target;
    public Vector3 targetDist;
    public Transform basicDist;

    void Start()
    {
        setTarget();
    }
    public void setTarget()
    {
        basicDist = target.transform.Find("CamPos");
        transform.position = basicDist.transform.position;
        targetDist = transform.position - target.transform.position;
        Debug.Log(targetDist);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.transform.position + targetDist;
            transform.LookAt(target.transform);
        }
        if (Input.GetKey(KeyCode.V))
            setTarget();

    }
}
