using System.Collections;
using UnityEngine;

public class DemonController : AxeGhostMovement
{

    public AudioSource seenAudio;
    private bool firstTimeSeeing=true;

    protected override void Update()
    {
        if (!playerSeen)
        {
            CanSeePlayer();
            base.Update();
        }
        else
        {
            StartCoroutine(Sound());

            //Seen sound only plays the first time player has been seen
            if (firstTimeSeeing)
            {
                seenAudio.Play();
                firstTimeSeeing = false;
            }

            transform.LookAt(playerPosition.position);
            movementDirection = playerPosition.position - transform.position;
            movementPerSecond = movementDirection * velocity;

            //move enemy:
            transform.Translate(movementPerSecond * Time.deltaTime);

        }

    }
    private IEnumerator Sound()
    {      
        myAudioSource.Play();
        yield return new WaitForSeconds(2f);
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Building")
        {
            //When following the player it can go through buildings
            if (playerSeen)
            {
                if (collision.gameObject.tag == "Building")
                {
                    Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
                }
            }
            else
            {
                base.OnCollisionEnter(collision);
            }
        }
    }


    internal override int TypeOfGhost()
    {
        return 1;
    }

}
