using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject efectoExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
