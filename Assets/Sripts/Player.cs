using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    float vertical, horizontal;
    [SerializeField] float lockHorizontal;
    [SerializeField] float lockVertical;
    Vector3 moveDirection;
    public float speed = 1;
    [SerializeField] Transform aim;
    [SerializeField] new Camera camera;
    Vector2 facingDirection;
    [SerializeField] Transform bulletPrefab;
    [SerializeField] int health = 3;
    [SerializeField] bool isSlow;
    [SerializeField] float slowRate = 0.1f;
    [SerializeField] int extraPoints = 500;
    [SerializeField] float stepper = 0.1f;

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
        StartCoroutine(move());
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
        yield return new WaitForSeconds(1);

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if(horizontal != 0 && lockHorizontal==0)
        {
            lockHorizontal = Mathf.Sign(horizontal)* stepper;
            lockVertical= 0;
        } else if(vertical < 0 && lockVertical == 0){
            lockHorizontal = 0;
            lockVertical = Mathf.Sign(vertical) * stepper;
        }
        moveDirection.x = lockHorizontal;
        moveDirection.y = lockVertical;
        if(isSlow){
            transform.position += moveDirection * Time.deltaTime * ((speed+ GameManager.Instance.gameDifficulty) * slowRate);
            
        } else{

            transform.position += moveDirection * Time.deltaTime * (speed + GameManager.Instance.gameDifficulty) ;
                    
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
