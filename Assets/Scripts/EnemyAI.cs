using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    static bool activate;
    public float activationRadius=40f;
    public float lookRadius=10f,cooldown=0.5f ; 
    public Transform target;
    public NavMeshAgent agent; 
    public Vector3 offset= new Vector3(1,1,1);
    public GameObject bullet;
    GameObject bulletalias;
    Rigidbody r_bodybullet;
    public GameObject particle;
    public GameObject gun;
    public Animator animator;
    float particleTime;
    bool isDead;
    public GameManager manager;
    public AudioSource shootAudio;
    public AudioSource walk;
    
    void Start() 
    {
       particle.SetActive(false);
    }
    void Update()
    {
        if(true)
        {
            float distance=Vector3.Distance(target.position,transform.position);
            if(distance<=activationRadius)
            {
                activate=true;
                if(particleTime<=1.5f)
                {
                    particle.SetActive(true);
                }
                else
                {
                    particle.SetActive(false);
                    particleTime=5f;
                }
            }
            if(activate)
            {
                particleTime+=Time.deltaTime;
                if(cooldown<=0.5f)
                {
                    cooldown+=Time.deltaTime;
                }
                if(distance<=lookRadius)
                {
                    animator.SetBool("IsShoot",true);
                    agent.isStopped=true;
                    walk.Stop();
                    FaceTarget();
                    RaycastHit hit;
                    Debug.DrawRay(transform.position+offset, (target.position-(transform.position+offset))*1000, Color.green);
                    if(Physics.Raycast(transform.position+offset,(target.position-(transform.position+offset)), out hit,lookRadius))
                    {
                        if(cooldown>=0.5f&&(hit.transform.tag=="fps"||hit.transform.tag=="AlienBullet"))
                        {
                            Debug.Log("yo");
                            Shoot();
                            cooldown=0;
                            if(!shootAudio.isPlaying)
                            shootAudio.Play();
                        }
                    }
                }
                else
                {
                    agent.isStopped=false;
                    animator.SetBool("IsShoot",false);
                    agent.SetDestination(target.position);
                    if(!walk.isPlaying)
                    {
                        walk.Play();
                    }
                    shootAudio.Stop();
                }
            }
        }
        
    }
    void Shoot()
    {
        if(isDead==false)
        {
            bulletalias = Instantiate(bullet,transform.position+offset+transform.forward,transform.rotation);
            r_bodybullet=bulletalias.GetComponent<Rigidbody>();
            r_bodybullet.AddForce(((target.position-(transform.position+offset)).normalized)*1000);
            Destroy(bulletalias,3f);
        }
    }
    void FaceTarget()
    {
        Vector3 direction=(target.position-transform.position-transform.forward).normalized;
        Quaternion lookRotation=Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation=Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*15f);
    }
    public void SetDead()
    {
        isDead=true;
        animator.SetBool("IsDead",true);
        gun.SetActive(false);
    }
}
