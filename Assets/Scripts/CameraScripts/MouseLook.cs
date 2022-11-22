using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 200f;
    [SerializeField] Transform playerbody;

    private float xRotation = 0f;
    private float yRotation = 0f;
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponentInParent<PlayerMovement>().IsActive)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

            playerbody.Rotate(Vector3.up * mouseX);
        }
    }
}
