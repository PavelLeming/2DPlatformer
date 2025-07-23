using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private InputReader _inputReader;

    private void FixedUpdate()
    {
        _mover.Move(_inputReader.HorizontalMove);

        if (_inputReader.GetIsJump())
        {
            _mover.Jump();
        }
    }
}
