using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float forceVal=1000f;
    public Rigidbody bullet;
    public Transform player;
    public void Shoot(Vector3 Force)
    {
        Vector3 direction=Force;
        direction.y=direction.y/5;
        Debug.Log(direction);
        transform.position=player.position+2*player.forward;
        transform.rotation=player.rotation;
        bullet.useGravity=true;
        bullet.AddForce(direction*forceVal);
    }
}
