using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProje1.Combats
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int maxHealth = 3;
        [SerializeField] int currentHealth = 0;
        public bool IsDead => currentHealth < 1;

        public event System.Action<int> OnHealthChanged;
        public event System.Action OnDead;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        private void Start()
        {
            OnHealthChanged?.Invoke(maxHealth);
        }


        public void TakeHit(Damage damage)
        {
            if (IsDead) return;

            currentHealth -= damage.HitDamage;

            if (IsDead)
            {
                OnDead?.Invoke();
            }
            else
            {
                OnHealthChanged?.Invoke(currentHealth);
            }
        }
    }
}
