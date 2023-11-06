using UnityEngine;
using UnityEngine.EventSystems;

public class Splike : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private int _forceValue;

    public void OnPointerClick(PointerEventData eventData)
    {
        _rigidbody.AddForce(Vector2.up * _forceValue);
    }
}
