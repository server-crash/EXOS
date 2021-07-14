using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public NumberOfHitsEnemy hitNumber;
    public HealthManager health;
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Bullet")
        {
            Destroy(other.gameObject,0.5f);
            health.TakeDamage(health.maxHealth/hitNumber.numberHitsFinal);
        }
    }
}


