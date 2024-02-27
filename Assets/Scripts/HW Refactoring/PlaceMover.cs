using UnityEngine;

public class PlaceMover: MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _placesPoint;
    private Transform[] _places;
    private int _currentPlaceIndex;

    private void Start()
    {
        _places = new Transform[_placesPoint.childCount];

        for (int i = 0; i < _placesPoint.childCount; i++)
        {
            _places[i] = _placesPoint.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        var _place = _places[_currentPlaceIndex];
        transform.position = Vector3.MoveTowards(transform.position, _place.position, _speed * Time.deltaTime);

        if (transform.position == _place.position)
        {
            UpdateNextPlaceLogic();
        }
    }

    private void UpdateNextPlaceLogic()
    {
        _currentPlaceIndex++;

        if (_currentPlaceIndex == _places.Length)
        {
            _currentPlaceIndex = 0;
        }
    }
}