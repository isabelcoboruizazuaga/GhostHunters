using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EnemyController : MonoBehaviour
{
    public Transform playerPosition;
    public float maxDistance = 15f;

    protected bool playerSeen = false;

    public GameObject efectoExplosion;
    // Start is called before the first frame update
    protected void Start()
    {
        playerPosition = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Explode()
    {
        var explotion = Instantiate(efectoExplosion, transform.position, transform.rotation);

        Destroy(explotion, 1);
        Destroy(gameObject);

        //Create a new ghost
        GameObject.Find("EnemySpawn").GetComponent<EnemySpawn>().SpawnRandomGhost();
    }

    protected bool CanSeePlayer()
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
