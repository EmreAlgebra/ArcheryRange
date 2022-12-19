using System.Collections;
using System.Collections.Generic;
using UdemyProje1.Abstracts.Spawners;
using UdemyProje1.Controllers;
using UdemyProje1.Pools;
using UnityEngine;

namespace UdemyProje1.Spawners
{
    public class EnemySpawner : BaseSpawner
    {

        //protected void Spawn()
        //{
        //    EnemyController newEnemy = RedDragonPool.Instance.Get();
        //    newEnemy.transform.position = transform.position;
        //    newEnemy.gameObject.SetActive(true);
        //}
        [SerializeField] EnemyController enemy;
        protected override void Spawn()
        {
            Instantiate(enemy, this.transform);
        }

    }
}

