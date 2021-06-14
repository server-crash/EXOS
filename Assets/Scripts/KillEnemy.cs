using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    NumberOfHitsEnemy enemy;
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Kill");
        if(other.gameObject.tag=="Alien")
        {
            Debug.Log("Kill");
            enemy=other.gameObject.GetComponent<NumberOfHitsEnemy>();
            //Destroy(other.gameObject,0f);
            enemy.UpdateNumber(other.gameObject);

        }
    }
}
