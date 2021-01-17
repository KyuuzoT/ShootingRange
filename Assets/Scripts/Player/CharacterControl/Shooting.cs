using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject instantiationPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 10.0f;
    [SerializeField] private float timeBeforeDestruction = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var instantiatedBullet = Instantiate(bullet, instantiationPoint.transform.position, transform.rotation);
            instantiatedBullet.GetComponent<Rigidbody>().AddForce(instantiatedBullet.transform.forward * bulletSpeed, ForceMode.Impulse);
            StartCoroutine(DestroyBullet(instantiatedBullet));
        }

    }

    private IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(timeBeforeDestruction);
        Destroy(bullet);
    }
}
