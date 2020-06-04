using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class GroundTracking : MonoBehaviour
{
    private int _countGrounds;

    public bool IsGround { get; private set; }
    public int CountGrounds
    {
        get
        {
            return _countGrounds;
        }
        private set
        {
            _countGrounds = Mathf.Clamp(value, 0, int.MaxValue);

            if (_countGrounds == 0)
            {
                if (IsGround)
                    IsGround = false;
            }
            else
            {
                if (!IsGround)
                    IsGround = true;
            }
        }
    }

    public event UnityAction<Ground> TriggerEnterGroundEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ground ground))
        {
            TriggerEnterGroundEvent?.Invoke(ground);
            CountGrounds++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ground ground))
            CountGrounds--;
        
    }
}
