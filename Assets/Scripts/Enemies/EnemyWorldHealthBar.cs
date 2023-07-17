using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWorldHealthBar : MonoBehaviour
{

    [SerializeField] private Slider _HBSlider;

    public void UpdateHealth(float currentValue, float maxValue)
    {
        _HBSlider.value = Mathf.Clamp(currentValue / maxValue,0,1);
    }
}
