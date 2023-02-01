using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    float xRange = 30f;
    float yRange = 20f;

    bool isOutOfBounds = false;

    Vector3 currentPosition;

    // Update is called once per frame
    void Update()
    {
        isOutOfBounds = CheckIfOutOfBounds();
        if(isOutOfBounds)
        {
            Destroy(gameObject);
        }
    }

    bool CheckIfOutOfBounds()
    {
        currentPosition = transform.position;
        if(currentPosition.x > xRange || currentPosition.x < -xRange || currentPosition.y > yRange || currentPosition.y < -yRange)
        {
            return true;
        }
        return false;
    }
}
