using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public GameObject efectoExplosion;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + " " + other.name);
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().Explode();

            Destroy(this, 1);
        }
    }
}
