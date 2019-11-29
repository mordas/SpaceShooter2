using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private int _powerupID;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player)
            {
                switch (_powerupID)
                {
                    case 0:
                        player.SetTrippleShot();
                        break;
                    case 1:
                        player.SetSpeedPowerUp();
                        break;
                    case 2:
                        player.SetShieldActive();
                        break;
                    default:
                        Debug.Log("Default");
                        break;
                }
            }

            Destroy(gameObject);
        }
    }
}