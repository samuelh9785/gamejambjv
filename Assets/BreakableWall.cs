using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour, IInteractable
{
    
    public void Interaction(LaserBehaviour laser)
    {
        laser.isTouchedSomething = true;
    }

    public void StopInteraction(LaserBehaviour laser)
    {
        laser.isTouchedSomething = false;
    }

    // Start is called before the first frame update
   
}
