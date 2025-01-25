using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    private Vector3 beginScale;
    public Vector3 scaleChang = new Vector3(0.01f, 0.01f, 0.01f);
    public bool isGrowing;
    public float growSpeed, minimalSize, finishedSize;
    public GameObject winRing, loseRing, pivot, shop;


    private void Start()
    {
        winRing.transform.localScale += new Vector3(finishedSize, finishedSize, finishedSize);
        loseRing.transform.localScale -= new Vector3(minimalSize, minimalSize, minimalSize);
        beginScale = pivot.transform.localScale;
    }
    
    void Update()
    {
        
        if (isGrowing)
        {
            if (pivot.transform.localScale.y < beginScale.y+finishedSize)
            {
                pivot.transform.localScale = Vector3.MoveTowards(pivot.transform.localScale, beginScale + new Vector3(finishedSize, finishedSize, finishedSize), growSpeed * Time.deltaTime);
                //transform.localScale += scaleChang;
            }
        }
        else
        {
            pivot.transform.localScale = Vector3.MoveTowards(pivot.transform.localScale, beginScale - new Vector3(minimalSize, minimalSize, minimalSize), growSpeed * Time.deltaTime);
            //transform.localScale -= scaleChang;
            if (pivot.transform.localScale.y < beginScale.y - minimalSize + 2f)
            {
                Debug.Log("Booom");
                //Debug.Log(pivot.transform.localScale);
                //isGrowing = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.SetActive(false);
        if (other.tag == "House")
            shop.GetComponent<ShopScript>().LoseHouse();
        else if (other.tag == "Greenhouse")
            shop.GetComponent<ShopScript>().LoseGreenhous();

    }
}
