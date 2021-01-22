using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    [SerializeField] private Transform deathZone;
    [SerializeField] private int pointsPerTarget = 10;

    private void OnCollisionEnter(Collision collision)
    {
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
        GlobalVars.ScorePoints += pointsPerTarget;
        Destroy(transform.gameObject);
    }
}
