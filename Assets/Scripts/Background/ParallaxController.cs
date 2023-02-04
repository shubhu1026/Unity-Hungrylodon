using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    Transform cam;
    Vector3 camStartPos;
    float distance;
    
    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;

    float farthestBack;

    [Range(0.01f, 0.05f)]
    [SerializeField] float parallaxSpeed;

 
    void Start()
    {
        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for(int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
        } 
    }

    void CalculateBackgroundSpeed(int backCount)
    {
        for(int i = 0; i < backCount; i++)
        {
            if(backgrounds[i])
            {}
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
