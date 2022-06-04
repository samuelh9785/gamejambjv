using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristal : MonoBehaviour , IInteractable
{
    public bool isTouched;
    public void Interaction(LaserBehaviour laser)
    {
        
        isTouched = true;
    }

    public void StopInteraction(LaserBehaviour laser)
    {
        
        isTouched = false;
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
