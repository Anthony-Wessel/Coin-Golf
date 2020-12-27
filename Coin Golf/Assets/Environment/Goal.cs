using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    bool containsPlayer;
    Rigidbody playerRB;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
            containsPlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
            containsPlayer = false;
    }

    private void Start()
    {
        containsPlayer = false;
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (containsPlayer)
        {
            if (playerRB.velocity.magnitude == 0)
            {
                GameManager.Win();
                containsPlayer = false;
            }
                
        }
    }
}
