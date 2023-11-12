using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage = 35;
    [SerializeField] private float _speed = 2;

    private GameObject _target;

    public void Init(Player player)
    {
        if (player == null)
        {
            throw new System.ArgumentNullException(nameof(player));
        }

        _target = player.gameObject;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = (_target.transform.position - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);
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
