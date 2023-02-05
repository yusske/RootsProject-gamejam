using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsSpawnController : MonoBehaviour
{
     [SerializeField] GameObject[] rootPrefabs;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        StartCoroutine(SpawnRoots());
    }

 IEnumerator SpawnRoots()
   {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            int random =  Random.Range(0, rootPrefabs.Length-1);
            Instantiate(rootPrefabs[random]);
        }

    }
    // Update is called once per frame
    void Update()
    {
    
    }
}
