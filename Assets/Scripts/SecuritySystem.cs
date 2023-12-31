using UnityEngine;
using UnityEngine.Events;

public class SecuritySystem : MonoBehaviour
{
    private bool _isInside = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isInside = false;
        }
    }
}
