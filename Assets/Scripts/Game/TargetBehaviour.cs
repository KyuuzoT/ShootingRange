using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    [SerializeField] private Transform deathZone;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        Debug.Log(collision.transform.name.Equals(deathZone.name));
        if(collision.transform.name.Equals(deathZone.name))
        {
            var platform = transform.parent.GetComponent<PlatformBehaviour>();
            platform.cubesOnPlatform.Remove(transform);
            StartCoroutine(DestroyTarget());
        }
    }

    private IEnumerator DestroyTarget()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Destroy: " + transform.name);
        GlobalVars.ScorePoints += 1;
        Destroy(transform.gameObject);
    }
}
