using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    private IEnumerator _corutine;
    [SerializeField] private GameObject _enemyContrainer;

    private bool _stopSpawning = false;
[SerializeField]
    private GameObject[] powerups;

    void Start()
    {
    }

    public void StartSpawning(){
        StartCoroutine(SpawnEnemyRutine(5));
        StartCoroutine(TripplseShotSpawner());
    }
    public void StopSpawning(){
        StopCoroutine(SpawnEnemyRutine(5));
        StopCoroutine(TripplseShotSpawner());
    }


    IEnumerator SpawnEnemyRutine(float time)
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(3f);
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemy, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContrainer.transform;
            yield return new WaitForSeconds(time);
        }
    }

    IEnumerator TripplseShotSpawner()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(2f);
            float randomTime = Random.Range(3f, 8f);
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(powerups[Random.Range(0,powerups.Length)], posToSpawn, Quaternion.identity);
//            Instantiate(powerups[2], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(randomTime);
        }
    }

    public void OnPlyerDeath()
    {
        _stopSpawning = true;
    }
}