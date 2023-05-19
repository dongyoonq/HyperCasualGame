using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeLineSpawner : MonoBehaviour
{
    public float spawnDelay;
    public GameObject pipePrefab;

    Coroutine spawnRoutine;

    private void OnEnable()
    {
        spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(spawnRoutine);
    }

    IEnumerator SpawnRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnDelay);
            Vector2 spawnPos = transform.position + Vector3.up * Random.Range(-1.4f, 1.9f);
            Instantiate(pipePrefab, spawnPos, transform.rotation);
        }
    }
}
