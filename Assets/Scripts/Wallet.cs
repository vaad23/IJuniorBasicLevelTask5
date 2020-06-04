using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    [SerializeField] private LevelGeneration _levelGeneration;
    [SerializeField] private Text _amountCoins;

    private int _amount;

    public void AddCoin()
    {
        _amount++;
        _amountCoins.text = _amount.ToString();
    }

    private void OnEnable()
    {
        _amountCoins.text = _amount.ToString();
    }

    private void OnDisable()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            if (PlayerPrefs.GetInt("Coins") < _amount)
                PlayerPrefs.SetInt("Coins", _amount);
        }
        else
        {
            PlayerPrefs.SetInt("Coins", _amount);
        }        
    }
}
