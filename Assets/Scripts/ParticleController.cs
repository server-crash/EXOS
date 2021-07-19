using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private bool playEnv= false;
    private ParticleSystem particleObject;

    void Start () {
        particleObject = GetComponent<ParticleSystem>();
        particleObject.Stop();
    }


  void Update()
{
    if (playEnv)
    {
        Debug.Log("Running");
        particleObject.Play();
        playEnv = false;
    }
}
public void particleEnvPlay()
    {
        Debug.Log("hit");
        playEnv = true;
    }
}
