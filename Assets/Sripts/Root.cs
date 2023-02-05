using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
        transform.position = player.position;
        transform.rotation = player.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
