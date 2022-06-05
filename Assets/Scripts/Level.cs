using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform spawnPlayer1 = default;
    [SerializeField] private Transform spawnPlayer2 = default;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if(players.Length == 2)
        {
            players[0].transform.position = players[0].GetComponent<Character>().spawnPos = spawnPlayer1.position;
            players[1].transform.position = players[1].GetComponent<Character>().spawnPos = spawnPlayer2.position;
        }
    }
}
