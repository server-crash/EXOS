using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Vector3 spawnPos;
    public GameObject spawnObject;
    public Transform player;
    public static Spawner Instance;
    void Awake()
    {
        Instance=this;
    }
    void SpawnNewObject()
    {
        transform.position=player.position;
        Instantiate(spawnObject, spawnPos, Quaternion.identity);
    }
}