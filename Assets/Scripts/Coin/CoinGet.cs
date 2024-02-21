using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGet : MonoBehaviour
{
    private CoinsManager coinsManager;

    private float getMoney;

    private void Start()
    {
        coinsManager = FindObjectOfType<CoinsManager>();
        if (coinsManager == null)
        {
            Debug.LogError("CoinsManager not found in the scene!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("1.7"))
        {
            getMoney = coinsManager.amount * 1.7f;
            coinsManager.money += getMoney;
            PlayerPrefs.SetFloat("Coin", coinsManager.money);
            PlayerPrefs.Save();
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("1.1"))
        {
            getMoney = coinsManager.amount * 1.1f;
            coinsManager.money += getMoney;
            PlayerPrefs.SetFloat("Coin", coinsManager.money);
            PlayerPrefs.Save();
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("0.5"))
        {
            getMoney = coinsManager.amount * 0.5f;
            coinsManager.money += getMoney;
            PlayerPrefs.SetFloat("Coin", coinsManager.money);
            PlayerPrefs.Save();
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}

