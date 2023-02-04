using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFish : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;

    bool shouldMoveLeft = false;

    void Start()
    {
        if(transform.position.x > 0)
        {
            shouldMoveLeft = true;
        }
        else
        {
            shouldMoveLeft = false; 
        }
    }

    void Update()
    {
        if(shouldMoveLeft)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    // Rigidbody2D rb2d;

    // Vector3 movementVector;

    // void Awake() 
    // {
    //     rb2d = GetComponent<Rigidbody2D>();
    // }

    // void Start()
    // {
    //     //if spawned on left side, fish should move right or if spawned on right side, they should move left
    //     if(transform.position.x > 0)
    //     {
    //         movementVector = Vector2.right * -1;
    //     }
    //     else
    //     {
    //         movementVector = Vector2.right;  
    //     }
    // }

    // void Update()
    // {
    //     rb2d.AddForce(movementVector * moveSpeed);
    // }
}
