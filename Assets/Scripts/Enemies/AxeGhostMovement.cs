using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class EnemyRandomMovement : EnemyController
{
    public float velocity = 2f;
    public float rotationChangeTime = 1.5f;
    public float directionChangeTime = 3f;

    public float rangoX=1f;
    public float rangoY=0.5f;
    public float rangoZ=1f;

    private float latestDirectionChangeTime;
    private float latestRotationChangeTime;
    private Vector3 movementDirection;
    private Vector3 movementPerSecond;


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

        //move enemy:
        transform.Translate(movementPerSecond * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Building")
        {
            latestDirectionChangeTime = Time.time;
            movementDirection = new Vector3(-movementDirection.x, movementDirection.y, -movementDirection.z);
            movementPerSecond = movementDirection * velocity;
        }
    }

    private void LookAtRandom()
    {
        transform.Rotate(0, Random.Range(-180,180), 0);
    }
}
