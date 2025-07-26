using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void DoJumpAnimation(bool isGrounded, float yVelocity)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsGrounded, isGrounded);
        _animator.SetFloat(PlayerAnimatorData.Params.YSpeed, yVelocity);
    }

    public void DoRunAnimation(bool isRun)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRun, isRun);
    }
}
