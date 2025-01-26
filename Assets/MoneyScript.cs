using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    public Text moneyAmount;

    public int money = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyAmount.text = "Money: " + money.toString();
    }

    // Update is called once per frame
    void Update()
    {
        int temp = 120
        if (temp > 0)
        {
            temp -= 1;       
        } else
        {
            temp = 120;
            money += 1;
        }
    }
}
