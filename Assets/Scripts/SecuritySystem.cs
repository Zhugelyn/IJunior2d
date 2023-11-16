using UnityEngine;
using UnityEngine.Events;

public class SecuritySystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;
    private float _currentVolume = 0.0f;
    private float _fadeSpeed = 0.5f;

    private bool _isInside = false;

    private void Update()
    {
        if (_isInside)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _maxVolume, _fadeSpeed * Time.deltaTime);
            _audioSource.volume = _currentVolume;
        }
        else
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _minVolume, _fadeSpeed * Time.deltaTime);
            _audioSource.volume = _currentVolume;
        }

        if (_currentVolume == 0)
        {
            _audioSource.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _audioSource.Play();
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
