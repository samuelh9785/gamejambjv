using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IInteractable
{
    public void Interaction(LaserBehaviour laser)
    {
        
        laser.isTouchedSomething = true;
        Debug.Log("MArche");
    }

    // Start is called before the first frame update
    
}
