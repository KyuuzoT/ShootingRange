using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBulletHoles : MonoBehaviour
{
    [SerializeField] private GameObject bulletHole;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if(other.tag.Equals("Bullet"))
        {
            Debug.Log("BULLET!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if(collision.transform.tag.Equals("Bullet"))
        {
            var hole = Instantiate(bulletHole, collision.GetContact(0).point, bulletHole.transform.rotation);
        }
    }
}
