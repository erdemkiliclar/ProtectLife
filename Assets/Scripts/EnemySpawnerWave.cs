using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerWave : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _waveCount = 5;
    [SerializeField] private int _enemiesPerWave = 10;
    [SerializeField] private float _spawnDelay = 1f;
    [SerializeField] private float _waveDelay = 3f;
    public int enemyCount;

    private int _currentWave = 0;
    private int _enemiesRemaining;

    private void Start()
    {
        TinySauce.OnGameStarted();
        _enemiesRemaining = _enemiesPerWave;

        StartNextWave();
        enemyCount = _waveCount * _enemiesPerWave;
    }

    private void StartNextWave()
    {
        _currentWave++;

        if (_currentWave > _waveCount)
        {
            Debug.Log("All waves completed!");
            return;
        }

        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < _enemiesPerWave; i++)
        {
            int prefabIndex = Random.Range(0, _enemyPrefabs.Length);
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

            Instantiate(_enemyPrefabs[prefabIndex], _spawnPoints[spawnPointIndex].position, Quaternion.identity);

            _enemiesRemaining--;

            if (_enemiesRemaining == 0)
            {
                yield return new WaitForSeconds(_spawnDelay);

                _enemiesRemaining = _enemiesPerWave;
            }
            else
            {
                yield return null;
            }
        }
        yield return new WaitForSeconds(_waveDelay);
        StartNextWave();
    }
}
