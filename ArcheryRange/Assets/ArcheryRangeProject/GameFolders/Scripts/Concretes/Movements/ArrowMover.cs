using System.Collections;
using System.Collections.Generic;
using UdemyProje1.Combats;
using UnityEngine;
namespace UdemyProje1.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ArrowMover : MonoBehaviour
    {

        [SerializeField] float moveSpeed = 1000f;
        [SerializeField] GameObject playerObjectForLaunchProjectileComponent;
        Rigidbody2D _rigidbody2D;
        LaunchProjectile _launchProjectile;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _launchProjectile = playerObjectForLaunchProjectileComponent.GetComponent<LaunchProjectile>();
        }
        private void OnEnable()
        {
            //LaunchProjectile._projectileDirection statik oluşturulmak zorunda kalındı. Neeni LauncProjectile projectile prfabin bir companenti olmadığı.
            _rigidbody2D.velocity = Vector2.ClampMagnitude(_launchProjectile.ProjectileDirection,1f) * moveSpeed;
        }
    }

}
