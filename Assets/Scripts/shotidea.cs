using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotidea : AxeGhostMovement
{

    public GameObject magicBall;

    public Transform ballSpawn;
    public float shotRate = 3f; //Time untill next shot
    private float shotRateTime = 0;
    public float shotForce = 300;

    protected override void Update()
    {
        base.Update();

        if (CanSeePlayer())
        {
            transform.LookAt(playerPosition.position);
            velocity = 0;

            if (Time.time > shotRateTime)
            {
                StartCoroutine(ShotPlayer());
            }
        }
    }


    private IEnumerator ShotPlayer()
    {
        /**
        *TO DO
        *Make ghost stop moving while shooting
        **/
        GameObject newBullet = Instantiate(magicBall, ballSpawn.position, ballSpawn.rotation);

        //Waiting for creation animation
        yield return new WaitForSeconds(0.45f);

        //shooting the ball
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shotForce);
        Destroy(newBullet, 3);

        shotRateTime = Time.time + shotRate;
        Debug.Log("Piu piu");
    }
}