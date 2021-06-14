using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Kill");
        if(other.gameObject.tag=="Alien")
        {
            Debug.Log("Kill");
            Destroy(other.gameObject,0f);
        }
    }
}
