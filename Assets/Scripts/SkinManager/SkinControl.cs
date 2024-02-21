using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinControll : MonoBehaviour
{
    public int skinNum;
    public Button buyButton;
    public int price;

    public Image[] skins;

    public TextMeshProUGUI buyTextButton;

    public CoinsShop coinShop;

    private AudioSource audioSource;
    public AudioClip buySound;
    public AudioClip buttonSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            buyTextButton.text = price.ToString();
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            buyTextButton.text = "EQUIP";
            if (PlayerPrefs.GetInt(GetComponent<Image>().name + "EQUIP") == 1)
            {
                buyTextButton.text = "EQUIPPED";
            }
            else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "EQUIP") == 0)
            {
                buyTextButton.text = "EQUIP";
            }
        }

        coinShop.UpdateMoneyText();
    }
    public void Buy()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            if (coinShop.money >= price)
            {
                coinShop.money -= price; 
                PlayerPrefs.SetFloat("Coin", coinShop.money); 
                PlayerPrefs.Save();
                audioSource.PlayOneShot(buySound);
                PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 1);
                PlayerPrefs.SetInt("skinNum", skinNum);

                foreach (Image img in skins)
                {
                    if (GetComponent<Image>().name == img.name)
                    {
                        PlayerPrefs.SetInt(GetComponent<Image>().name + "EQUIP", 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt(img.name + "EQUIP", 0);
                    }
                }
            }
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {

            PlayerPrefs.SetInt(GetComponent<Image>().name + "EQUIP", 1);
            PlayerPrefs.SetInt("skinNum", skinNum);

            foreach (Image img in skins)
            {
                if (GetComponent<Image>().name == img.name)
                {
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "EQUIP", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(img.name + "EQUIP", 0);
                }
            }
        }
    }
}
