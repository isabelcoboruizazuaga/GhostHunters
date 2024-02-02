using UnityEngine;

public class DemonController : AxeGhostMovement
{
    protected override void Update()
    {
        if (!playerSeen)
        {
            CanSeePlayer();
            base.Update();
        }
        else
        {
            transform.LookAt(playerPosition.position);
            movementDirection = playerPosition.position - transform.position;
            movementPerSecond = movementDirection * velocity;

            //move enemy:
            transform.Translate(movementPerSecond * Time.deltaTime);
        }

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
        return 2;
    }

}
