using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    float vertical, horizontal;
    [SerializeField] float lockHorizontal;
    [SerializeField] float lockVertical;
    Vector3 moveDirection;
    public float speed = 1.0f;
    [SerializeField] Transform aim;
    [SerializeField] new Camera camera;
    Vector2 facingDirection;
    [SerializeField] Transform bulletPrefab;
    [SerializeField] int health = 3;
    [SerializeField] bool isSlow;
    [SerializeField] float slowRate = 0.1f;
    [SerializeField] int extraPoints = 500;
     [SerializeField] GameObject[] rootPrefabs;
     [SerializeField] GameObject codito;

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
        StartCoroutine(move());

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    public void TakeDamage()
    {

        Health--;

        if (Health <= 0)
        {
            GameManager.Instance.gameOver = true;
            UIManager.Instance.ShowGameOverScreen();
        }
    }
     IEnumerator move()
    {
        while (true){
            yield return new WaitForSeconds(1.0f/GameManager.Instance.gameDifficulty);
        if(horizontal != 0 && lockHorizontal==0)
        {
            float sign = Mathf.Sign(horizontal);
            if(sign < 0.0){
                transform.rotation = Quaternion.Euler(new Vector3(0,0,-90));
            } 
            else {
                 transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
            }
            Instantiate(codito);
            lockHorizontal = sign;
            lockVertical= 0;
        } else if(vertical < 0 && lockVertical == 0){
            lockHorizontal = 0;
            lockVertical = -1;
             Instantiate(codito);
            transform.rotation = Quaternion.Euler(new Vector3(0,0,0));

        } else {
            int random =  Random.Range(0, 3);
            Instantiate(rootPrefabs[random]);
        }
        moveDirection.x = lockHorizontal;
        moveDirection.y = lockVertical;
        transform.position += moveDirection;
        }
    }

    IEnumerator Invulnerable()
    {
        isSlow = true;
        yield return new WaitForSeconds(3);
        isSlow = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            switch (other.GetComponent<PowerUp>().powerUpType)
            {
                case PowerUp.PowerUpType.IncreaseHealth:
                    if (health < 3)
                    {
                        health+=health;
                    }
                    //health+=;
                    break;
                case PowerUp.PowerUpType.ReduceSpeed:
                    //powerShotEnabled = true;
                    StartCoroutine(Invulnerable());
                    break;
                case PowerUp.PowerUpType.ExtraPoints:
                    GameManager.Instance.Score+= extraPoints;
                    break;
            }
            Destroy(other.gameObject, 0.1f);

        }
    }
}
