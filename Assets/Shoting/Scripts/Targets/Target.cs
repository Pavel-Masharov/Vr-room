using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : MonoBehaviour
{

    public abstract Rigidbody _rigidbody { get; set; }
    public abstract void Hit();

    public abstract void Move(Vector3 movePosition = default);
}
