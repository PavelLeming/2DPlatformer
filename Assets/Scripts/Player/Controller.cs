using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private InputReactioner _inputReactioner;

    private void FixedUpdate()
    {
        _mover.Move(_inputReactioner._horizontalMove);

        if (_inputReactioner.GetIsJump())
        {
            _mover.Jump();
        }
    }
}
