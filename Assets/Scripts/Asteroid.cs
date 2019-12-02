using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 3.0f;
    [SerializeField]
    private GameObject _explosionPrefab;
    private Player _player;
private SpawnManager _spawnManager;
    void Start()
    {
       _player = GameObject.FindWithTag("Player").GetComponent<Player>();
       _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
       _spawnManager.StopSpawning();
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
       DestroyAsteroid(other); 
            if (_player)
            {
           _player.GetComponent<Player>().SetScore(10); 
            }

        }

        if (other.tag == "Player")
        {
            if (_player != null)
            {
            _player.SetScore(5);
                _player.Damage();
            }
        }
    }

    private void DestroyAsteroid(Collider2D other){
            Instantiate(_explosionPrefab,transform.position,Quaternion.identity);
            Destroy(this.gameObject,0.25f);
            Destroy(other.gameObject);
            _spawnManager.StartSpawning();
 
    }

}
