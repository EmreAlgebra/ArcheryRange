using System.Collections;
using System.Collections.Generic;
using UdemyProje1.Abstracts.Spawners;
using UdemyProje1.Controllers;
using UnityEngine;

namespace UdemyProje1.Spawners
{
    public class CollectableSpawner : CoinBaseSpawner
    {
        [SerializeField] float maxSpawnWorldPosx = 1.5f;

        [SerializeField] float minSpawnWorldPosx = -1.5f;

        [SerializeField] float maxSpawnWorldPosy = 3f;

        [SerializeField] float minSpawnWorldPosy = 1.25f;

        [SerializeField] CollectableController coin;
        protected override void Spawn()
        {
            this.transform.position = new Vector3(Random.Range(minSpawnWorldPosx, maxSpawnWorldPosx), Random.Range(minSpawnWorldPosy, maxSpawnWorldPosy));
            Instantiate(coin, this.transform);
        }
    }
}

