using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _speed = 4f;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemyLaser;
    private GameObject _audioManager;
    private Animator _deadAnim;
    private float _fireRate=3.0f;
    private float _canFire = -1;
    void Start()
    {    _audioManager = GameObject.Find("Audio_Manager");
        if (_audioManager == null)
        {
            Debug.Log("Audio manager is null");
        }
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Debug.Log("Player is null");
        }
        _deadAnim = gameObject.GetComponent<Animator>();
        if (_deadAnim == null)
        {
            Debug.Log("Anim is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
CalculateMovement();

if (Time.time > _canFire)
{
    _fireRate = Random.Range(3f, 7f);
    _canFire = Time.time + _fireRate;
GameObject enemyLaser = Instantiate(_enemyLaser, transform.position, Quaternion.identity);
Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();
foreach (var laser in lasers)
{
   laser.AssignEnemyLaser(); 
}

}

    }

    private void CalculateMovement()
    {
         transform.Translate(Vector3.down * _speed * Time.deltaTime);
         if (transform.position.y < -5)
         {
             float randomX = Random.Range(-8f, 8f);
             transform.position = new Vector3(randomX, 5, 0);
         }       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collider 1");
        if (other.tag == "Laser")
        {
           Destroy(other.gameObject);
//            Destroy(this.gameObject);
            //_deadAnim.SetBool("isDestroy",true);
            StartCoroutine(enemyDestroy());
            if (_player)
            {
           _player.GetComponent<Player>().SetScore(10); 
            }
        }

        if (other.tag == "Player")
        {
            StartCoroutine(enemyDestroy());
//            _deadAnim.SetBool("isDestroy",true);
//            Destroy(this.gameObject);
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
            player.SetScore(5);
                player.Damage();
            }
        }
    }

    IEnumerator enemyDestroy()
    {
        _speed = 0.5f;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
            _deadAnim.SetBool("isDestroy",true);
            _audioManager.GetComponent<AudioManager>().PlayExplosionSound();
            yield return new WaitForSeconds(1);
    }
}