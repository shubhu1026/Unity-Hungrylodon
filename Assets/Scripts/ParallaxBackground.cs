using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private const float backgroundSpeedModifier = 0.005f;
    [SerializeField] SpriteRenderer[] backgrounds;
    [SerializeField] Vector2 speed = Vector2.right;
    Vector2[] offsets;
    private void Awake() {
        offsets = new Vector2[backgrounds.Length];
    }
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            offsets[i] += (Time.deltaTime * speed * SystemSetup.Instance.gameSpeed) * backgroundSpeedModifier * i;
            offsets[i] = new Vector2(offsets[i].x % 1, offsets[i].y % 1);
            backgrounds[i].material.mainTextureOffset = offsets[i];
        }
        
    }
}
