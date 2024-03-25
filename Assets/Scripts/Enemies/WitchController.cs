using System.Collections;
using UnityEngine;

public class WitchController : AxeGhostMovement
{

    public GameObject magicBall;

    public Transform ballSpawn;
    public float shotRate = 1f; //Time untill next shot
    private float shotRateTime = 0;
    public float shotForce = 1500;

    private GameObject newBall;

    public AudioSource shotAudio;
    private bool audioPlaying=false;

    protected override void Update()
    {

        if (CanSeePlayer())
        {
            transform.LookAt(playerPosition.position);
            velocity = 0;

            StartCoroutine(BooSound());

            if (Time.time > shotRateTime)
            {
                shotRateTime = Time.time + shotRate;
                StartCoroutine(ShotPlayer());
            }
        }
        else
        {
            velocity = 3;

            base.Update();
        }
    }


    private IEnumerator ShotPlayer()
    {
        newBall = Instantiate(magicBall, ballSpawn.position, ballSpawn.rotation);
        shotAudio.Play();

        //Waiting for creation animation
        yield return new WaitForSeconds(1f);

        newBall.GetComponent<Rigidbody>().useGravity = true;

        //shotting the ball
        audioPlaying = true;
        newBall.GetComponent<Rigidbody>().AddForce(transform.forward * shotForce);
        Destroy(newBall, 3);
        StartCoroutine(StopShot());

    }
    private IEnumerator BooSound()
    {
        //make sure other sound isnt playin
        if (!audioPlaying)
        {

            myAudioSource.Play();
        }
        yield return new WaitForSeconds(3.5f);
    }
    private IEnumerator StopShot()
    {
        yield return new WaitForSeconds(1f);

        shotAudio.Stop();
        audioPlaying = false;
    }

    internal override void DestroyElements()
    {
        Destroy(newBall);
    }

    internal override int TypeOfGhost()
    {
        return 2;
    }
}
