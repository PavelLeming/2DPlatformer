using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private int _jumpForce = 300;
    private float _speed = 5f;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, _jumpForce));
    }

    public void Move(float horizontalMove)
    {
        _rigidbody.velocity = new Vector2(horizontalMove * _speed, _rigidbody.velocity.y);
    }
}
