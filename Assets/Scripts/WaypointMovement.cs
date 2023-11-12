using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform path;

    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[path.childCount];
    }
}
