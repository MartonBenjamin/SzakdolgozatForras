using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isActive;

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    public float speed = 4;

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private PlanetGravity planetGravity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (IsActive)
        {
            float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Translate(x, 0, z);


            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(0, 150 * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(0, -150 * Time.deltaTime, 0);
            }
        }
    }
    public void Ascend(float power)
    {
        rb.AddForce(transform.up * power * 10 * Time.deltaTime, ForceMode.Acceleration);
    }
}
