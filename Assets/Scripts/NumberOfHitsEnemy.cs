using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfHitsEnemy : MonoBehaviour
{
    public int numberHitsFinal=2;
    int numberHits=0;
    public EnemyAI enemyAI;
    public GameObject blast;
    public void UpdateNumber(GameObject enemy)
    {
        numberHits++;
        if(numberHits==numberHitsFinal)
        {
            enemyAI.SetDead();
            Destroy(enemy,4f);
        }
    }

}
