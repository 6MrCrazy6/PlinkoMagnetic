using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeysMechanic : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI cointext;

    public GameObject panelYouGot;
    public GameObject panelShop;
    
    public CoinsShop coinsShop;
    private bool buttonCooldown = false;
    private DateTime nextCaseTime;

    private void Awake()
    {
        LoadNextCaseTime();
    }

    public void OpenKeys()
    {
        if (buttonCooldown)
        {
            return;
        }

        panelShop.SetActive(false);
        panelYouGot.SetActive(true);
        int coinsEarned = UnityEngine.Random.Range(100, 1001);
        coinsShop.money += coinsEarned;
        PlayerPrefs.SetFloat("Coin", coinsShop.money);
        PlayerPrefs.Save();

        cointext.text = coinsEarned.ToString();
        buttonCooldown = true;
        button.interactable = false;
        coinsShop.UpdateMoneyText();

        nextCaseTime = DateTime.Now.AddHours(1);
        SaveNextCaseTime();
        StartCoroutine(UpdateButtonTime());
    }

    private void SaveNextCaseTime()
    {

        PlayerPrefs.SetString("NextCaseTime", nextCaseTime.ToString());
        PlayerPrefs.Save();
    }

    private void LoadNextCaseTime()
    {
        if (PlayerPrefs.HasKey("NextCaseTime"))
        {
            string nextCaseTimeString = PlayerPrefs.GetString("NextCaseTime");
            nextCaseTime = DateTime.Parse(nextCaseTimeString);
            StartCoroutine(UpdateButtonTime());
            buttonCooldown = true;
            button.interactable = false;
        }
        else
        {
            buttonCooldown = false;
            button.interactable = true;
        }
    }

    private IEnumerator UpdateButtonTime()
    {
        TimeSpan remainingTime = nextCaseTime - DateTime.Now;
        if (remainingTime.TotalSeconds > 0)
        {
            string timeString = string.Format("{0:00}:{1:00}:{2:00}", remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);
            buttonText.text = timeString;
            button.interactable = false;
            yield return new WaitForSeconds(1f);
            yield return StartCoroutine(UpdateButtonTime()); 
        }
        else
        {
            yield return StartCoroutine(ButtonCooldown());
        }
    }

    private IEnumerator ButtonCooldown()
    {
        yield return new WaitForSeconds(1f);
        buttonCooldown = false;
        button.interactable = true;
        buttonText.text = "OPEN";
        yield break;
    }
}
