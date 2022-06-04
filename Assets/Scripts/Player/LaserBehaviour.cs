using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour, IInteractable
{
    public static bool isTouchedOtherLaser = false;
    public bool isTouchedSomething = false;
    
    [SerializeField] private float laserSpeed = 2f;
    private float currentSize = 0;

    private const string PLAYER_TAG = "Player";
    private const string INTERACTABLE_TAG = "Interactable";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        if(collision.CompareTag(PLAYER_TAG) || collision.CompareTag(INTERACTABLE_TAG))
            collision.GetComponent<IInteractable>().Interaction(this);
    }

    public void ShootLaser()
    {
        if(!isTouchedOtherLaser && !isTouchedSomething)
        {
            transform.localScale = new Vector3(currentSize, transform.localScale.y, 1);
            currentSize += Time.deltaTime * laserSpeed;
        }
    }

    public void ResetLaser()
    {
        transform.localScale = new Vector3(0, transform.localScale.y, 1);
    }

    public void Interaction(LaserBehaviour laser)
    {
        isTouchedOtherLaser = true;
    }

    void IInteractable.StopInteraction(LaserBehaviour laser)
    {
        throw new System.NotImplementedException();
    }
}
