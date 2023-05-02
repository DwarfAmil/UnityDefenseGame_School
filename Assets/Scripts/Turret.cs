using UnityEngine;
using UnityEngine.Serialization;

public class Turret : MonoBehaviour
{
    private Transform _target;
    
    [SerializeField] private float _range = 15f;
    [SerializeField] private float _fireRate;
    private float _fireCountdown = 0f;
    
    
    [Header("Unity Setup Fields")]
    [SerializeField] private string _enemyTag = "Enemy";
    private Enemy _targetEnemy;
    [SerializeField] private Transform _partToRotate;
    [SerializeField] private float _turnSpeed = 10f;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePos;
    
    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= _range)
        {
            _target = nearestEnemy.transform;
            _targetEnemy = nearestEnemy.GetComponent<Enemy>();
        } else
        {
            _target = null;
        }
    }
    
    void Update () {
        if (_target == null)
            return;
        //Target Lock On
        Vector3 dir = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(_partToRotate.rotation, lookRotation, Time.deltaTime*_turnSpeed).eulerAngles;
        _partToRotate.rotation = Quaternion.Euler (0f,rotation.y, 0f);
        
        if (_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1f / _fireRate;
        }
        _fireCountdown -= Time.deltaTime;
    }
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
    
    void Shoot ()
    {
        GameObject bulletGO = Instantiate(_bulletPrefab, _firePos.position, _firePos.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(_target);
    }
}