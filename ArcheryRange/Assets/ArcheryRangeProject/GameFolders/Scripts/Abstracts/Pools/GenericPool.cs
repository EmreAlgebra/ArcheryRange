using System.Collections;
using System.Collections.Generic;
using UdemyProje1.Combats;
using UnityEngine;

namespace UdemyProje1.Abstracts.Pools
{
    public abstract class GenericPool<T> : MonoBehaviour where T : Component
    {

        [SerializeField] T[] prefabs;
        [SerializeField] int countLoop = 5;

        //ilk giren ilk çıkar
        Queue<T> _poolPrefabs = new Queue<T>();

        private void Awake()
        {
            SingletonObject();
            //Death death = FindObjectOfType<Death>();
            //death.OnDeath += ResetAllObjects;
        }
        private void Start()
        {
            GrowPoolPrefab(); 
        }
        private void OnEnable()
        {
            GameManager.Instance.OnSceneChanged += ResetAllObjects;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnSceneChanged -= ResetAllObjects;
        }

        protected abstract void SingletonObject();

        public T Get()
        {
            if (_poolPrefabs.Count == 0)
            {
                GrowPoolPrefab();
            }
            return _poolPrefabs.Dequeue();
        }

        private void GrowPoolPrefab()
        {
            for(int i = 0; i < countLoop; i++)
            {
                T newPrefab = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
                newPrefab.transform.parent = this.transform;
                newPrefab.gameObject.SetActive(false);
                _poolPrefabs.Enqueue(newPrefab);
            }
        }
        public abstract void ResetAllObjects();

        public void Set(T poolObject)
        {
            poolObject.gameObject.SetActive(false);
            _poolPrefabs.Enqueue(poolObject);//havuza objeyi geri atıyoruz
        }
    }
}

