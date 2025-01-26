using TMPro;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    private float timer;
    [HideInInspector]
    public int zarabianing;
    public TMP_Text moneyDisplay;
    public int money;
    [SerializeField]
    private float waitTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
        zarabianing = 1;
        money = 0;
        moneyDisplay.text = "$" + money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            timer = 0;
            money += zarabianing;
            moneyDisplay.text = "$" + money.ToString();
        }
    }
}
