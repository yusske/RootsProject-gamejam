using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    float vertical, horizontal;
    Vector3 moveDirection;
    public float speed = 3;
    public float vspSeed = 1.5f;
    [SerializeField] Transform aim;
    [SerializeField] new Camera camera;
    Vector2 facingDirection;
    [SerializeField] Transform bulletPrefab;
    [SerializeField] public float fireRate = 1;
    [SerializeField] int health = 10;
    [SerializeField] bool powerShotEnabled;
    [SerializeField] bool isInvulnerable;

    bool gunLoaded = true;
    public int Health {
        get => health;
        set { 
            health=value;
            UIManager.Instance.UpdateUIHealth(health);
        }
    }

    void Start()
    {
        UIManager.Instance.UpdateUIHealth(Health);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        moveDirection.x = horizontal;
        moveDirection.y = 0;
        transform.position += moveDirection * Time.deltaTime * speed;
        StartCoroutine(moveDown());
    }
    public void TakeDamage()
    {

        if (isInvulnerable)
            return;
        Health--;

        if (Health <= 0)
        {
            GameManager.Instance.gameOver = true;
            UIManager.Instance.ShowGameOverScreen();
        }
    }

    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1 / fireRate);
        gunLoaded = true;
    }

     IEnumerator moveDown()
    {
        yield return new WaitForSeconds(2);
        moveDirection.y = vspSeed;
        moveDirection.x = 0;
        transform.position -= moveDirection * Time.deltaTime;
    }

    IEnumerator Invulnerable()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(3);
        isInvulnerable = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            switch (other.GetComponent<PowerUp>().powerUpType)
            {
                case PowerUp.PowerUpType.FireRateIncrease:
                    fireRate++;
                    break;
                case PowerUp.PowerUpType.PowerShot:
                    powerShotEnabled = true;
                    break;
                case PowerUp.PowerUpType.Invulnerability:
                    StartCoroutine(Invulnerable());
                    break;
            }
            Destroy(other.gameObject, 0.1f);

        }
    }
}
