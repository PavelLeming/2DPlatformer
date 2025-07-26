using UnityEngine;

public class Flipper : MonoBehaviour
{
    private float _deagreeOfRotation = 180f;

    public void Flip(bool isFacingRight)
    {
        if (isFacingRight)
        {
            transform.rotation = Quaternion.AngleAxis(_deagreeOfRotation, Vector3.up);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }
    }
}
