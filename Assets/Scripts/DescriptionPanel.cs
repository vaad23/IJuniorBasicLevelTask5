using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DescriptionPanel : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        _animator.SetBool("IsOpen", true);
    }

    public void Close()
    {
        _animator.SetBool("IsOpen", false);
    }
}
