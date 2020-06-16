using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class GroundTracking : MonoBehaviour
{
    private int _countGrounds;

    public bool IsGround => _countGrounds > 0;
    
    public event UnityAction<Ground> EnteredGround;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ground ground))
        {
            EnteredGround?.Invoke(ground);
            _countGrounds++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ground ground))
            _countGrounds--;        
    }
}
