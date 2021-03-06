using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float x;
    float z;

    Vector3 velocity;
    Vector3 move;
    public float intSpeed=7f;
    float speed;

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

    public Animator animator;

    public CharacterController controller;

     public AudioSource walk;
    private void Start() 
    {
        speed=intSpeed;
    }
    void Update()
    {
        if(!manager.GameIsPaused)
        {
            animator.SetBool("IsShoot",false);
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
                animator.SetBool("IsShoot",true);
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
            bool isX=!Mathf.Approximately(x,0f);
            int isRight;
            int isFront;
            if(isX)
            {
                if(x<0) isRight=-1;
                else isRight=1;
            }
            else isRight=0;
            bool isZ=!Mathf.Approximately(z,0f);
            bool isMove=isX||isZ;
            if(isZ)
            {
                if(z>0)isFront=1;
                else isFront=-1;
            }
            else isFront=0;
            if(!isStop)
            {
                controller.Move(move*speed*Time.fixedDeltaTime);
            }
            bool isRun=Input.GetKey("left shift");
            if(isRun)
            {
                if(isX)
                {
                    speed=intSpeed*1.4f;
                }
                if(isFront<0)
                {
                    speed=intSpeed;
                    isRun=false;
                }
                else if(speed<=2*intSpeed)
                {
                    speed =speed+0.04f;
                }
                walk.pitch=1.5f;
            }
            else
            {
                speed=intSpeed;
                walk.pitch=1;
            }
            if(isRun&&isMove)
            {
                animator.SetBool("IsRun",true);
            }
            else
            {
                animator.SetBool("IsRun",false);
            }
            if(isMove&&!isStop)
            {
                if(!isRun)
                {
                    animator.SetInteger("IsFront",isFront);
                    animator.SetInteger("IsRight",isRight);
                }
                else
                {
                    animator.SetInteger("IsFront",0);
                    animator.SetInteger("IsRight",0);
                }
                if(!walk.isPlaying)
                {
                    walk.Play();
                }
            }
            else
            {
                animator.SetInteger("IsFront",0);
                animator.SetInteger("IsRight",0);
                animator.SetBool("IsRun",false);
                walk.Stop();
            }
            
            velocity.y+=gravity*Time.fixedDeltaTime;
            controller.Move(velocity*Time.fixedDeltaTime);
        }
    }
}
