using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBulletHoles : MonoBehaviour
{
    [SerializeField] private GameObject bulletHole;
    private int bulletHoleCount = 0;
    internal bool isTutorial = true;

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.contactCount);
        if(collision.transform.tag.Equals("Bullet"))
        {
            var hole = Instantiate(bulletHole, collision.GetContact(0).point, bulletHole.transform.rotation);
            hole.transform.SetParent(this.transform);
            bulletHoleCount++;
        }
    }
}
