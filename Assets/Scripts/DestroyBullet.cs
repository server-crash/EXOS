using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Bullet")
        {
            Destroy(other.gameObject,0.5f);
        }
    }
}


