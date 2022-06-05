using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristal : MonoBehaviour , IInteractable
{
    public bool isTouched;
    public FinishLevel finish;
    public void Interaction(LaserBehaviour laser)
    {
        //if (shake != null) shake.Stop().Reset().Play();
        //else shake = new Shake(this, child, shakeSetting, true).Play();
        if(laser.isTouchedOtherLaser)
            isTouched = true;
        
        //finish.checkCristal();
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
