using UnityEngine;

public class EnemySpawm : MonoBehaviour
{

    public Transform spawnPosition;
    Vector3 randomLocation;
    public GameObject enemy;

    void Start()
    {
        //We will spawn 5 random ghost at the beginning of the game
        for(int i = 0; i < 20; i++)
        {
            SpawnRandomGhost();
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SpawnRandomGhost()
    {
        //ObjectPosition
        randomLocation = Random.insideUnitSphere * 83; //scenery size
        randomLocation.y = 0;

        //Checking position colliders, spawn only happens when no collisions
        Collider[] hitColliders = new Collider[2]; //Max number of colliders it will check
        int numColliders = Physics.OverlapSphereNonAlloc(spawnPosition.position + randomLocation, 0.21f, hitColliders);
        if (numColliders == 0)
        {
            Instantiate(enemy, spawnPosition.position + randomLocation, enemy.transform.rotation);
        }
        else
        {
            SpawnRandomGhost();
        }

    }

}
