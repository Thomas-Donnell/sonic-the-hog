using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathFloor : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.LoseLife(); // Call LoseLife from GameManager
            player.transform.position = respawnPoint.position;
        }

    }


}