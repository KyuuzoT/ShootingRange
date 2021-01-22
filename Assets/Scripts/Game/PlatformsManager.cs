using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> platforms;
    private bool isTutorial;
    private GameObject instantiated;

    private void Awake()
    {
        isTutorial = true;
    }

    private void Update()
    {
        if(isTutorial)
        {
            var platform = platforms.Find(x => x.name.Equals("TutorialPlatform"));
            instantiated = Instantiate(platform, platform.transform.position, platform.transform.rotation);
            isTutorial = platform.GetComponent<TargetBulletHoles>().isTutorial;

        }
        if (!isTutorial)
        {
            StartCoroutine(DestroyPlatform(instantiated));
        }
    }

    private IEnumerator DestroyPlatform(GameObject instantiated)
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(instantiated);
    }
}
