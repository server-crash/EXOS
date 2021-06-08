using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float x;
    float z;

    Vector3 velocity;
    Vector3 move;
    public float speed=12f;

    public float gravity=-9.81f;
    public float jumpHeight=3f;

    public Transform groundCheck;
    public float groundDistance=0.2f;
    public LayerMask groundMask;
    bool isGrounded;

    bool isStop;
    public MouseLook mouse;

    Vector3 mousePressPos;
    Vector3 mouseReleasePos;
    public GameManager manager;
    GameObject bullet;
    bool isClicked;

    public CharacterController controller;
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            mousePressPos=Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 100000f));
            mouse.CursorUnlock();
            mouse.enabled=false;
            isStop=true;
            isClicked=true;
        }
        if(isClicked)
        {
            mouseReleasePos=Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 100000f));
            manager.CallTrajectory(mousePressPos-mouseReleasePos);
        }
        if(Input.GetButtonUp("Fire1"))
        {
            mouse.CursorLock();
            mouse.enabled=true;
            isStop=false;
            bullet=manager.NewBullet();
            manager.Shoot(mousePressPos-mouseReleasePos,bullet);
            manager.Delete(bullet);
            manager.RemoveTrajectory();
            isClicked=false;
        }
        isGrounded=Physics.CheckSphere(groundCheck.position, groundDistance,groundMask);
        if(isGrounded&&velocity.y<0)
        {
            velocity.y=-2f;
        }
        if(isGrounded&&Input.GetButtonDown("Jump"))
        {
            velocity.y=Mathf.Sqrt(-2f*jumpHeight*gravity);
        }
        x=Input.GetAxis("Horizontal");
        z=Input.GetAxis("Vertical");
        move=transform.right*x+transform.forward*z;
        if(!isStop)
        {
            controller.Move(move*speed*Time.fixedDeltaTime);
        }
        velocity.y+=gravity*Time.fixedDeltaTime;
        controller.Move(velocity*Time.fixedDeltaTime);
    }
}
