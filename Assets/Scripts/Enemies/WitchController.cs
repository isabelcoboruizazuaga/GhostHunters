using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchController : EnemyController
{
    public float velocity = 2f;
    public float rotationChangeTime = 1.5f;
    public float directionChangeTime = 3f;

    public float rangoX = 1f;
    public float rangoY = 0.5f;
    public float rangoZ = 1f;

    private float latestDirectionChangeTime;
    private float latestRotationChangeTime;
    private Vector3 movementDirection;
    private Vector3 movementPerSecond;

    public Transform playerPosition;
    public float maxDistance = 15f;

    private bool playerSeen=false;

    /*
    *TO DO
    *Change this scrip to the demon or another ghost, the witch one should shoot
    *use the enemy parent
    */
    void Start()
    {
        latestDirectionChangeTime = 0f;
        CalcuateNewMovementVector();
    }

    void CalcuateNewMovementVector()
    {
        //creating a random direction vector, the ghost shouldn't be higher than 25f
        float y = (transform.position.y >= 25f) ? Random.Range(-rangoY, -0.1f) : Random.Range(-rangoY, rangoY);
        movementDirection = new Vector3(Random.Range(-rangoX, rangoX), y, Random.Range(-rangoZ, rangoZ));
        movementPerSecond = movementDirection * velocity;
    }

    void Update()
    {
        if (!playerSeen)
        {
            CanSeeTarget();

            //when time is reached the directionChanges
            if (Time.time - latestDirectionChangeTime > directionChangeTime)
            {
                latestDirectionChangeTime = Time.time;
                CalcuateNewMovementVector();
            }
            if (Time.time - latestRotationChangeTime > rotationChangeTime)
            {
                latestRotationChangeTime = Time.time;
                LookAtRandom();
            }
        }
        else
        {
            transform.LookAt(playerPosition.position);
            movementDirection= playerPosition.position - transform.position;
            movementPerSecond =movementDirection * velocity;
        }

        //move enemy:
        transform.Translate(movementPerSecond * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
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
                latestDirectionChangeTime = Time.time;
                movementDirection = new Vector3(-movementDirection.x, movementDirection.y, -movementDirection.z);
                movementPerSecond = movementDirection * velocity;
            }
        }
    }

    private void LookAtRandom()
    {
        transform.Rotate(0, Random.Range(-180, 180), 0);
    }

    bool CanSeeTarget()
    {
        if (playerPosition == null)
            return false;

        Vector3 direccion = playerPosition.position - transform.position;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direccion, out hit, maxDistance))
        {
            if (hit.collider.transform == playerPosition)
            {
                playerSeen = true;
                return true;
            }
        }

        return false;
    }
}
