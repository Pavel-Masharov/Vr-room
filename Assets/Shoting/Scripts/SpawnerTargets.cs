using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTargets : MonoBehaviour
{
    [SerializeField] private Target _prefabTestTarget;
    [SerializeField] private List<Transform> _positionsTestTargets = new();

    [SerializeField] private Target _prefabCockshotTarget;
    [SerializeField] private Transform _positionStartCockshotTarget;
    [SerializeField] private Transform _positionFinishCockshotTarget;

    private WaitForSeconds _secondsBtwSpawn = new WaitForSeconds(3);
    private Coroutine _coroutineSpawnTestTarget;
    private Coroutine _coroutineSpawnCockshotTarget;
    private void Start()
    {
        _coroutineSpawnTestTarget = StartCoroutine(SpawnTestTargets());
        _coroutineSpawnCockshotTarget = StartCoroutine(SpawnCockshotTargets());
    }

    private IEnumerator SpawnTestTargets()
    {
        foreach (var item in _positionsTestTargets)
        {
            var target = Instantiate(_prefabTestTarget);
            target.transform.position = item.position;
            yield return _secondsBtwSpawn;
        }
        
    }

    private IEnumerator SpawnCockshotTargets()
    {
        while (true)
        {
            var target = Instantiate(_prefabCockshotTarget);
            target.transform.position = _positionStartCockshotTarget.position;
            target.Move(_positionFinishCockshotTarget.position);
            yield return _secondsBtwSpawn;
        }
        
    }
}
