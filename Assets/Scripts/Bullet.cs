using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private float _speed = 70f;
    [SerializeField] private GameObject _impactEffect;
    
    // -값이 들어가야 hp가 감소함
    [SerializeField] private float _damage;
    
    public void Seek (Transform target)
    {
        _target = target;
    }
    
    void Update () {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = _speed * Time.deltaTime;
        
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(_target);
    }
    
    void HitTarget ()
    {
        GameObject effectIns = Instantiate(_impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);
        //Destroy(_target.gameObject);
        _target.GetComponent<Enemy>().ComputeHP(_damage);
        Destroy(gameObject);
    }
}