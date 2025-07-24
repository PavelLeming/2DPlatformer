using UnityEngine;

public class Flipper : MonoBehaviour
{
    public void Flip(bool isFacingRight)
    {
        if (isFacingRight)
        {
            transform.rotation = Quaternion.AngleAxis(180f, Vector3.up);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }
    }
}
