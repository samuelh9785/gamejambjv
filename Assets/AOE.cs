using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    public TNT tNT;
    // Start is called before the first frame update
    void Start()
    {
        tNT = gameObject.GetComponentInParent<TNT>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            Debug.Log(other.name);
            tNT.inRange = true;
            tNT.playerInRange = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            tNT.inRange = false;
           
        }
    }
}
