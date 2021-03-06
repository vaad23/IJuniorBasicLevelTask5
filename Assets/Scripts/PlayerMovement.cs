﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GroundTracking _underfoot;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private bool _isfinish;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _isfinish = false;
    }

    private void Update()
    {
        if (_isfinish)
            return;

        transform.Translate(_speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            if (_underfoot.IsGround)
                _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void Finish()
    {
        _isfinish = true;
    }
}
