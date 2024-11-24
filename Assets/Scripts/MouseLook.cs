using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles everything concerning the view
/// Contains rotation, cursor locking, mouse input handling
/// </summary>
public class MouseLook : MonoBehaviour
{ 
    private float lookLimit = 80f;
    public float sensitivity = 1000f;
    public Transform body;
    private float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        xRotation -= mouseY * Time.deltaTime * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -lookLimit, lookLimit);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * mouseX * Time.deltaTime * sensitivity);
    }
}
