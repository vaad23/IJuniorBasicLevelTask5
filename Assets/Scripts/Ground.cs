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
    
    public void Enable(Ground previous)
    {
        int chance = Random.Range(0, 100);

        if (previous._coin.gameObject.activeSelf)
        {
            if (_chanceReCoin > chance)
                _coin.gameObject.SetActive(true);
        }
        else
        {
            if(_chanceCoin > chance)
                _coin.gameObject.SetActive(true);
            else if(_chanceCoin + _chanceObstacle > chance)
                _obstacle.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if (_coin.gameObject.activeSelf)
            _coin.gameObject.SetActive(false);

        if (_obstacle.gameObject.activeSelf)
            _obstacle.gameObject.SetActive(false);
        
    }
}
