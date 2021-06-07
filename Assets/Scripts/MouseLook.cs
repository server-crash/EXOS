using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float mouseX;
    float mouseY;
    public float mouseSensitivity=100f;
    public Transform playerBody;
    float upRotation=0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX=Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
        mouseY=Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;
        upRotation-=mouseY;
        upRotation=Mathf.Clamp(upRotation,-90f,90f);
        transform.localRotation=Quaternion.Euler(upRotation,0f,0f);
        playerBody.Rotate(Vector3.up*mouseX);
    }
}
