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
    //public float timeRemaining;
    public UIGameOver GameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdateTimerText(string newTimeCode)
    {
        TimerText.text = newTimeCode;
    }

    public void DisablePlayer(int num)
    {
        uIPlayers[num].gameObject.SetActive(false);
    }

    public void EnablePlayer(int num)
    {
        uIPlayers[num].gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        Debug.Log("Restarting Game");
        GameStateManager.Instance.RestartGame();
    }

    public void OpenGameOverMenu()
    {
        GameOverMenu.gameObject.SetActive(true);
    }
}
