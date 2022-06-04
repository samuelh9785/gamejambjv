using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    public PlayerInputManager manager;
    public GameObject[] players;
    public InputActionAsset asset;
    public CameraController cameraScript;
    //public UnityEvent<PlayerInput> unEvent = default;
    public int index = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnPlayerJoined()
    {
        if(manager.playerCount == 2)
        {
           GameObject[] currentPlayer = GameObject.FindGameObjectsWithTag("Player");
            Debug.Log(currentPlayer.Length);
            
            for (int i = 0; i < currentPlayer.Length; i++)
            {
                cameraScript._targets.Add(currentPlayer[i].transform);

            }

            Character player1 = currentPlayer[0].GetComponent<Character>();
            Character player2 = currentPlayer[1].GetComponent<Character>();

            player1.OtherPlayer = player2.transform;
            player2.OtherPlayer = player1.transform;
        }
    }

}
