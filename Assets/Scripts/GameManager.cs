using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject makeCloneOf;
    public Transform player;
    public float forceVal=2f;
    Vector3 offset;
    Rigidbody rb;
    public GameObject NewBullet()
    {
        offset=2*player.forward;
        GameObject bullet;
        bullet=Instantiate(makeCloneOf,player.position+offset,Quaternion.identity);
        return bullet;
    }
    public void Shoot(Vector3 Force, GameObject bullet)
    {
        rb=bullet.GetComponent<Rigidbody>();
        Vector3 direction=Force;
        direction.y=direction.y/5;
        Debug.Log(direction);
        rb.useGravity=true;
        rb.AddForce(direction*forceVal);
    }
    public void Delete(GameObject bullet)
    {
        Destroy(bullet,10f);
    }

}
