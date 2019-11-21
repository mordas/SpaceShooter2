using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _laserSpeed = 10f;
        

    void Update()
    {
       transform.Translate(Vector3.up * Time.deltaTime * _laserSpeed); 
       if(transform.position.y >8f)
           Destroy(this.gameObject);
    }
}
