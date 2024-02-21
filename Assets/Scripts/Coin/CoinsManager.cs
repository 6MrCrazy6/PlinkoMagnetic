using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    public float money;
    public float amount = 100;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Coin"))
            money = 2000;
        else
            money = PlayerPrefs.GetFloat("Coin");

        UpdateMoneyText();
    }

    private void Update()
    {
        UpdateMoneyText();
    }

    public void AddMoney(float amountToAdd)
    {
        money += amountToAdd;
        UpdateMoneyText(); 
    }

    private void UpdateMoneyText()
    {
        if (moneyText != null)
            moneyText.text = money + " / " + amount.ToString();
        else
            Debug.LogWarning("MoneyText не назначен в инспекторе!");
    }

}
