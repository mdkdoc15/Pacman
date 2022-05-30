using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnDeath;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            // TODO health should be managed here, pass event around with amount of lives left
            OnDeath?.Invoke();
        }
    }
    
    
}
