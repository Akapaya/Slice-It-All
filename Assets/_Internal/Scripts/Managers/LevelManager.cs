using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;

    [SerializeField] private int _quantityObstacles;


    private void Awake()
    {
        for (int i = 1; i < _quantityObstacles; i++)
        {
            Instantiate(_obstaclePrefab, this.transform.position - (new Vector3(Random.Range(5, 10), 0,0)*i), Quaternion.identity);
        }
    }
}
