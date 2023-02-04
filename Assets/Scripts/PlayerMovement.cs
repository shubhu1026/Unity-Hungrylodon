using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float dashForce = 10f;
    
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
        ProcessInput();
        RotateSprite();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(movementVector * dashForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate() 
    {
        rb2d.AddForce(movementVector * moveSpeed);
    }

    void ProcessInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movementVector = new Vector2(horizontalInput, verticalInput);
    }

    void RotateSprite()
    {
        //if moving right and looking left
        if(horizontalInput >= 0 && Mathf.Sign(transform.localScale.x) > 0)
        {
            Vector3 currentScale;
            currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;
        }
        //if moving left and looking right
        else if(horizontalInput < 0 && Mathf.Sign(transform.localScale.x) < 0)
        {
           Vector3 currentScale;
            currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;
        }
    }
}
