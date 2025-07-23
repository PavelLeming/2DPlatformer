using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void JumpAnimation(bool isGrounded, float yVelocity)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsGrounded, isGrounded);
        _animator.SetFloat(PlayerAnimatorData.Params.YSpeed, yVelocity);
    }

    public void RunAnimation(bool isRun)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRun, isRun);
    }
}
