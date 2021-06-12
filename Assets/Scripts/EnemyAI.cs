using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public float lookRadius=10f,cooldown=1f ; 
    public Transform target;
    public NavMeshAgent agent; 
    public float range=50f;
    public Vector3 offset= new Vector3(1,1,1);
    public GameObject bullet;
    GameObject bulletalias;
    Rigidbody r_bodybullet;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(cooldown<=1f)
        {
            cooldown+=Time.deltaTime;
        }
       float distance=Vector3.Distance(target.position,transform.position);
       if(distance<=lookRadius)
       {
           agent.SetDestination(target.position);
           FaceTarget();
           RaycastHit hit;
           //Debug.DrawRay(transform.position+offset, transform.forward*1000, Color.green);
           if(Physics.Raycast(transform.position+offset,transform.forward, out hit,range))
           {
               if(cooldown>=1f)
               {
                   Debug.Log("yo");
                   Shoot();
                   cooldown=0;
               }
           }
       }
    }
    void Shoot()
    {
        Vector3 offset2=transform.forward*2+offset;
        bulletalias = Instantiate(bullet,transform.position+offset2,transform.rotation);
        r_bodybullet=bulletalias.GetComponent<Rigidbody>();
        r_bodybullet.AddForce(transform.forward*1000);
        //bullet.AddForce(transform.forward*100);
        Destroy(bulletalias,3f);
    }
    void FaceTarget()
    {
        Vector3 direction=(target.position-transform.position).normalized;
        Quaternion lookRotation=Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation=Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*5f);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }
}
