using System.Collections;
using UnityEngine;

public class WitchController : AxeGhostMovement
{

    public GameObject magicBall;

    public Transform ballSpawn;
    public float shotRate = 3f; //Time untill next shot
    private float shotRateTime = 0;
    public float shotForce = 1500;

    private GameObject newBall;

    protected override void Update()
    {
        base.Update();

        if (CanSeePlayer())
        {
            transform.LookAt(playerPosition.position);
            velocity = 0;

            if (Time.time > shotRateTime)
            {

                shotRateTime = Time.time + shotRate;
                StartCoroutine(ShotPlayer());
            }
        }
    }


    private IEnumerator ShotPlayer()
    {
        /**
        *TO DO
        *Make ghost stop moving while shooting
        *Delete Ball when enemy dies
        **/
        newBall = Instantiate(magicBall, ballSpawn.position, ballSpawn.rotation);

        //Waiting for creation animation
        yield return new WaitForSeconds(1f);

        newBall.GetComponent<Rigidbody>().useGravity = true;

        //shooting the ball
        newBall.GetComponent<Rigidbody>().AddForce(transform.forward * shotForce);
        Destroy(newBall, 3);
    }

    internal override void DestroyElements()
    {
        Destroy(newBall);
    }
}
