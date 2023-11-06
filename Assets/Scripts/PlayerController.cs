using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed = 2;
    [SerializeField] private float _forceValue = 200;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime * -1, Space.World);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.W))
            _rigidbody2D.AddForce(Vector2.up * _forceValue);
    }
}
