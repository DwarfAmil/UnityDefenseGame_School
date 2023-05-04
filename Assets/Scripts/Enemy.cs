using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _hpMax;
    private float _hp;
    private Transform _target;
    private int _wavePointIndex = 0;
    [SerializeField] private GameObject _dieEffect, _coinObject;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _target = WayPoints.points[0];
        _hp = _hpMax;
        gameObject.transform.LookAt(_target);
        UpdateUI();
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

    public void ComputeHP(float num)
    {
        _hp += num;

        if (_hp >= _hpMax)
        {
            _hp = _hpMax;
        }

        if (_hp <= 0)
        {
            DeleteEnemy();
        }
        
        UpdateUI();
    }

    private void DeleteEnemy()
    {
        GameObject coin = Instantiate(_coinObject, transform.position, Quaternion.identity);
        coin.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1000, 0));
        GameObject dieEffect = Instantiate(_dieEffect, transform.position, Quaternion.identity);
        Destroy(dieEffect, 1f);
        // 코인 생성 / 스코어 처리 / 이벤트 출력
        Destroy(gameObject);
    }

    private void UpdateUI()
    {
        _slider.value = _hp / _hpMax;
    }
}
