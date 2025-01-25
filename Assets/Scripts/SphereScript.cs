using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    private Vector3 beginPosition, beginScale;
    public Transform planetPosition;
    public Vector3 scaleChang = new Vector3(0.01f, 0.01f, 0.01f);
    public bool isGrowing;
    public float moveSpeed, growSpeed, tolerance;


    private void Start()
    {
        beginPosition = transform.position;
        beginScale = transform.localScale;
    }
    
    void Update()
    {
        
        if (isGrowing)
        {
            transform.position = Vector3.MoveTowards(transform.position, planetPosition.position, moveSpeed * Time.deltaTime);
            transform.localScale = Vector3.MoveTowards(transform.localScale, planetPosition.localScale, growSpeed * Time.deltaTime);
            //transform.localScale += scaleChang;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, beginPosition, moveSpeed * Time.deltaTime);
            transform.localScale = Vector3.MoveTowards(transform.localScale, beginScale - new Vector3(0.6f, 0.6f, 0.6f), growSpeed * Time.deltaTime);
            //transform.localScale -= scaleChang;
            if (transform.localScale.y < beginScale.y -0.5f)
            {
                Debug.Log("Booom");
                Debug.Log(transform.localScale);
                isGrowing = true;
            }
        }
    }
}
