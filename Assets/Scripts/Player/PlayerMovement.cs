using System;
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

    public float movementSpeed = 0f;

    // Start is called before the first frame update
    void Awake() 
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        //CheckSpriteRotation();
        IfInvertControls();
        
        movementSpeed = moveSpeed * GameManager.gameInstance.MovementSpeedMultiplier;

        FlipSprite();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(movementVector * dashForce * GameManager.gameInstance.DashForceMultiplier, ForceMode2D.Impulse);
        }
    }

    void IfInvertControls()
    {
        if(GameManager.gameInstance.InvertControls)
        {
            movementVector *= -1;
        }
    }

    private void FlipSprite()
    {
        if(Mathf.Abs(movementVector.x) < float.Epsilon) return;
        float sign = Mathf.Sign(movementVector.x);
        Vector3 currentScale = transform.localScale;
        currentScale.x = - MathF.Abs(currentScale.x) * sign;
        transform.localScale = currentScale;
    }

    void FixedUpdate() 
    {
        rb2d.AddForce(movementVector * moveSpeed * GameManager.gameInstance.MovementSpeedMultiplier);
    }

    void ProcessInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movementVector = new Vector2(horizontalInput, verticalInput);
    }

    void CheckSpriteRotation()
    {
        //if moving right and looking left
        if(horizontalInput >= 0 && Mathf.Sign(transform.localScale.x) > 0)
        {
           RotateSprite();
        }
        //if moving left and looking right
        else if(horizontalInput < 0 && Mathf.Sign(transform.localScale.x) < 0)
        {
            RotateSprite();
        }
    }

    void RotateSprite()
    {
        Vector3 currentScale;
        currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}
