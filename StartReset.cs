using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartReset : MonoBehaviour
{
    public GameObject spawn, player;
    void Start()
    {
        player.transform.position = spawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
