using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    void Start()
    {
         Physics.IgnoreLayerCollision(6, 7);
    }
    // void OnCollisionEnter(Collision other)
    // {
    //     if(other.gameObject.tag=="AlienBullet")
    //     {
    //         Physics.IgnoreCollision(GetComponent<Collider>(),other.collider);
    //     }
    // }
}
