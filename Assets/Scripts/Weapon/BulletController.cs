using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public GameObject efectoExplosion;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(efectoExplosion, transform.position, transform.rotation);

            Destroy(collision.gameObject);
            Destroy(this, 1);
        }
    }
}
