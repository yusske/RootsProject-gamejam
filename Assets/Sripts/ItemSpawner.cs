using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject checkpointPrefab;
    [SerializeField] int checkpointDelay=10;
    [SerializeField] int powerUpDelay=10;
    [SerializeField] float spawnRadius =10;
    [SerializeField] GameObject[] powerUpPrefab;

    void Start()
    {
        StartCoroutine(SpawnPowerUp());
    }

     IEnumerator SpawnCheckpoint()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkpointDelay);
            Vector2 randomPos = (Vector2)transform.position + Random.insideUnitCircle*spawnRadius ;
            Instantiate(checkpointPrefab, randomPos, Quaternion.identity);
        }
    }

     IEnumerator SpawnPowerUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUpDelay);
            Vector2 randomPos = (Vector2)transform.position + Random.insideUnitCircle*spawnRadius;
            int randomPower = Random.Range(0,powerUpPrefab.Length);
            Instantiate(powerUpPrefab[randomPower], randomPos, Quaternion.identity);
        }
    }
}
