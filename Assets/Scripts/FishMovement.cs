using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    bool shouldMoveLeft = false;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {   
        Move();
        RotateSprite();
    }

    void Move()
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

    void RotateSprite()
    {
        if(shouldMoveLeft && Mathf.Sign(transform.localScale.x) < 0)
        {
            Vector3 currentScale;
            currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;
        }
        //if moving left and looking right
        else if(!shouldMoveLeft && Mathf.Sign(transform.localScale.x) > 0)
        {
            Vector3 currentScale;
            currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;
        }
    }
}
