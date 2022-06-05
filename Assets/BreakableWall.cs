using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour, IInteractable
{
    
    public void Interaction(LaserBehaviour laser)
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void StopInteraction(LaserBehaviour laser)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
