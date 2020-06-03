using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    [SerializeField] private Ground _prefab;
    [SerializeField] private GroundTracking _onLeft;
    [SerializeField] private GroundTracking _onRight;

    private List<Ground> _poolGrounds;
    private List<Ground> _allGrounds;
    private Ground _lastActive;

    public event UnityAction CoinFoundEvent;

    private void OnEnable()
    {
        _onLeft.TriggerEnterGroundEvent += OnTriggerEnterGround;
        _onRight.TriggerExitGroundEvent += OnTriggerExitGroundEvent;
    }

    private void OnDisable()
    {
        _onLeft.TriggerEnterGroundEvent -= OnTriggerEnterGround;
        _onRight.TriggerExitGroundEvent -= OnTriggerExitGroundEvent;

        foreach (var ground in _allGrounds)
            ground.CoinFoundEvent -= OnCoinFound;       
    }

    private void OnTriggerEnterGround(Ground ground)
    {
        _poolGrounds.Add(ground);
        ground.gameObject.SetActive(false);
    }

    private void OnTriggerExitGroundEvent()
    {
        EnableGrounds(false);
    }

    private void Start()
    {
        CreateStartLocation();
    }

    private void CreateStartLocation()
    {
        _poolGrounds = new List<Ground>();
        _allGrounds = new List<Ground>();

        EnableGrounds(true);
    }

    private void CreateGround()
    {
        Ground ground = Instantiate(_prefab, transform);
        _poolGrounds.Add(ground);
        _allGrounds.Add(ground);
        ground.CoinFoundEvent += OnCoinFound;
        ground.gameObject.SetActive(false);
    }

    private void EnableGrounds(bool defaultValue)
    {
        while (_onRight.transform.position.x > _spawn.position.x)
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

    private void OnCoinFound()
    {
        CoinFoundEvent?.Invoke();
    }
}
