using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToSpawn;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float maxTime = 5;
    [SerializeField] private float minTime = 2;

    private float time;
    private float spawnTime;

    void Start()
    {
        SetRandomTime();
        time = 0;
        //SpawnObject();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
            time = 0;
        }
    }

    private void SpawnObject()
    {
        if (objectsToSpawn.Count == 0) return;

        int randomIndex = Random.Range(0, objectsToSpawn.Count);
        GameObject spawnedObject = Instantiate(objectsToSpawn[randomIndex], spawnPoint.position, Quaternion.identity);
        objectsToSpawn.RemoveAt(randomIndex);

        // Play audio clip at the spawn point
        AudioClip clip = spawnedObject.GetComponent<AudioSource>().clip;
        float volume = spawnedObject.GetComponent<AudioSource>().volume;
        AudioSource.PlayClipAtPoint(clip, spawnPoint.position, volume);
    }

    private void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}
