using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHealthUp : MonoBehaviour
{
    public AudioSource collect;
    bool isPlayed;
    private void OnTriggerEnter(Collider other) 
    {
        if(!collect.isPlaying&&other.tag=="fps"&&!isPlayed)
        {
            collect.Play();
            isPlayed=true;
        }
    }
}
