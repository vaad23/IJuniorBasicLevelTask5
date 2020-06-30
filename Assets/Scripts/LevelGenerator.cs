using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    [SerializeField] private Transform _spawnBorder;
    [SerializeField] private Ground _template;
    [SerializeField] private GroundTracking _destroyer;

    private List<Ground> _poolGrounds;
    private Ground _lastActive;
    
    private void OnEnable()
    {
        _destroyer.EnteredGround += OnEnteredGround;
    }

    private void OnDisable()
    {
        _destroyer.EnteredGround -= OnEnteredGround;           
    }

    private void OnEnteredGround(Ground ground)
    {
        _poolGrounds.Add(ground);
        ground.gameObject.SetActive(false);
        EnableGrounds(true);
    }

    private void Start()
    {
        CreateStartLocation();
    }

    private void CreateStartLocation()
    {
        _poolGrounds = new List<Ground>();

        EnableGrounds(false);
    }

    private void CreateGround()
    {
        Ground ground = Instantiate(_template, transform);
        _poolGrounds.Add(ground);
        ground.gameObject.SetActive(false);
    }

    private void EnableGrounds(bool isBonusActivate)
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

            if (isBonusActivate)
                ground.Enable(_lastActive);

            _lastActive = ground;
        }
    }    
}
