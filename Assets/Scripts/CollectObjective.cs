using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjective : MonoBehaviour
{
    public SphereLock sphere;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="fps")
        {
            sphere.UpdateEnemyNumber();
            Destroy(gameObject);
            Debug.Log("Done");
        }
    }
}
