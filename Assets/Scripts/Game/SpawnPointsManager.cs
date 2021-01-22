using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsManager : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<Transform> platformPrefabs;
    internal List<Transform> platformsOnScene;
    // Start is called before the first frame update
    void Awake()
    {
        platformsOnScene = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatform();
    }

    private void SpawnPlatform()
    {
        System.Random rnd = new System.Random();

        Debug.Log("Count: " + platformsOnScene.Count);
        if (platformsOnScene.Count <= 0)
        {
            var platform = platformPrefabs[rnd.Next(0, platformPrefabs.Count-1)];
            var spawnPoint = spawnPoints[rnd.Next(0, spawnPoints.Count-1)];
            var newPlatform = Instantiate(platform, spawnPoint.position, platform.rotation);
            platformsOnScene.Add(newPlatform);
        }
    }
}
