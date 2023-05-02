using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    private Transform _target;
    private int _wavePointIndex = 0;

    private void Start()
    {
        _target = WayPoints.points[0];
        gameObject.transform.LookAt(_target);
    }

    private void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetMaxWayPoint();
        }
    }

    private void GetMaxWayPoint()
    {
        if (_wavePointIndex >= WayPoints.points.Length - 1)
        {
            Debug.Log("Goal!");
            Destroy(gameObject);
            return;
        }

        _wavePointIndex++;
        _target = WayPoints.points[_wavePointIndex];
        gameObject.transform.LookAt(_target);
    }
}
