using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject makeCloneOf;
    public Transform player;
    public float forceVal=2f;
    Rigidbody rb;
    public ShowTrajectory showTrajectory;
    public bool GameIsPaused = false;
    public GameObject NewBullet()
    {
        Vector3 offset=2*player.forward;
        GameObject bullet;
        bullet=Instantiate(makeCloneOf,player.position+offset,Quaternion.identity);
        return bullet;
    }
    public void Shoot(Vector3 Force, GameObject bullet)
    {
        rb=bullet.GetComponent<Rigidbody>();
        Vector3 direction=Force;
        direction.y=direction.y/5;
        rb.useGravity=true;
        rb.AddForce(direction*forceVal/1000);
    }
    public void Delete(GameObject bullet)
    {
        Destroy(bullet,10f);
    }
    public void CallTrajectory(Vector3 Force)
    {
        Rigidbody rb=makeCloneOf.GetComponent<Rigidbody>();
        Vector3 offset=2*player.forward;
        Vector3 direction=Force;
        direction.y=direction.y/5;
        showTrajectory.UpdateTrajectory(direction*forceVal/1000,rb.mass, player.position+offset);
    }
    public void RemoveTrajectory()
    {
        showTrajectory.HideLine();
    }
    public void ResumeGame()
    {
        GameIsPaused = false;
    }
    public void PauseGame()
    {
        GameIsPaused = true;
    }

}
