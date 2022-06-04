using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveInput;
    public float moveSpeed;
    public Rigidbody2D rb;
    //public PlayerInput input;
    public InputActionAsset inputAction;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<PlayerInput>().actions = inputAction;
        //gameObject.GetComponent<PlayerInput>().actions = inputAction;
    }

    // Update is called once per frame


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.deltaTime);
        
    }


    private void OnMovement(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnShoot()
    {
        
            Debug.Log("PERFORMED");
    }

    void OnShootRelease()
    {
        Debug.Log("RELEASE");
    }


}
