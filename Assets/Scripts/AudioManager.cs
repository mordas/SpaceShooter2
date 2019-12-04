using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _explosionSound;
    [SerializeField] private AudioSource _powerupSound;

    public void PlayExplosionSound()
    {
    _explosionSound.Play();
    }

    public void PlayPowerupSound()
    {
        _powerupSound.Play();
    }
}
