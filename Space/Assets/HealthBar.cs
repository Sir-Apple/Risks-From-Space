﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image HP;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        HP.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        HP.color = gradient.Evaluate(slider.normalizedValue);

    }
}