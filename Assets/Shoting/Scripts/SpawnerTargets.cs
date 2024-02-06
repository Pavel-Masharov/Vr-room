using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTargets : MonoBehaviour
{
    [SerializeField] private Target _prefabTarget;
    [SerializeField] private List<Transform> _positionsTargets = new();

    private WaitForSeconds _secondsBtwSpawn = new WaitForSeconds(3);
    private Coroutine _coroutineSpawnTarget;
    private void Start()
    {
        _coroutineSpawnTarget = StartCoroutine(SpawnTargets());
    }

    private IEnumerator SpawnTargets()
    {
        foreach (var item in _positionsTargets)
        {
            var target = Instantiate(_prefabTarget);
            target.transform.position = item.position;
            yield return _secondsBtwSpawn;
        }
        
    }
}
