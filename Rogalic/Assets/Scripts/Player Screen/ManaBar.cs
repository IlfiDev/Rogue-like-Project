using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private TooltipTrigger tooltipTrigger;

    private Slider slider;

    private void Awake()
    {
        slider = this.GetComponent<Slider>();

        tooltipTrigger = transform.GetComponentInChildren<TooltipTrigger>();
        tooltipTrigger.SetText(slider.value.ToString() + " / " + slider.maxValue.ToString());
    }

    public void SetMaxMana(float mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
        int manaValue = (int) slider.value;
        tooltipTrigger.SetText(manaValue.ToString() + " / " + slider.maxValue.ToString());
    }

    public void SetMana(float mana)
    {
        slider.value = mana;
        int manaValue = (int) slider.value;
        tooltipTrigger.SetText(manaValue.ToString() + " / " + slider.maxValue.ToString());
    }
}
