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

    [SerializeField] private LineRenderer _lineRenderer;

    [SerializeField] private ParticleSystem prefabParticleFire;
    [SerializeField] private Transform _positionParticle;
    private bool _canShot = true;

    private WaitForSeconds _timeReset = new WaitForSeconds(0.4f);
    private Coroutine _coroutineResetTimeShot;



    private void Update()
    {
        UpdateLineRenderer();
    }

    private void UpdateLineRenderer()
    {
        _lineRenderer.SetPosition(0, transform.position);

        Vector3 forward = transform.forward;
        Vector3 position = transform.position;
        float distance = 10f;
        Vector3 targetPoint = position + forward * distance;

        _lineRenderer.SetPosition(1, targetPoint);
    }

    public async void Shot(UnityAction actionHit)
    {
        if (!_canShot)
            return;

        _canShot = false;
        _audioSource.Play();
        //_particleFire.Play();
        var particle = Instantiate(prefabParticleFire, transform);

        particle.Play();
        Ray ray = new(_modelGun.transform.position, _modelGun.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {            
            if(hit.collider.gameObject.GetComponent<Target>())
            {
                actionHit?.Invoke();
                hit.collider.gameObject.GetComponent<Target>().Hit();
            }
        }

        await Task.Delay(300);
       // _particleFire.Stop();
        _canShot = true;

        Destroy(particle.gameObject);    
    }

    private IEnumerator ResetTimeShot()
    {
        yield return _timeReset;
        _particleFire.Stop();
        _canShot = true;
    }
}
