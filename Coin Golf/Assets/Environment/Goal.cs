using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    bool containsPlayer;
    CoinController player;
    bool lastStroke = false;

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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CoinController>();
    }
    private void Update()
    {
        if (!player.IsMoving())
        {
            if (containsPlayer)
            {
                GameManager.Instance.Win();
                containsPlayer = false;
            }
            else
            {
                if (lastStroke)
                {
                    GameManager.Instance.Lose();
                }
                else if (GameManager.Instance.OutOfStrokes())
                {
                    StartCoroutine(setLastStroke());
                }
            } 
        }
    }

    IEnumerator setLastStroke()
    {
        yield return new WaitForSeconds(0.1f);
        lastStroke = true;
    }
}
