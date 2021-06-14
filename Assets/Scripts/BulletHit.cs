using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="AlienBullet")
        {
            Destroy(other.gameObject,0f);
        }
    }
}
