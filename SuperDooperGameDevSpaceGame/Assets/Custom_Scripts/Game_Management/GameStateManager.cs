using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public enum GameState { Starting, Playing, End }
    [SerializeField] private GameState currentState;
    [SerializeField] List<SpaceshipMainComponent> allControls;
    [SerializeField] float timeRemaining = 30f;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
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
        currentState = GameState.Playing;
        FindObjectOfType<AsteroidSpawner>().StartSpawner();
    }

    public void RestartGame()
    {
        //timeRemaining = 100f;
        //currentState = GameState.Playing;
        //Time.timeScale = 1f;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame()
    {
        Debug.LogError("GAME ENDEEEEEEEEEEEEEEEEED");
        currentState = GameState.End;
        Time.timeScale = 0f;
        UIManager.Instance.GameOverMenu.ShowScores(allControls);
        UIManager.Instance.OpenGameOverMenu();
    }

    public void AddSpaceshipToList(SpaceshipMainComponent newSpaceship)
    {
        if(currentState != GameState.Playing) //todo: rem
        {
            StartGame();
        }
        allControls.Add(newSpaceship);
    }

    public void RemoveSpaceshipFromList(SpaceshipMainComponent removedSpaceship)
    {
        allControls.Remove(removedSpaceship);
        if(allControls.Count == 0 && currentState == GameState.Playing)
        {
            EndGame();
        }
    }
}
