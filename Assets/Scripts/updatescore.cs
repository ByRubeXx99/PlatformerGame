using System;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    public int Score; 

    public static event Action <int> Update;
    private void OnEnable()
    {
        coin.CoinPickUp += Updatescore;
    }
    private void OnDisable()
    {
        coin.CoinPickUp -= Updatescore;
    }
    private void Updatescore(coin coin)
    {
        Score += coin.CoinValue;  
        Update?.Invoke(Score);
    }

}
