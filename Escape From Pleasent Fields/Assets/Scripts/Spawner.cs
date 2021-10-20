using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float _spawnTimer;
    private float _spawnTime;
    [SerializeField]
    private GameObject _nurse;

    [SerializeField] private Transform _spawnPosition;
    // Start is called before the first frame update
    void Start()
    {

        _spawnTime = _spawnTimer;

    }

    // Update is called once per frame
    void Update()
    {
        _spawnTime = _spawnTime - Time.deltaTime;
        if (_spawnTime < 0)
        {
            GameObject ble = GameObject.Instantiate(_nurse,gameObject.transform);
            ble.transform.position = _spawnPosition.position;
            _spawnTime = _spawnTimer;
        }

    }
}
