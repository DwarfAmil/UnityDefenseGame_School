using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyPrefab;
    [SerializeField] private float _timeBetweenWaves = 5;
    [SerializeField] private Transform _spawnPoint;
    private float _countdown = 2;
    private int _waveIndex;

    private void Update()
    {
        if (_countdown <= 0)
        {
            StartCoroutine(nameof(SpawnWave));
            _countdown = _timeBetweenWaves;
        }

        _countdown -= Time.deltaTime;
    }

    private IEnumerator SpawnWave()
    {
        _waveIndex++;
        
        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy(/*GameObject enemy*/)
    {
        Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
