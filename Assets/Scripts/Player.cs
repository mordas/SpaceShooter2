using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Transform _trippleLaser;
    [SerializeField] private Transform _laser;
    [SerializeField] private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField] private int _lives = 3;
    private SpawnManager _spawnManager;
    private bool _trippleShot = false;
    private float _previosSpeed;
    private bool _isBoostActive = false;
    private bool _shieldActive = false;
    private UI_Manager _uiManager;
    private GameManager _gameManager;

    [SerializeField] private int score = 0;

    [SerializeField] private Transform _shieldPrefab;

    [SerializeField] private Transform _rightEngine;
    [SerializeField] private Transform _leftEngine;
    [SerializeField] private AudioSource _laserAudio;
    void Start()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if(!_gameManager.isCoop){
        transform.position = new Vector3(0, 0, 0);
        }
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.Log("The spawn manager is NULL");
        }

        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        if (_uiManager == null)
        {
            Debug.Log("UI manager is NULL");
        }
    }

    void Update()
    {
        CalculateMovement();


        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0f), 0);
        if (transform.position.x >= 11)
        {
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
        else if (transform.position.x <= -11)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;
        if (_trippleShot == false)
        {
            Instantiate(_laser, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }
        else if (_trippleShot == true)
        {
            Instantiate(_trippleLaser, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }
        _laserAudio.Play();
        
    }

    public void Damage()
    {
        if (!_shieldActive)
        {
            _lives -= 1;
            if (_lives == 2)
            {
                _rightEngine.gameObject.SetActive(true);
            }
            else if (_lives == 1 )
            {
                Debug.Log("Last Life");
                _leftEngine.gameObject.SetActive(true);
            }
            else if (_lives < 1)
            {
                _spawnManager.OnPlyerDeath();
                _uiManager.ShowGameOverText();
                _gameManager.GameOver();
                Destroy(this.gameObject);
            }
        }
        _uiManager.UpdateLives(_lives);
    }

    public void SetTrippleShot()
    {
        _trippleShot = true;
        StartCoroutine(setTrippleShotDown(5));
    }

    IEnumerator setTrippleShotDown(float time)
    {
        yield return new WaitForSeconds(time);
        _trippleShot = false;
    }

    public void SetSpeedPowerUp()
    {
        _previosSpeed = _speed;
        _speed = _speed * 2;
        _isBoostActive = true;
        StartCoroutine(SetSpeedPowerUpDown());
    }

    IEnumerator SetSpeedPowerUpDown()
    {
        yield return new WaitForSeconds(5);
        _speed = _previosSpeed;
        _isBoostActive = false;
    }

    public void SetShieldActive()
    {
        _shieldActive = true;
        StartCoroutine(SetShieldDown());
        _shieldPrefab.gameObject.SetActive(true);
    }

    IEnumerator SetShieldDown()
    {
        yield return new WaitForSeconds(5);
        _shieldActive = false;
        _shieldPrefab.gameObject.SetActive(false);
    }

    public void SetScore(int s)
    {
        score += s;
        _uiManager.UpdateScore(score);
    }

  

}