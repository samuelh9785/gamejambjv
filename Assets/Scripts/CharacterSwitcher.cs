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
    //public UnityEvent<PlayerInput> unEvent = default;
    public int index = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    
    public void OnSwitchCharacter()
    {
        index = index + 1;
        manager.playerPrefab = players[index];
        
        
        Debug.Log("LETS GO");
    }

    /*public void OnSwitch(PlayerInput input)
    {
        manager.playerPrefab = players[index];
        index = index + 1;
    }

    public void Move()
    {
        
    }*/
    
}
