using UnityEngine;

public class RotateSelf : MonoBehaviour {

    [SerializeField] private float _speed = 1.5f;

    void Update () {
        transform.Rotate(new Vector3(_speed, 0f, 0f));
    }
}