using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    float originalSpeed;
    Player player;
    [SerializeField] float speedReduction;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        originalSpeed = player.speed;
    }

   private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            player.speed*= speedReduction;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        player.speed = originalSpeed;
    }
}
