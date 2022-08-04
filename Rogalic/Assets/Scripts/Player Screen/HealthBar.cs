using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TooltipTrigger tooltipTrigger;

    private Slider slider;

    private void Awake()
    {
        slider = this.GetComponent<Slider>();

        tooltipTrigger = transform.GetComponentInChildren<TooltipTrigger>();
        tooltipTrigger.SetText(slider.value.ToString() + " / " + slider.maxValue.ToString());
    }

    public void SetMaxHealth(float health)
    { 
        slider.maxValue = health;
        slider.value = health;
        tooltipTrigger.SetText(slider.value.ToString() + " / " + slider.maxValue.ToString());
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        tooltipTrigger.SetText(slider.value.ToString() + " / " + slider.maxValue.ToString());
    }
}