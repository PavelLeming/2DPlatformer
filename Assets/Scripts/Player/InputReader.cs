using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InputReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string Jump = "Jump";

    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerAnimator _playerAnimator;

    public float HorizontalMove { get; private set; } = 0;
    public bool IsJump { get; private set; }

    private void Update()
    {
        HorizontalMove = Input.GetAxisRaw(HorizontalAxis);

        if (Input.GetButtonDown(Jump) && _groundDetector.IsGround())
        {
            IsJump = true;
        }
    }

    public bool GetIsJump()
    {
        bool value = IsJump;
        IsJump = false;
        return value;
    }
}
