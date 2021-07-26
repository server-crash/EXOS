using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    int count;
    public int objectiveEnemyCount;
    public int bossEnemyCount;
    public void UpdateCount()
    {
        count++;
        if(count==2*objectiveEnemyCount+bossEnemyCount)
        {
            //win game screen
        }
    }
}
