using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProje1.Abstracts.Spawners
{
    public abstract class CoinBaseSpawner : MonoBehaviour
    {
        

        float _currentSpawnTime;
        float _timeBoundary = 6f;

        private void Start()
        {
            ResetTimes();
        }
        private void Update()
        {
            _currentSpawnTime += Time.deltaTime;
            if (_currentSpawnTime > _timeBoundary)
            {
                Spawn();
                ResetTimes();
            }
        }

        private void ResetTimes()
        {
            _currentSpawnTime = 0f;
        }

        protected abstract void Spawn();
    }
}
