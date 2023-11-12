using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private Player _target;

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
            Enemy enemy = Instantiate(_template, transform.position, Quaternion.identity);
            enemy.Init(_target);

            yield return waitForSecond;
        }
    }
}