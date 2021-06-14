using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfHitsEnemy : MonoBehaviour
{
    public int numberHitsFinal=2;
    int numberHits=0;
    public void UpdateNumber(GameObject enemy)
    {
        numberHits++;
        if(numberHits==numberHitsFinal)
        {
            Destroy(enemy,0f);
        }
    }

}
