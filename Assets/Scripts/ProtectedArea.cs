using UnityEngine;
using UnityEngine.Events;

public class ProtectedArea : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private UnityEvent _event = new UnityEvent();

    private void Update()
    {
        _event.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _signaling.Activate();
            _event.AddListener(_signaling.AcivateSound);
            _event.RemoveListener(_signaling.DisableSound);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _event.AddListener(_signaling.DisableSound);
            _event.RemoveListener(_signaling.AcivateSound);
        }
    }
}
