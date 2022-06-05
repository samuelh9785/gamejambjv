using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform otherPlayer = default;
    [SerializeField] private LaserBehaviour laser = default;
    [SerializeField] private PlayerInput playerInput = default;
    public int health = 3;
    public Transform startPosition;
    public Vector3 death = new Vector3(0,0,0);
    public Vector3 normalState = new Vector3(1, 1, 1);
    public Vector3 decrement = new Vector3(0.7f, 0.7f, 0.7f);
    public Vector3 spawnPos = default;
    [SerializeField] private float timeChargeLaser = 2f;
    

    public Transform OtherPlayer
    {
        get => otherPlayer;
        set => otherPlayer = value;
    }

    private float timerLaser;
    private bool isShooting = false;

    private void Update()
    {
        if (LoadLaser()) laser.ShootLaser();
    }

    private bool LoadLaser()
    {
        if (isShooting)
        {
            if (timerLaser > timeChargeLaser)
                return true;
            else
            {
                timerLaser += Time.deltaTime;
                return false;
            }
        }

        laser.ResetLaser();
        timerLaser = 0;
        return false;
    }
    

    private void LateUpdate() 
    {
        if (otherPlayer == null) return;

        Vector3 diff = otherPlayer.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        float finalRotation = rot_z - 90;

        transform.rotation = Quaternion.Euler(0f, 0f, finalRotation);
    }


    void OnShoot()
    {
        Debug.Log("test on press");
        isShooting = true;
    }

    void OnShootRelease()
    {
        Debug.Log("test on release");
        isShooting = false;
    }

    public void Interaction(LaserBehaviour laser)
    {
        laser.isTouchedSomething = true;
    }

    public void StopInteraction(LaserBehaviour laser)
    {
        throw new System.NotImplementedException();
    }

    private Coroutine fall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Void")
        {
            //collision.gameObject.GetComponent<Character>().health = collision.gameObject.GetComponent<Character>().health - 1;
            health = health - 1;
            Debug.Log("HIT!!!");

            playerInput.DeactivateInput();

            if (fall != null) StopCoroutine(fall);
            fall = StartCoroutine(OnFall());
                
        }
    }

    IEnumerator OnFall()
    {
        while (gameObject.transform.localScale.x >= 0)
        {
            
            gameObject.transform.localScale -= decrement * Time.deltaTime;
            yield return null;
        }
        gameObject.transform.position = spawnPos;
        gameObject.transform.localScale = normalState;
        playerInput.ActivateInput();
    }
}
