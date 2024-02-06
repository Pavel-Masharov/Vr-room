using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _modelGun;
    //[SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _particleFire;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    //private int _animationFireHash = Animator.StringToHash("Fire");

    public void Shot(UnityAction actionHit)
    {
        // _animator.SetTrigger(_animationFireHash);
        _audioSource.PlayOneShot(_audioClip);
        _particleFire.Play();
         Ray ray = new(_modelGun.transform.position, _modelGun.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {            
            if(hit.collider.gameObject.GetComponent<Target>())
            {
                actionHit?.Invoke();
            }
        }
    }
}
