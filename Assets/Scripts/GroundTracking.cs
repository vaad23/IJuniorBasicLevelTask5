using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class GroundTracking : MonoBehaviour
{
    private int _countGrounds;
    
    public int CountGrounds
    {
        get
        {
            return _countGrounds;
        }
        private set
        {
            _countGrounds = Mathf.Clamp(value, 0, int.MaxValue);
        }
    }

    public event UnityAction<Ground> EnteredGround;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ground ground))
        {
            EnteredGround?.Invoke(ground);
            CountGrounds++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ground ground))
            CountGrounds--;
        
    }
}
