using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Obstacle
{
    [SerializeField] private ObstacleDamager _damager;

    private GameObject _activeObject;

    public enum Type
    {
        None = 0,
        Damager = 1
    }

    public void Init(Type type)
    {
        if (_activeObject != null)
            Disable();

        switch (type)
        {
            case Type.Damager:
                _activeObject = _damager.gameObject;
                _activeObject.SetActive(true);
                break;
        }
    }

    public void Disable()
    {
        if (_activeObject == null)
            return;

        _activeObject.SetActive(false);
        _activeObject = null;        
    }
}
