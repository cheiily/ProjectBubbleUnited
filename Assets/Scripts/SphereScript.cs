using NUnit.Framework.Constraints;
using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SphereScript : MonoBehaviour
{
    private Vector3 beginScale;
    public bool isGrowing;
    public float growSpeed, minimalSize, finishedSize;
    public GameObject winRing, loseRing, pivot, shop;
    public TMP_Text showSize;
    public List<GameObject> wyrwa;

    public GameObject winCanvas, loseCanvas;

    private void Start()
    {
        winRing.transform.localScale += new Vector3(finishedSize, finishedSize, finishedSize);
        loseRing.transform.localScale -= new Vector3(minimalSize, minimalSize, minimalSize);
        beginScale = pivot.transform.localScale;
    }
    
    void Update()
    {
        
        if (growSpeed>0)
        {
            if (pivot.transform.localScale.y < beginScale.y+finishedSize)
            {
                showSize.text = ((int)(pivot.transform.localScale.x - minimalSize)).ToString()+"/"+((int)(beginScale.x + finishedSize)).ToString();
                pivot.transform.localScale = Vector3.MoveTowards(pivot.transform.localScale, beginScale + new Vector3(finishedSize, finishedSize, finishedSize), growSpeed * Time.deltaTime);
                //transform.localScale += scaleChang;
            } else {
                winCanvas.SetActive(true);
            }
        }
        else if(growSpeed<0)
        {
            showSize.text = ((int)(pivot.transform.localScale.x - minimalSize)).ToString() + "/" + ((int)(beginScale.x + finishedSize)).ToString();
            pivot.transform.localScale = Vector3.MoveTowards(pivot.transform.localScale, beginScale - new Vector3(minimalSize, minimalSize, minimalSize), -growSpeed * Time.deltaTime);
            //transform.localScale -= scaleChang;
            if (pivot.transform.localScale.y < beginScale.y - minimalSize + 2f)
            {
                loseCanvas.SetActive(true);
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

    public void Repair(GameObject sphereBreak)
    {
        foreach (GameObject checkBreak in wyrwa)
        {
            if (sphereBreak == checkBreak)
            {
                wyrwa.Remove(checkBreak);
                Destroy(sphereBreak);
                growSpeed += 10;
                break;
            }
        }
    }
}
