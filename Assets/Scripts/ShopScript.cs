using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class ShopScript : MonoBehaviour
{
    public GameObject[] radars, turets, houses, greenHouses;
    public GameObject sphere, money;

    public void BuyHouse()
    {
        if (money.GetComponent<MoneyScript>().money >= 5)
        {
            foreach (GameObject house in houses)
            {
                if (!house.active)
                {
                    money.GetComponent<MoneyScript>().money -= 5;
                    money.GetComponent<MoneyScript>().zarabianing++;
                    house.active = true;
                    money.GetComponent<MoneyScript>().moneyDisplay.text = "$" + money.ToString();
                    break;
                }
            }
        }
    }

    public void BuyGreenhous()
    {
        if (money.GetComponent<MoneyScript>().money >= 5)
        {
            foreach (GameObject greenHouse in greenHouses)
            {
                if (!greenHouse.active)
                {
                    money.GetComponent<MoneyScript>().money -= 5;
                    sphere.GetComponent<SphereScript>().growSpeed += 5;
                    greenHouse.active = true;
                    money.GetComponent<MoneyScript>().moneyDisplay.text = "$" + money.ToString();
                    break;
                }
            }
        }
    }

    public void BuyTuret()
    {
        if (money.GetComponent<MoneyScript>().money >= 5)
        {
            foreach (GameObject turetr in turets)
            {
                if (!turetr.active)
                {
                    money.GetComponent<MoneyScript>().money -= 5;
                    turetr.active = true;
                    money.GetComponent<MoneyScript>().moneyDisplay.text = "$" + money.ToString();
                    break;
                }
            }
        }
    }

    public void BuyRadar()
    {
        if (money.GetComponent<MoneyScript>().money >= 5)
        {
            foreach (GameObject radar in radars)
            {
                if (!radar.active)
                {
                    money.GetComponent<MoneyScript>().money -= 5;
                    radar.active = true;
                    money.GetComponent<MoneyScript>().moneyDisplay.text = "$" + money.ToString();
                    break;
                }
            }
        }
    }

    public void LoseHouse()
    {
        money.GetComponent<MoneyScript>().zarabianing--;
    }

    public void LoseGreenhous()
    {
        sphere.GetComponent<SphereScript>().growSpeed -= 5;
    }
}
