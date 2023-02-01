using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    
    Rigidbody2D rb2d;

    float horizontalInput;
    float verticalInput;

    Vector2 movementVector;

    // Start is called before the first frame update
    void Awake() 
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.Space))
        {
            verticalInput = 1;
        }
        else
        {
            verticalInput = 0;
        }

        movementVector = new Vector2(horizontalInput, verticalInput);
    }

    void FixedUpdate() 
    {
        rb2d.AddForce(movementVector * moveSpeed);
    }
}
