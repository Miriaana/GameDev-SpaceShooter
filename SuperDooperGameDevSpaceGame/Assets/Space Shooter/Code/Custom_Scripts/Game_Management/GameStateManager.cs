using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public enum GameState { Starting, Selection, Countdown, Playing, End }
    [SerializeField] private GameState currentState;
    [SerializeField] List<SpaceshipMainComponent> allSpaceships;
    [SerializeField] float timeRemaining = 30f;
    [SerializeField] TextMeshProUGUI countDownText;

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
            UIManager.Instance.UpdateTimerText(string.Format("{0:N2}", timeRemaining));
        }
        else if(currentState == GameState.Playing)
        {
            EndGame();
        }
    }

    public void StartGame()
    {
        Debug.Log("StartCalled");
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
        Debug.Log("Starting The Game");
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
        FindObjectOfType<AsteroidSpawner>().StartSpawner();
        UIManager.Instance.StartGameOverlay();
        CameraMovement.Instance.SetNewPosition(CameraMovement.ViewPoint.BattleView);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame()
    {
        currentState = GameState.End;
        Time.timeScale = 0f;
        UIManager.Instance.GameOverMenu.ShowScores(allSpaceships);
        UIManager.Instance.OpenGameOverMenu();
    }

    public void AddSpaceshipToList(SpaceshipMainComponent newSpaceship)
    {
        allSpaceships.Add(newSpaceship);
    }

    public void RemoveSpaceshipFromList(SpaceshipMainComponent removedSpaceship)
    {
        allSpaceships.Remove(removedSpaceship);
        if(allSpaceships.Count == 0 && currentState == GameState.Playing)
        {
            EndGame();
        }
    }
}
