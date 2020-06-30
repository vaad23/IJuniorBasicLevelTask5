using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _player;

    private float _distanceX;

    private void Awake()
    {
        _distanceX = _camera.position.x - _player.position.x;
    }

    private void Update()
    {
        _camera.position = new Vector3(_distanceX + _player.position.x, _camera.position.y, _camera.position.z);
    }
}
