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
    [SerializeField] Slider healthSlider;

    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        healthSlider.maxValue = 100f;
    }

    public void UpdateScore(int num)
    {
        score += num;
        ScoreText.text = "Score: " + score;
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
