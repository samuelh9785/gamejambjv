using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour, IInteractable
{
    public bool explode;
    public GameObject player;
    public List<GameObject> objectInRange = new List<GameObject>();
    public bool inRange;
    public int life;

    public void Interaction(LaserBehaviour laser)
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        if(inRange == true)
        {

        }
            for(int i =0; i < objectInRange.Count; i++)
            {
                objectInRange[i].SetActive(false);
                
            }
        gameObject.SetActive(false);
        Debug.Log("Zouhhhh");
        
        
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
