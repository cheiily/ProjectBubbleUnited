using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class ShopScript : MonoBehaviour
{
    public GameObject[] radars, turets, houses, greenHouses;
    public GameObject sphere;
    public int money;
    [SerializeField]
    private float waitTime;
    private float timer;
    private int zarabianing;
    public TMP_Text moneyDisplay;


    private void Start()
    {
        timer = 0;
        zarabianing = 1;
        money = 0;
        moneyDisplay.text = money.ToString();
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            timer = 0;
            money += zarabianing;
            moneyDisplay.text = money.ToString();
        }
    }


    public void BuyHouse()
    {
        if (money >= 5)
        {
            foreach (GameObject house in houses)
            {
                if (!house.active)
                {
                    money -= 5;
                    zarabianing++;
                    house.active = true;
                    moneyDisplay.text = money.ToString();
                    break;
                }
            }
        }
    }

    public void BuyGreenhous()
    {
        if (money >= 5)
        {
            foreach (GameObject greenHouse in greenHouses)
            {
                if (!greenHouse.active)
                {
                    money -= 5;
                    sphere.GetComponent<SphereScript>().growSpeed += 5;
                    greenHouse.active = true;
                    moneyDisplay.text = money.ToString();
                    break;
                }
            }
        }
    }

    public void BuyTuret()
    {
        if (money >= 5)
        {
            foreach (GameObject turetr in turets)
            {
                if (!turetr.active)
                {
                    money -= 5;
                    turetr.active = true;
                    moneyDisplay.text = money.ToString();
                    break;
                }
            }
        }
    }

    public void BuyRadar()
    {
        if (money >= 5)
        {
            foreach (GameObject radar in radars)
            {
                if (!radar.active)
                {
                    money -= 5;
                    radar.active = true;
                    moneyDisplay.text = money.ToString();
                    break;
                }
            }
        }
    }

    public void LoseHouse()
    {
        zarabianing--;
    }

    public void LoseGreenhous()
    {
        sphere.GetComponent<SphereScript>().growSpeed -= 5;
    }
}
