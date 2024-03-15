using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class TestWaves : MonoBehaviour
{
    private WaveSpawner _waveSpawner;
    private EnemySpawnerWave _enemySpawnerWave;
    [SerializeField] Animator _animator;
    private EnemyController _enemyController;
    private void Awake()
    {
        _waveSpawner = GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<WaveSpawner>();
        _enemySpawnerWave = GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<EnemySpawnerWave>();
        _enemyController = GetComponent<EnemyController>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            _animator.SetBool("_isDeath",true);
            _enemyController.enabled = false;
            _enemySpawnerWave.enemyCount--;
            if (_enemySpawnerWave.enemyCount==0)
            {
                Debug.Log("Victory!");    
            }

            StartCoroutine(Death());
        }
    }

    /*
    private void OnDestroy()
    {
        int enemiesLeft = 0;
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemiesLeft == 0)
        {
            _waveSpawner.LaunchWave();
        }
    }
    */

    IEnumerator Death()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
