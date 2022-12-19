using System.Collections;
using System.Collections.Generic;
using UdemyProje1.Abstracts.Spawners;
using UdemyProje1.Controllers;
using UdemyProje1.Pools;
using UnityEngine;

namespace UdemyProje1.Spawners
{
    public class ProjectileSpawner : BaseSpawner
    {
        //protected void Spawn()
        //{
        //    EnemyController poolEnemy = ProjectilePool.Instance.Get();
        //    poolEnemy.transform.position = this.transform.position;
        //    poolEnemy.gameObject.SetActive(true);
        //}
        protected override void Spawn()
        {
            throw new System.NotImplementedException();
        }
    }
}

