using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public GameObject ballPrefab;
    public CoinsManager coinsManager;
    
    public void SpawnBall()
    {
        if (coinsManager.money >= coinsManager.amount)
        {
            coinsManager.money -= coinsManager.amount;
            PlayerPrefs.SetFloat("Coin", coinsManager.money);
            PlayerPrefs.Save();
            CreateNewBall();
        }
        else
        {
            Debug.Log("У вас недостаточно денег");
            Debug.Log("Current coin value: " + PlayerPrefs.GetFloat("Coin"));
        }
    }

    void CreateNewBall()
    {
        GameObject parentObject = GameObject.Find("GameBallsSpawn");
        Vector3 spawnPosition = new Vector3(0f, -14f, 0f);
        GameObject newBall = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
        newBall.transform.SetParent(parentObject.transform, false);
        newBall.GetComponent<BallControl>().canMove = true;
    }
}
