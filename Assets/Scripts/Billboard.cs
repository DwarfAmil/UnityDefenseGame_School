using UnityEngine;

public class Billboard : MonoBehaviour
{

    [SerializeField] private Transform _target;

    private void Start()
    {

        _target = Camera.main.gameObject.transform;
    }

    private void Update()
    {

        transform.rotation = Quaternion.LookRotation(_target.forward, _target.up);
    }
}