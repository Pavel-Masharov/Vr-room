using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _modelGun;
    [SerializeField] private ParticleSystem _particleFire;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    private bool _canShot = true;

    public async void Shot(UnityAction actionHit)
    {
        if (!_canShot)
            return;

        _canShot = false;
        _audioSource.PlayOneShot(_audioClip);
        _particleFire.Play();
         Ray ray = new(_modelGun.transform.position, _modelGun.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {            
            if(hit.collider.gameObject.GetComponent<Target>())
            {
                actionHit?.Invoke();
                hit.collider.gameObject.GetComponent<Target>().Hit();
            }
        }

        await Task.Delay(400);
        _particleFire.Stop();
        _canShot = true;
    }
}
