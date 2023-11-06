using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health { get; private set; } = 100;

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
