using System.Collections;
using System.Collections.Generic;
using UdemyProje1.Combats;
using UdemyProje1.UIs;
using UdemyProje1.Spawners;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UdemyProje1.Controllers
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] Transform projectileTransform;
        [SerializeField] GameObject _haloGameObject;

        Animator _animator,_haloAnimator;
        Health _health;
        Damage _damage;
        PcInputController _pcInputController;
        LaunchProjectile _launchProjectile;
        AudioSource _audioSource;

        private int _playerLevel = 4;//bu değer menuden attributelerden gelecek
        public int PlayerLevel => _playerLevel;

        bool _isLeftButtonClicked = false;
        bool _isTouch = false;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _pcInputController = new PcInputController();
            _launchProjectile = GetComponent<LaunchProjectile>();
            _audioSource = GetComponent<AudioSource>();
            _audioSource.mute = true;
            _launchProjectile.ScreenPos = Camera.main.WorldToScreenPoint(projectileTransform.transform.position);
            _health = GetComponent<Health>();
            _damage = GetComponent<Damage>();
            _haloGameObject = GameObject.FindWithTag("HALO");
            _haloAnimator = _haloGameObject.GetComponent<Animator>();
            _haloAnimator.SetFloat("animSpeed", PlayerLevel);
        }
        private void Start()
        {
            //_playerLevel = GameManager.Instance.
        }

        private void OnEnable()
        {
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();
            if (gameCanvas != null)
            {
                //_health.OnDead += gameCanvas.ShowGameOverPanel;
                //DisplayHealth displayHealth = gameCanvas.GetComponentInChildren<DisplayHealth>();
                //_health.OnHealthChanged += displayHealth.HealthWrite;
            }
        }

        private void Update()
        {
            //if (_health.IsDead) return;
            if (!_launchProjectile.CanLaunch) return;

            if (_pcInputController.LeftMouseClickUp)
            {
                _isLeftButtonClicked = true;

            }
            if (_pcInputController.TouchCount)
            {
                _isTouch = true;
            }

        }

        private void FixedUpdate()
        {
            if (_isLeftButtonClicked)
            {
                
                _launchProjectile.LaunchAction();
                
                _isTouch = false;
                _animator.SetBool("isTouch", _isTouch);
                _haloAnimator.SetTrigger("haloPlay");
                _audioSource.Play();
                _isLeftButtonClicked = false;
            }
            if (_isTouch)
            {
                if (_launchProjectile.ScreenPos.y - Input.mousePosition.y >= 0)
                {
                    
                    _animator.SetBool("isTouch", _isTouch);
                    _launchProjectile.ProjectileDirection = new Vector2((_launchProjectile.ScreenPos.x - Input.mousePosition.x), (_launchProjectile.ScreenPos.y - Input.mousePosition.y));
                    _animator.SetFloat("Angle", _launchProjectile.Angle);
                }
            }


        }
    }
}

