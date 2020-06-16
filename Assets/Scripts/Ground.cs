using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Ground : MonoBehaviour
{
    [SerializeField] private float _chanceCreateObject; 
    [SerializeField] private float _significanceOfCoin;
    [SerializeField] private float _chanceReCoin;
    [SerializeField] private float _significanceOfObstacle;
    [SerializeField] private Coin _coin;
    [SerializeField] private Obstacle _obstacle;
    
    public void Enable(Ground previous)
    {
        if (previous._coin.gameObject.activeSelf)
        {
            if (_chanceReCoin > Random.Range(0, 100))
                _coin.gameObject.SetActive(true);
        }
        else
        {
            if (_chanceCreateObject > Random.Range(0, 100))
            {
                float maxSignificance = _significanceOfCoin + _significanceOfObstacle;
                float chance = Random.Range(0, maxSignificance);

                if (_significanceOfCoin > chance)
                    _coin.gameObject.SetActive(true);
                else
                    _obstacle.Init(Obstacle.Type.Damager);
            }
        }
    }

    private void OnDisable()
    {
        if (_coin.gameObject.activeSelf)
            _coin.gameObject.SetActive(false);

        _obstacle.Disable();        
    }
}
