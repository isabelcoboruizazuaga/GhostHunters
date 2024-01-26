using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class EnemyRandomMovement : MonoBehaviour
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
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector3(Random.Range(-rangoX, rangoX), Random.Range(-rangoY, rangoY), Random.Range(-rangoZ, rangoZ));//.normalized;
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

    private void LookAtRandom()
    {
        transform.Rotate(0, Random.Range(-180,180), 0);
    }
}
