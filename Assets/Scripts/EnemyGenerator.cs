using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Enemy _template;
    [SerializeField] private int _direction = -1;

    private void Start()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        int generateDelay = 2;
        var waitForSecond = new WaitForSeconds(generateDelay);
        bool isGenerate = true;

        while (isGenerate)
        {
            int minIndex = 0;
            int maxIndex = _spawnPoints.Count;
            int index = Random.Range(minIndex, maxIndex);
            Enemy enemy = Instantiate(_template, _spawnPoints[index].transform.position, Quaternion.identity);
            enemy.Init(_direction);

            yield return waitForSecond;
        }
    }
}