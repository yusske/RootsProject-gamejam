using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] int health = 1;
    [SerializeField] int scorePoints = 100;
    
    Transform player;
    

    // Start is called before the first frame update
    [System.Obsolete]
    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("Spawnpoint");
        int randomSpawnPoint = Random.RandomRange(0,spawnPoints.Length);
        transform.position = spawnPoints[randomSpawnPoint].transform.position;
    }
    private void Update()
    {
       
    }
    public void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            GameManager.Instance.Score+= scorePoints;
            Destroy(gameObject);
        }
    }
  private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage();
        }
    }

}
