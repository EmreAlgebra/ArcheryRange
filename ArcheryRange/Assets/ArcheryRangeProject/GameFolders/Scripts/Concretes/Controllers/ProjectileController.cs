using System.Collections;
using System.Collections.Generic;
using UdemyProje1.Abstracts.Controllers;
using UdemyProje1.Combats;
using UdemyProje1.ExtensionMethods;
using UdemyProje1.Helper;
using UdemyProje1.Movements;
using UdemyProje1.Pools;
using UnityEngine;

namespace UdemyProje1.Controllers
{
    public class ProjectileController : EnemyController
    {


        Damage _damage;
        Mover _mover;
        Animator _animator;
        Rigidbody2D _rigidBody2D;
        BoxCollider2D _boxCollider2D;
        EnemyController enemy;
        OnGround _onGround;
        CollectableController _coin;

        private void Awake()
        {
            _damage = GetComponent<Damage>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
           
            if(collision.GetComponent<EnemyController>() != null)
            {

                enemy = collision.GetComponent<EnemyController>();
                //Health health = enemy.GetComponent<Health>();
                //Damage damage = enemy.GetComponent<Damage>();
                //Mover mover = enemy.GetComponent<Mover>();
                _animator = enemy.GetComponentInChildren<Animator>();
                _rigidBody2D = enemy.GetComponent<Rigidbody2D>();
                _boxCollider2D = enemy.GetComponent<BoxCollider2D>();
                _onGround = enemy.GetComponent<OnGround>();

                if (_onGround.IsOnGround)
                {
                    _rigidBody2D.velocity = Vector2.zero;
                    _boxCollider2D.enabled = false;
                    InGameVariables._isBoxColliderEnabled = false;
                    DeadAction();
                    Destroy(this.gameObject);
                    
                    //enemy velocity is zero     
                    //health.OnDead += DeadAction;
                    //health.TakeHit(damage);
                }
            }
            if(collision.GetComponent<CollectableController>() != null)
            {
                _coin = collision.GetComponent<CollectableController>();
                GameManager.Instance.IncreaseScore();
                Destroy(_coin.gameObject);
                Destroy(this.gameObject);
            }
            //SetEnemyPool();
        }

        //public override void SetEnemyPool()
        //{
        //    ProjectilePool.Instance.Set(this);
        //}

        public void DeadAction()
        {
            StartCoroutine(DeadActionAsync()); 
        }
        private IEnumerator DeadActionAsync()
        {
            _animator.SetTrigger("split");
            //Destroy(enemy.gameObject, _animator.GetCurrentAnimatorStateInfo(0).length);
            Destroy(enemy.gameObject,1);
            yield return new WaitForSeconds(1);
            

        }
    }
}
