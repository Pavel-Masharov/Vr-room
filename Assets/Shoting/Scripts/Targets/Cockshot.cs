using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cockshot : Target
{
    public override Rigidbody _rigidbody { get; set ; }

    public override void Hit()
    {
        Destroy(gameObject);
    }

    public override void Move(Vector3 movePosition)
    {
        transform.DOMove(movePosition, 5f).SetEase(Ease.OutSine).OnComplete(()=> Destroy(gameObject));
    }
}
