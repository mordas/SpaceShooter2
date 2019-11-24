using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    private IEnumerator _corutine;
    [SerializeField]
    private GameObject _enemyContrainer;

    private bool _stopSpawning = false;

    void Start()
    {
        _corutine = SpawnRutine(5);
        StartCoroutine(_corutine);
    }

    void Update()
    {
    }

    IEnumerator SpawnRutine(float time)
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemy, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContrainer.transform;
            yield return new WaitForSeconds(time);
        }
    }

    public void OnPlyerDeath()
    {
        _stopSpawning = true;
    }
}