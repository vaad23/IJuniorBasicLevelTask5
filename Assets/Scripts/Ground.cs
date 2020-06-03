using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Ground : MonoBehaviour
{
    [SerializeField] private int _chanceCoin;
    [SerializeField] private int _chanceReCoin;
    [SerializeField] private Coin _coin;
    [SerializeField] private int _chanceObstacle;
    [SerializeField] private Obstacle _obstacle;

    public event UnityAction CoinFoundEvent;

    public void Enable(Ground previous)
    {
        int chance = Random.Range(0, 100);

        if (previous._coin.gameObject.activeSelf)
        {
            if (_chanceReCoin > chance)
            {
                _coin.gameObject.SetActive(true);
                _coin.CoinFoundEvent += OnCoinFound;
            }
        }
        else
        {
            if(_chanceCoin > chance)
            {
                _coin.gameObject.SetActive(true);
                _coin.CoinFoundEvent += OnCoinFound;
            }
            else if(_chanceCoin + _chanceObstacle > chance)
            {
                _obstacle.gameObject.SetActive(true);
                _obstacle.ObstacleFoundEvent += OnObstacleFound;
            }
        }
    }

    private void OnDisable()
    {
        if (_coin.gameObject.activeSelf)
        {
            _coin.CoinFoundEvent -= OnCoinFound;
            _coin.gameObject.SetActive(false);
        }

        if (_obstacle.gameObject.activeSelf)
        {
            _obstacle.ObstacleFoundEvent -= OnObstacleFound;
            _obstacle.gameObject.SetActive(false);
        }
    }

    private void OnCoinFound()
    {
        _coin.CoinFoundEvent -= OnCoinFound;
        _coin.gameObject.SetActive(false);
        CoinFoundEvent?.Invoke();
    }

    private void OnObstacleFound()
    {
        _obstacle.ObstacleFoundEvent -= OnObstacleFound;
    }
}
