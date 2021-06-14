using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="AlienBullet")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(),other.collider);
        }
    }
}
