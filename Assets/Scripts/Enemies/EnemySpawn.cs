using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public Transform spawnPosition;
    Vector3 randomLocation;
    public GameObject axeGhost, witchGhost, demonGhost, axeBoss, witchBoss, demonBoss;

    private float colliderRadius = 0.291f;
    void Start()
    {
        //We will spawn 10 random ghost at the beginning of the game
        //lvl 1: 7axe 2witch 1demon
        //lvl3: 6axe 3 witch 1 demon
        //lvl5: 5 axe, 3witch 2demon -> axe boss
        //lvl6-10: 4axe, 4witch 2demon
        //lvl 6,7,8: vida axe*2
        //lvl 8,9: vida witch*2
        //lvl 10: witch boss

        for (int i = 0; i < 10; i++)
        {
            if (i < 7)
            {
                SpawnGhost(axeGhost);
            }
            else if (i > 8)
            {
                SpawnGhost(demonGhost);
            }
            else
            {
                SpawnGhost(witchGhost);
            }
        }

    }
    internal void CallSpawn(int ghost)
    {
        switch (ghost)
        {
            case 0:
                SpawnGhost(axeGhost);
                break;
            case 1:
                SpawnGhost(demonGhost);
                break;
            case 2:
                SpawnGhost(witchGhost);
                break;
            case 3:
                SpawnGhost(axeBoss); 
                break;
            case 4:
                SpawnGhost(demonBoss);
                break;
            case 5:
                SpawnGhost(witchBoss);
                break;
        }
    }
    internal void SpawnGhost(GameObject enemy)
    {
        //ObjectPosition
        randomLocation = Random.insideUnitSphere * 83; //scenery size
        randomLocation.y = 0;

        //Checking position colliders, spawn only happens when no collisions
        Collider[] hitColliders = new Collider[2]; //Max number of colliders it will check
        int numColliders = Physics.OverlapSphereNonAlloc(spawnPosition.position + randomLocation, colliderRadius, hitColliders);
        if (numColliders == 0)
        {
            Instantiate(enemy, spawnPosition.position + randomLocation, enemy.transform.rotation);
        }
        else
        {
            SpawnGhost(enemy);
        }

    }

}
