using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossAI : MonoBehaviour
{
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
        if(cooldown<=0.5f)
        {
            cooldown+=Time.deltaTime;
        }
       float distance=Vector3.Distance(target.position,transform.position);
       if(distance<=lookRadius)
       {
           animator.SetBool("IsShoot",true);
            agent.isStopped=true;
           FaceTarget();
           RaycastHit hit;
           Debug.DrawRay(transform.position+offset, transform.forward*1000, Color.green);
           if(Physics.Raycast(transform.position+offset,transform.forward, out hit,lookRadius))
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
    void Shoot()
    {
        Vector3 offset2=transform.forward*2+offset;
        bulletalias = Instantiate(bullet,transform.position+offset2,transform.rotation);
        r_bodybullet=bulletalias.GetComponent<Rigidbody>();
        r_bodybullet.AddForce(transform.forward*1000);
        Destroy(bulletalias,3f);
    }
    void FaceTarget()
    {
        Vector3 direction=(target.position-transform.position).normalized;
        Quaternion lookRotation=Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation=Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*15f);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }
}
