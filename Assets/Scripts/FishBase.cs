using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBase : MonoBehaviour
{
    [SerializeField] Sprite[] idleSprites;
    [SerializeField] Sprite[] moveSprites;
    [SerializeField] float speedAnimation = 10;
    [SerializeField] ParticleController particleController;
    private float spriteIndex;
    Sprite[] actualSpritesArr;
    private SpriteRenderer spriteRenderer;
    private Coroutine fightAnim;
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
    public void AttackVisual()
    {
        particleController.PlayParticleSystem();
        if(fightAnim != null) return;        
        StartCoroutine(AttackAnimationCoroutine());
    }
    private IEnumerator AttackAnimationCoroutine()
    {
        int repeat = 8;
        while (repeat > 0)
        {
            repeat--;
            float zRot = Random.Range(-5, 5);
            transform.rotation = Quaternion.Euler(0,0,zRot);
            yield return new WaitForSeconds(0.04f);
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
