using TMPro;
using UnityEngine;

public class CoinsShop : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    public float money;

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

    public void UpdateMoneyText()
    {
        if (moneyText != null)
            moneyText.text = money.ToString();
        else
            Debug.LogWarning("MoneyText не назначен в инспекторе!");
    }
}
