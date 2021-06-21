using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    bool activate;
    public float activationRadius=40f;
    public float lookRadius=10f,cooldown=0.5f ; 
    public Transform target;
    public NavMeshAgent agent; 
    public float range=50f;
    public Vector3 offset= new Vector3(1,1,1);
    public GameObject bullet;
    GameObject bulletalias;
    Rigidbody r_bodybullet;
    public Animator animator;
    void Update()
    {
        float distance=Vector3.Distance(target.position,transform.position);
        if(distance<=activationRadius)
        {
            activate=true;

        }
        if(activate)
        {
            if(cooldown<=0.5f)
            {
                cooldown+=Time.deltaTime;
            }
            if(distance<=lookRadius)
            {
                animator.SetBool("IsShoot",true);
                agent.isStopped=true;
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
                    }
                }
            }
            else
            {
                agent.isStopped=false;
                animator.SetBool("IsShoot",false);
                    agent.SetDestination(target.position);
            }
        }
        
    }
    void Shoot()
    {
        //Vector3 offset2=transform.forward*3+offset;
        bulletalias = Instantiate(bullet,transform.position+offset+transform.forward,transform.rotation);
        r_bodybullet=bulletalias.GetComponent<Rigidbody>();
        r_bodybullet.AddForce(((target.position-(transform.position+offset)).normalized)*1000);
        Destroy(bulletalias,3f);
    }
    void FaceTarget()
    {
        Vector3 direction=(target.position-transform.position-transform.forward).normalized;
        Quaternion lookRotation=Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation=Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*15f);
    }
}
