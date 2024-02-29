using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottlesTarget : Target
{
    public override Rigidbody _rigidbody { get; set; }

    public override void Hit()
    {
        GetComponent<Bottle>().Explode();
    }

    public override void Move(Vector3 movePosition)
    {
        return;
    }
}
