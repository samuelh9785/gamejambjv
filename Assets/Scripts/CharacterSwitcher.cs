using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    public PlayerInputManager manager;
    public List<GameObject> players = new List<GameObject>();
    //public UnityEvent<PlayerInput> unEvent = default;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    
    public void OnSwitchCharacter()
    {
        manager.playerPrefab = players[index];
        index = index + 1;
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
