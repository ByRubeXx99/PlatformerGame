using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public static Action OnDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }

    private void Die()
    {
        // Invoke any method subscribed to the OnDeath event
        OnDeath?.Invoke();
    }
}
