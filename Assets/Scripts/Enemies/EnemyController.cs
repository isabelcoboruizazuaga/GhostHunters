using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EnemyController : MonoBehaviour
{
    public Transform playerPosition;
    protected GameObject player;
    public float maxDistance = 15f;
    public int coins = 1;

    protected bool playerSeen = false;

    public GameObject efectoExplosion;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = GameObject.Find("Player");
        playerPosition =player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Explode()
    {
        player.GetComponent<PlayerMovement>().money += coins;
        var explotion = Instantiate(efectoExplosion, transform.position, transform.rotation);

        DestroyElements();
        Destroy(explotion, 1);
        Destroy(gameObject);

        //Create a new ghost
        GameObject.Find("EnemySpawn").GetComponent<EnemySpawn>().CallSpawn(TypeOfGhost());
    }


    internal virtual int TypeOfGhost()
    {
        return -1;
    }

    internal virtual void DestroyElements()
    {
        //does nothing as base enemy doesn't shoot
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
