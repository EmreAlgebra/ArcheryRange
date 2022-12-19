using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace UdemyProje1.UIs
{
    public class DisplayHealth : MonoBehaviour
    {
        TextMeshProUGUI _healthText;

        private void Awake()
        {
            _healthText = GetComponent<TextMeshProUGUI>();
        }

        public void HealthWrite(int currentHealth)
        {
            _healthText.text = currentHealth.ToString();
        }
    }
}
