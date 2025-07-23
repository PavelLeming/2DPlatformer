using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InputReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string Jump = "Jump";

    public float HorizontalMove { get; private set; } = 0;
    public bool IsJump { get; private set; }

    private void Update()
    {
        HorizontalMove = Input.GetAxisRaw(HorizontalAxis);

        if (Input.GetButtonDown(Jump))
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
