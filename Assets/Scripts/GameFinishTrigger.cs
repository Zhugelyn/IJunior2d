using UnityEngine;
using UnityEngine.Events;

public class GameFinishTrigger : MonoBehaviour
{
    [SerializeField] private EndPoint _endpoint;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _endpoint.Reached += OnEndPointReached;
    }

    private void OnDisable()
    {
        _endpoint.Reached += OnEndPointReached;
    }

    private void OnEndPointReached()
    {
        if (_endpoint.IsReached)
            Debug.Log("Finish");
    }
}
