using System.Collections;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }
    IEnumerator SpawnNewEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            float random = Random.Range(0.0f, 1.0f);
            if (random < GameManager.Instance.gameDifficulty * 0.1f)
            {
                Instantiate(enemyPrefab[0]);
                Instantiate(enemyPrefab[1]);
            }
            else
            {
                Instantiate(enemyPrefab[1]);
                Instantiate(enemyPrefab[0]);

            }
        }

    }
}
