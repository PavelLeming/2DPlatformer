using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InputReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string Jump = "Jump";
    private const int Attack = 0;
    private const int Vamire = 1;

    public float HorizontalMove { get; private set; } = 0;
    public bool IsJump { get; private set; }
    public bool IsAttack { get; private set; }
    public bool IsVampire { get; private set; }

    private void Update()
    {
        HorizontalMove = Input.GetAxisRaw(HorizontalAxis);

        if (Input.GetButtonDown(Jump))
        {
            IsJump = true;
        }

        if (Input.GetMouseButtonDown(Attack))
        {
            IsAttack = true;
        }

        if (Input.GetMouseButtonDown(Vamire))
        {
            IsVampire = true;
        }
    }

    public bool GetIsJump()
    {
        bool value = IsJump;
        IsJump = false;
        return value;
    }

    public bool GetIsAttack()
    {
        bool value = IsAttack;
        IsAttack = false;
        return value;
    }

    public bool GetIsVampire()
    {
        bool value = IsVampire;
        IsVampire = false;
        return value;
    }
}
