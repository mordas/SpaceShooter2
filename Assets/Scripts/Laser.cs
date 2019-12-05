using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _laserSpeed = 10f;
    private bool _isEnemyLaser = false;

    void Update()
    {
        if (!_isEnemyLaser)
        {
           MoveUp(); 
        }
        else
        {
            MoveDown();
        }

    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _laserSpeed);
        if (transform.position.y > 8f)
        {
            
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
            Destroy(this.gameObject);
            
        }
    }
    void MoveDown()
    
         {
             transform.Translate(Vector3.down * Time.deltaTime * _laserSpeed);
             if (transform.position.y < -4f)
             {
                 
             if (transform.parent != null)
             {
                 Destroy(transform.parent.gameObject);
             }
                 Destroy(this.gameObject);
                 
             }
         }

    public void AssignEnemyLaser()
    {
        _isEnemyLaser = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && _isEnemyLaser)
        {
           other.gameObject.GetComponent<Player>().Damage(); 
        }
    }
}