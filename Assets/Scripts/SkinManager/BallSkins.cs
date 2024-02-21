using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSkins : MonoBehaviour
{
    public Sprite standart;
    public Sprite skin1;
    public Sprite skin2;
    public Sprite skin3;
    public Sprite skin4;
    public Sprite skin5;
    public GameObject Ball;
    void Start()
    {
        if (PlayerPrefs.GetInt("skinNum") == 1)
        {
            Ball.GetComponent<Image>().sprite = skin1;
        }
        else if (PlayerPrefs.GetInt("skinNum") == 2)
        {
            Ball.GetComponent<Image>().sprite = skin2;
        }
        else if (PlayerPrefs.GetInt("skinNum") == 3)
        {
            Ball.GetComponent<Image>().sprite = skin3;
        }
        else if (PlayerPrefs.GetInt("skinNum") == 4)
        {
            Ball.GetComponent<Image>().sprite = skin4;
        }
        else if (PlayerPrefs.GetInt("skinNum") == 5)
        {
            Ball.GetComponent<Image>().sprite = skin5;
        }
        else
        {
            Ball.GetComponent<Image>().sprite = standart;
        }
    }

}
