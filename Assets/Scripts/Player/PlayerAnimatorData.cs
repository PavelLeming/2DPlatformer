using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorData : MonoBehaviour
{
    public static class Params
    {
        public static readonly int IsRun = Animator.StringToHash(nameof(IsRun));
        public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
        public static readonly int YSpeed = Animator.StringToHash(nameof(YSpeed));
    }
}
