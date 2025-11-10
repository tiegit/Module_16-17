using UnityEngine;

public interface IBehaviour
{
    void Start();

    void Stop();

    void Reset();

    void CustomUpdate(Vector3 characterPosition);
}