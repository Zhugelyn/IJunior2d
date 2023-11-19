using UnityEngine;

public class ProtectedArea : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private bool _isInside = false;

    private void Update()
    {
        if (_isInside)
            _signaling.AcivateSound();
        else
            _signaling.DisableSound();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _signaling.Activate();
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
