using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Weapon: MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _shootInterval;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(ShootBullets());
    }

    private IEnumerator ShootBullets()
    {
        while (enabled)
        {
            var direction = (_target.position - transform.position).normalized;
            var bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            var bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.transform.up = direction;
            bulletRigidbody.velocity = direction * _speed;

            yield return new WaitForSeconds(_shootInterval);
        }
    }
}