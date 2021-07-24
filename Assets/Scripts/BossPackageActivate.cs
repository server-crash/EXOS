using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPackageActivate : MonoBehaviour
{
    int objPackageCount=0;
    public GameObject boss;
    public void UpdateCount()
    {
        objPackageCount++;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="fps"&&objPackageCount==2)
        {
            boss.SetActive(true);
        }
    }
}
