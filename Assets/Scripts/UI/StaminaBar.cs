using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    Slider slider;
    StatsManager entityManager;

    private void Start()
    {
        entityManager = GetComponentInParent<StatsManager>();
        slider = GetComponent<Slider>();

        slider.maxValue = entityManager.maxStamina;
    }

    private void Update()
    {
        slider.value = entityManager.stamina;
    }

}
