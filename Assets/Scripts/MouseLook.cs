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
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
    }
    public void CursorUnlock()
    {
        Cursor.lockState=CursorLockMode.None;
    }
    public void CursorLock()
    {
        Cursor.lockState=CursorLockMode.Locked;
    }
    void Update()
    {
        mouseX=Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
        mouseY=Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;
        upRotation-=mouseY;
        upRotation=Mathf.Clamp(upRotation,10f,90f);
        transform.localRotation=Quaternion.Euler(upRotation,0f,0f);
        playerBody.Rotate(Vector3.up*mouseX);
    }
}
