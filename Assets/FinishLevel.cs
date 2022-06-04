using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public Cristal[] allCristals;
    public bool allTouched;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkCristal();
    }

    public void checkCristal()
    {
        allTouched = true;

        for (int i = 0; i < allCristals.Length; i++)
        {
            if (allCristals[i].isTouched == false)
            {
                allTouched = false;
 
            }
        }

        if(allTouched)
            Debug.Log("VICTOIRRREEEE");
    }
}
