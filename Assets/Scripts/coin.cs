using System;
using UnityEngine;

public class coin : MonoBehaviour
{ 
    public int CoinValue = 10;
    public static event Action<coin> CoinPickUp;
    public PlayerSoundController playerSoundController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CoinPickUp?.Invoke(this);
            Destroy(gameObject);
            playerSoundController.playCoin();
    }
  
}
