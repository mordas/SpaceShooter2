using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _speed = 4f;
    [SerializeField] private GameObject _player;

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
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
            Destroy(this.gameObject);
            if (_player)
            {
           _player.GetComponent<Player>().SetScore(10); 
            }
        }

        if (other.tag == "Player")
        {
            Debug.Log("Collider player");
            Destroy(this.gameObject);
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
            player.SetScore(5);
                player.Damage();
            }
        }
    }
}