using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTarget : Target
{
    public override Rigidbody _rigidbody { get; set; }

    public override void Hit()
    {
        if (!_rigidbody)
            _rigidbody = gameObject.AddComponent<Rigidbody>();

        _rigidbody.AddForce(Vector3.forward, ForceMode.Impulse);
    }

    public override void Move(Vector3 movePosition)
    {
        return;
    }
}
