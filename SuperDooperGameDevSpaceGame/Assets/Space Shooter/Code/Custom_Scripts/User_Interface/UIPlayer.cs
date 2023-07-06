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
    [SerializeField] Slider healthSlider;

    private int score;
    private int ammo;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        AddAmmo(3);
        healthSlider.maxValue = 100f;
    }

    public void UpdateScore(int num)
    {
        score += num;
        ScoreText.text = "Score: " + score;
    }

    public void AddAmmo(int num)
    {
        ammo += num;
        AmmoText.text = "Ammo: " + "Ready";
    }

    public void SubAmmo(int num)
    {
        ammo -= num;
        AmmoText.text = "Ammo: " + "Empty";
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
