using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public enum GameState { Starting, Selection, Countdown, Playing, Bossfight, End }
    public GameState currentState;
    [SerializeField] BossMainControls bossControls;
    [SerializeField] float timeRemaining = 30f;
    [SerializeField] TextMeshProUGUI countDownText;
    [SerializeField] AsteroidSpawner astSpawner;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        if (currentState != GameState.Playing)
        {
            //Time.timeScale = 0f;
        }
    }

    private void Update()
    {
        if (timeRemaining > 0 && currentState == GameState.Playing)
        {
            timeRemaining -= Time.deltaTime;
            timeRemaining = Mathf.Clamp(timeRemaining, 0f, 100000000f);
            if(timeRemaining > 0)
            {
                UIManager.Instance.UpdateTimerText(string.Format("{0:N2}", timeRemaining));
            }
            else
            {
                UIManager.Instance.TimerText.gameObject.SetActive(false);
                UIManager.Instance.TimerTitle.gameObject.SetActive(false);
            }
        }
        else if(currentState == GameState.Playing)
        {
            currentState = GameState.Bossfight;
            astSpawner.StopSpawner();
            bossControls.gameObject.SetActive(true);
        }
    }

    public void StartGame()
    {
        if(PlayerControlInstanceManager.Instance.CheckGlobalConfirmationState())
        {
            if(currentState == GameState.Selection)
            {
                StartCoroutine("StartGameCo");
            }
        }
        else
        {
            StopCoroutine("StartGameCo");
            if (currentState == GameState.Selection)
            {
                countDownText.text = "Select Your Starship";
            }
            else if (currentState == GameState.Playing)
            {
                countDownText.text = "";
            }
            else if(currentState == GameState.Countdown)
            {
                currentState = GameState.Selection;
            }
        }
    }

    IEnumerator StartGameCo()
    {
        currentState = GameState.Countdown;
        countDownText.text = "Starting in...";
        yield return new WaitForSeconds(1f);
        countDownText.text = "3";
        yield return new WaitForSeconds(1f);
        countDownText.text = "2";
        yield return new WaitForSeconds(1f);
        countDownText.text = "1";
        yield return new WaitForSeconds(1f);
        countDownText.text = "GET READY!";
        yield return new WaitForSeconds(1.5f);
        countDownText.text = "";
        //Actually Starting The Game
        currentState = GameState.Playing;
        PlayerControlInstanceManager.Instance.InstantiateSpaceships();
        astSpawner.StartSpawner();
        UIManager.Instance.StartGameOverlay();
        CameraMovement.Instance.SetNewPosition(CameraMovement.ViewPoint.BattleView);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CheckAllPlayerHealth()
    {
        for (int i = 0; i < PlayerControlInstanceManager.Instance.allInputs.Count; i++)
        {
            if (PlayerControlInstanceManager.Instance.allInputs[i].shipMain.mainHull.curHealth > 0)
            {
                return;
            }
        }
        EndGame();
    }

    public void EndGame()
    {
        currentState = GameState.End;
        Time.timeScale = 0f;
        List<SpaceshipMainComponent> allShips = new List<SpaceshipMainComponent>();
        foreach(SpaceshipInputControls control in PlayerControlInstanceManager.Instance.allInputs)
        {
            allShips.Add(control.shipMain);
        }
        UIManager.Instance.GameOverMenu.ShowScores(allShips);
        UIManager.Instance.OpenGameOverMenu();
    }

    
}
