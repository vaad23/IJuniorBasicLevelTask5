using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    [SerializeField] private Transform _spawnBorder;
     [SerializeField] private Ground _prefab;
    [SerializeField] private GroundTracking _onLeft;

    private List<Ground> _poolGrounds;
    private Ground _lastActive;
    
    private void OnEnable()
    {
        _onLeft.TriggerEnterGroundEvent += OnTriggerEnterGround;
    }

    private void OnDisable()
    {
        _onLeft.TriggerEnterGroundEvent -= OnTriggerEnterGround;           
    }

    private void OnTriggerEnterGround(Ground ground)
    {
        _poolGrounds.Add(ground);
        ground.gameObject.SetActive(false);
        EnableGrounds(false);
    }

    private void Start()
    {
        CreateStartLocation();
    }

    private void CreateStartLocation()
    {
        _poolGrounds = new List<Ground>();

        EnableGrounds(true);
    }

    private void CreateGround()
    {
        Ground ground = Instantiate(_prefab, transform);
        _poolGrounds.Add(ground);
        ground.gameObject.SetActive(false);
    }

    private void EnableGrounds(bool defaultValue)
    {
        while (_spawnBorder.transform.position.x > _spawn.position.x)
        {
            if (_poolGrounds.Count == 0)
                CreateGround();

            Ground ground = _poolGrounds[0];
            ground.gameObject.SetActive(true);
            _poolGrounds.Remove(ground);
            ground.transform.position = _spawn.position;
            _spawn.position += new Vector3(1, 0);

            if (!defaultValue)
                ground.Enable(_lastActive);

            _lastActive = ground;
        }
    }    
}
