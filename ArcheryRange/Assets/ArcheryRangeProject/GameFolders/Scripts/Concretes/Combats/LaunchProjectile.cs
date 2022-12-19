using UdemyProje1.Controllers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UdemyProje1.Combats
{
    public class LaunchProjectile : MonoBehaviour
    {
        [SerializeField] ProjectileController projectilePrefab;
        [SerializeField] Transform projectileTransform;
        [SerializeField] GameObject projectileParent;

        PlayerController _playerController;

        private float delayProjectile = 1.5f;

        float _currentDelayTime = 0f;
        bool _canLaunch = true;
        public bool CanLaunch => _canLaunch;

        public static Vector2 _projectileDirection;
        private Vector3 _screenPos;

        public Vector2 ProjectileDirection 
        { 
            get 
            {
                return _projectileDirection;
            }
            set
            {
                _projectileDirection = value;
            } 
        }

        public Vector3 ScreenPos
        {
            get
            {
                return _screenPos;
            }
            set
            {
                _screenPos = value;
            }
        }
       


        Animator _animator;
        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
            delayProjectile = delayProjectile / (float)_playerController.PlayerLevel;
        }

        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            _screenPos = Camera.main.WorldToScreenPoint(projectileTransform.transform.position);
            _screenPos = new Vector3(_screenPos.x, 606.2f, _screenPos.z);
            Debug.Log(_screenPos);
        }

        private void Update()
        {
            _currentDelayTime += Time.deltaTime;
            
            if (_currentDelayTime > delayProjectile)
            {
                _canLaunch = true;
                _currentDelayTime = 0f;
            }
        }
        public void LaunchAction()
        {

            if (_screenPos.y - Input.mousePosition.y >= 0)
            {
                if(_screenPos.x - Input.mousePosition.x != 0 && _screenPos.y - Input.mousePosition.y != 0)
                {
                    if (_canLaunch)
                    {

                        _projectileDirection = new Vector2((_screenPos.x - Input.mousePosition.x), (_screenPos.y - Input.mousePosition.y));

                        Quaternion rotate = Quaternion.Euler(0, 0, Angle - 90f);

                        //EnemyController poolEnemy = ProjectilePool.Instance.Get();

                        //poolEnemy.transform.position = projectileTransform.position;

                        //poolEnemy.transform.rotation = rotate;


                        //poolEnemy.transform.parent = projectileParent.transform;

                        //poolEnemy.gameObject.SetActive(true);

                        ProjectileController newProjectile = Instantiate(projectilePrefab, projectileTransform.position, rotate);
                        //Debug.Log(newProjectile.transform.rotation);
                        newProjectile.transform.parent = projectileParent.transform;
                        _currentDelayTime = 0f;
                        _canLaunch = false;
                    }
                }
            }
        }
        //public static float Angle(Vector2 p_vector2)
        //{
        //    return (Mathf.Atan2(p_vector2.y, p_vector2.x) * Mathf.Rad2Deg);
        //}

        public float Angle
        {
            get
            {
                return (Mathf.Atan2(_projectileDirection.y, _projectileDirection.x) * Mathf.Rad2Deg);
            }
        }
    }

}
