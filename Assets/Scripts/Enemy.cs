using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage = 35;
    [SerializeField] private float _speed = 2;
    
    private int _direction;

    public void Init(int direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        gameObject.transform.Translate(new Vector3(_speed, 0, 0) * Time.deltaTime * _direction, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_damage);

            if (player.Health <= 0)
                Destroy(player.gameObject);
        }
    }
}
