using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    Slider slider;
    StatsManager entityManager;

    private void Start()
    {
        entityManager = GetComponentInParent<StatsManager>();        
        slider = GetComponent<Slider>();

        slider.maxValue = entityManager.maxHealth;
    }

    private void Update()
    {
        slider.value = entityManager.health;
    }

    
   
}
