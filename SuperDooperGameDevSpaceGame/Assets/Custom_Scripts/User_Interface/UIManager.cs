using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public UIPlayer[] uIPlayers;
    public TextMeshProUGUI TimerText;
    public int assignmentIndex = 0;
    public float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            TimerText.text = string.Format("{0:N2}", timeRemaining);
        }
    }

    public void DisablePlayer(int num)
    {
        uIPlayers[num].gameObject.SetActive(false);
    }

    public void EnablePlayer(int num)
    {
        uIPlayers[num].gameObject.SetActive(true);
    }
}
