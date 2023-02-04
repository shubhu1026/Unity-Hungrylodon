using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBase : MonoBehaviour
{
    [SerializeField] Sprite[] idleSprites;
    [SerializeField] Sprite[] moveSprites;
    [SerializeField] float speedAnimation = 10;
    private float spriteIndex;
    Sprite[] actualSpritesArr;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        actualSpritesArr = moveSprites;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        spriteIndex += speedAnimation * Time.deltaTime;
        int index = (int)spriteIndex % actualSpritesArr.Length;
        spriteRenderer.sprite = actualSpritesArr[index];
    }
}
