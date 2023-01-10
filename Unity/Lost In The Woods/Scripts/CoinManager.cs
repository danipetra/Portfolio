using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
public class CoinManager : MonoBehaviour
{
    public TMP_Text coinsText;
    public TMP_Text totalCoinsText;

    public int coinGrabbedOnCurrentRound;
    public int totalCoinAmount;


    public bool totalCoinsIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("TotalCoins"))
        {
            totalCoinAmount = PlayerPrefs.GetInt("TotalCoins");
        }
        totalCoinsIncreasing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (coinsText)
        {
            updateGrabbedCoins();
        }
        if (totalCoinsText)
        {
            updateTotalCoinsEarned();
        }
    }

    private void updateGrabbedCoins()
    {

        coinsText.text = "Coins: " + coinGrabbedOnCurrentRound;

    }

    private void updateTotalCoinsEarned()
    {
        totalCoinsText.text = "Total Coins: " + totalCoinAmount;
    }

    public void saveCoinsGrabbedOnLastRound()
    {
        totalCoinAmount += coinGrabbedOnCurrentRound;
        PlayerPrefs.SetInt("TotalCoins", totalCoinAmount);
        coinGrabbedOnCurrentRound = 0;
    }

    public void GrabCoin(int coinsToAdd)
    {
        coinGrabbedOnCurrentRound += coinsToAdd;
    }
}

