using System.Collections;
using System.Collections.Generic;
using UdemyProje1.Abstracts.Spawners;
using UdemyProje1.Controllers;
using UdemyProje1.Movements;
using UdemyProje1.Pools;
using UnityEngine;

namespace UdemyProje1.Spawners
{
    public class ObsticleSpawner : BaseSpawner
    {


        [SerializeField] EnemyController[] enemies;

        protected override void Spawn()
        {

            int enemyIndex = Random.Range(0, enemies.Length);
            Instantiate(enemies[enemyIndex], this.transform);
        }
    }
}

