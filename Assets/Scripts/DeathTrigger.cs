using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public static Action OnDeath;
    public PlayerSoundController playerSoundController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
        playerSoundController.playDeath();

    }
    private void Die()
    {
        OnDeath?.Invoke();
    }
}
