using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    internal List<Transform> cubesOnPlatform = new List<Transform>();
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private Transform spawnPoint;
    void Awake()
    {
        cubesOnPlatform.AddRange(transform.GetComponentsInChildren<Transform>().Where(x => x.gameObject.name.Contains("Cube")));

        foreach (var item in cubesOnPlatform)
        {
            Debug.Log(item.name);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(cubesOnPlatform.Count<=0)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            StartCoroutine(DestroyTarget());
        }
        else
        {
            float yAxis = Mathf.Lerp(transform.position.y, 0, Time.deltaTime);
            transform.position = new Vector3(transform.position.x, yAxis, transform.position.z);
        }
    }

    private IEnumerator DestroyTarget()
    {
        yield return new WaitForSeconds(5);
        Destroy(transform.gameObject);
    }
}
