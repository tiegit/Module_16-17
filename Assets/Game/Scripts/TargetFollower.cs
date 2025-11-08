using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    private Transform _target;
    private Vector3 _offset;

    public void Initialize(Transform target)
    {
        _target = target;
        _offset = transform.position;
    }

    private void LateUpdate()
    {
        if (_target == null)
            return;

        transform.position = _target.position + _offset;
    }
}
