using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIPlayer : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI AmmoText;
    [SerializeField] Slider healthSlider, ammoSlider;
    private int ammo;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        UpdateAmmo();
        healthSlider.maxValue = 100f;
        healthSlider.value = healthSlider.maxValue;
    }

    public void UpdateScore(int newScore = 0)
    {
        ScoreText.text = "" + newScore;
    }

    public void UpdateAmmo(int ammoCount = 0, float slidingValue = 0)
    {
        AmmoText.text = "" + ammoCount;
        ammoSlider.value = slidingValue;
    }

    public int CheckAmmo()
    {
        return ammo;
    }

    public void SetName(string name)
    {
        NameText.text = name;
    }

    public void SetHealthSlider(float newValue)
    {
        healthSlider.value = newValue;
    }
}
