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

    void IInteractable.StopInteraction(LaserBehaviour laser)
    {
        
    }

    // Start is called before the first frame update

}
