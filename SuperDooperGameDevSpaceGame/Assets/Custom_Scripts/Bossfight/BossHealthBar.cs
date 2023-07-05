using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] Slider redSlider, whiteSlider;
    [SerializeField] float whiteSliderSpeed = 15f;
    // Update is called once per frame
    void Update()
    {
        if(redSlider.value != whiteSlider.value)
        {
            CorrectWhiteSlider();
        }
    }

    public void InitializeSlider(float maxValue)
    {
        redSlider.maxValue = maxValue;
        redSlider.value = maxValue;
        whiteSlider.maxValue = maxValue;
        whiteSlider.value = maxValue;
    }

    public void SetRedSliderValues(float newValue)
    {
        redSlider.value = newValue;
    }

    void CorrectWhiteSlider()
    {
        whiteSlider.value += Time.deltaTime * whiteSliderSpeed * Mathf.Sign(redSlider.value - whiteSlider.value);
        whiteSlider.value = Mathf.Clamp(whiteSlider.value, redSlider.value, whiteSlider.maxValue);
    }
}
