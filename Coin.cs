using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMovement playerMovement;
    int value = 10;
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * 5);
    }

    void OnCollisionEnter(Collision playerHit)
    {
       if (playerHit.transform.tag == "Player")
        {
            PlayerMovement.score += value;
            Destroy(this.gameObject);
        } 
    }
}
