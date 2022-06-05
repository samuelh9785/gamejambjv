using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public Cristal[] allCristals;
    public GameObject ending;
    //public GameObject[] players;
    //public CharacterSwitcher playerList;
    public bool allTouched;
    public bool isInPosition;
    private bool finishActive = false;
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
        if (finishActive) return;

        allTouched = true;

        for (int i = 0; i < allCristals.Length; i++)
        {
            if (allCristals[i].isTouched == false)
            {
                allTouched = false;
 
            }
        }

        if (allTouched)
        {
            finishActive = true;
            ending.SetActive(true);
            Debug.Log("VICTOIRRREEEE");
        }

    }


}
