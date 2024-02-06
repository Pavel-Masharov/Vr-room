using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public void Shot(UnityAction actionHit)
    {    
        Ray ray = new(gameObject.transform.position, gameObject.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {            
            if(hit.collider.gameObject.GetComponent<Target>())
            {
                actionHit?.Invoke();
            }
        }
    }
}
