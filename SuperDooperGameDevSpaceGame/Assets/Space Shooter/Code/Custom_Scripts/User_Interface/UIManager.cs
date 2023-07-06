using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public UIPlayer[] uIPlayers;
    public string[] Playernames = { "Blue", "Green", "Yellow", "Purple" };
    public TextMeshProUGUI TimerText;
    public int assignmentIndex = 0;
    //public float timeRemaining;
    public UIGameOver GameOverMenu;
    public GameObject SelectionMenu;
    public GameObject GameOverlay;

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
        GameStateManager.Instance.RestartGame();
    }

    public void OpenSelectionScreen()
    {
        SelectionMenu.SetActive(true);
    }

    public void StartGameOverlay()
    {
        SelectionMenu.SetActive(false);
        GameOverlay.SetActive(true);
    }

    public void CloseGameOverlay()
    {
        GameOverlay.SetActive(false);
        TimerText.gameObject.SetActive(false);
    }

    public void OpenGameOverMenu()
    {
        //GameOverMenu.gameObject.SetActive(true);
    }
}
