using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 5;
    [SerializeField] float health = 3;
    public bool isPowerShot;

    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage();
            if (!isPowerShot)
                Destroy(gameObject);
            health--;
            if (health <= 0)
                Destroy(gameObject);

        }
    }
}
