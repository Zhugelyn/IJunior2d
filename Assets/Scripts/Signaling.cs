using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;
    private float _currentVolume = 0.0f;
    private float _fadeSpeed = 0.5f;

    public void AcivateSound()
    {
        ChangeSoundVolume(_currentVolume, _maxVolume, _fadeSpeed);
    }

    public void DisableSound()
    {
        ChangeSoundVolume(_currentVolume, _minVolume, _fadeSpeed);

        if (_currentVolume == 0)
        {
            _audioSource.Stop();
        }
    } 

    public void Activate()
    {
        _audioSource.Play();
    }

    private void ChangeSoundVolume(float _currentVolume, float requiredVolume, float fadeSpeed)
    {
        this._currentVolume = Mathf.MoveTowards(_currentVolume, requiredVolume, fadeSpeed * Time.deltaTime);
        _audioSource.volume = this._currentVolume;
    }
}
