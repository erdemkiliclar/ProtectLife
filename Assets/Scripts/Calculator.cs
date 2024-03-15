using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{

    public int enemyEscape;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyEscape++;
            if (enemyEscape>=5)
            {
                TinySauce.OnGameFinished(0);
                Debug.Log("Hop hemşerim nereye");
            }
        }
    }
}
