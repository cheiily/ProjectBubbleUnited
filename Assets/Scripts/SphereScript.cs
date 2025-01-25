using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    private Vector3 beginScale;
    public Vector3 scaleChang = new Vector3(0.01f, 0.01f, 0.01f);
    public bool isGrowing;
    public float growSpeed, minimalSize, finishedSize;


    private void Start()
    {
        beginScale = transform.localScale;
    }
    
    void Update()
    {
        
        if (isGrowing)
        {
            if (transform.localScale.y < beginScale.y+finishedSize)
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale, beginScale + new Vector3(finishedSize, finishedSize, finishedSize), growSpeed * Time.deltaTime);
                //transform.localScale += scaleChang;
            }
        }
        else
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, beginScale - new Vector3(minimalSize, minimalSize, minimalSize), growSpeed * Time.deltaTime);
            //transform.localScale -= scaleChang;
            if (transform.localScale.y > beginScale.y - minimalSize)
            {
                Debug.Log("Booom");
                Debug.Log(transform.localScale);
                isGrowing = true;
            }
        }
    }
}
