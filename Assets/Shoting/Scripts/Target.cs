using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public void Hit()
    {
        if(!_rigidbody)
            _rigidbody = gameObject.AddComponent<Rigidbody>();

        _rigidbody.AddForce(Vector3.forward, ForceMode.Impulse);
    }
}
