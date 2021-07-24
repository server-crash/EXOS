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
        if(objPackageCount==2)
        {
            boss.SetActive(true);
        }
    }
}
