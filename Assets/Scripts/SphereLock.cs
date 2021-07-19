using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLock : MonoBehaviour
{
    public GameObject sphere;
    public float time=0f;
    public int enemyCount;
    int enemyct;
    float timePassed;
    bool isEnter;
    void Start()
    {
        sphere.SetActive(false);
    }
    void Update()
    {
        if(isEnter)
        {
            timePassed+=Time.deltaTime;
            if(timePassed>time)
            {
                sphere.SetActive(true);
            }
        }
        if(enemyct==enemyCount+1)
        {
            sphere.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag=="fps")
        {
            isEnter=true;
        }
    }
    public void UpdateEnemyNumber()
    {
        enemyct++;
    }
}
