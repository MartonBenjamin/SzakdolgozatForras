using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Rigidbody> ObjectsInRange = new List<Rigidbody>();
    public float gravityForce = -6.674f;
    public float massmultiplier;
    public float distance = 0.2f;
    private float distanceToGround;
    private Vector3 localUp;
    private Vector3 gravityVector;

    public Vector3 GravityVector
    {
        get { return gravityVector; }
        set { gravityVector = value; }
    }

    Vector3 gravityDirection;
    Vector3 Groundnormal;
    public void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Rigidbody>() != null)
        {
            ObjectsInRange.Add(col.GetComponent<Rigidbody>());
            InitializeRB(col.attachedRigidbody);
        }

    }
    public void OnTriggerExit(Collider col)
    {
        ObjectsInRange.Remove(col.GetComponent<Rigidbody>());
    }
    private void FixedUpdate()
    {
        ApplyPhysics();
    }
    private void Start()
    {
        if (massmultiplier == 0)
        {
            massmultiplier = this.transform.localScale.x;
        }
    }
    private void ApplyPhysics()
    {
        foreach (var rigidbody in ObjectsInRange)
        {
            //ShootRaycast(rigidbody);
            AddPlanetAttract(rigidbody);
        }
    }

    private void InitializeRB(Rigidbody rigidbody)
    {
        rigidbody.freezeRotation = true;
        rigidbody.useGravity = false;
    }

    private void AddPlanetAttract(Rigidbody rigidbody)
    {
        //ShootRaycast(rigidbody);
        SetGravity(rigidbody);
        SetRotation(rigidbody);
    }

    private void SetGravity(Rigidbody rigidbody)
    {
        if (rigidbody != null)
        {
            gravityDirection = (rigidbody.position - transform.position).normalized;
            localUp = rigidbody.transform.up;
            distanceToGround = gravityDirection.magnitude;
            GravityVector = gravityDirection * gravityForce * (massmultiplier / 100);
            rigidbody.AddForce(GravityVector);
        }
    }

    private void SetRotation(Rigidbody rigidbody)
    {
        if (rigidbody != null)
        {
            Quaternion toRotation = Quaternion.FromToRotation(rigidbody.transform.up, gravityDirection) * rigidbody.transform.rotation;
            rigidbody.transform.rotation = Quaternion.Slerp(rigidbody.transform.rotation, toRotation, 50f * Time.deltaTime);
        }

    }

    private void ShootRaycast(Rigidbody rigidbody)
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(rigidbody.transform.position, -rigidbody.transform.up, out hit, 10))
        {
            Groundnormal = hit.normal;
        }
    }
}

