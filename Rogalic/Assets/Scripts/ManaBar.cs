using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = this.GetComponent<Slider>();
    }

    public void SetMaxMana(float mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
    }

    public void SetMana(float mana)
    {
        slider.value = mana;
    }
}
