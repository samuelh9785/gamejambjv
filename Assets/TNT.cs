using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour, IInteractable
{
    public bool explode;
    public GameObject playerInRange;
    public bool inRange;

    public void Interaction(LaserBehaviour laser)
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        if(inRange == true)
        {
            playerInRange.GetComponentInParent<Character>().health = playerInRange.GetComponentInParent<Character>().health - 2;
            Debug.Log("Zouhhhh");
        }
        
        
    }

    public void StopInteraction(LaserBehaviour laser)
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player");
        }
    }

}
