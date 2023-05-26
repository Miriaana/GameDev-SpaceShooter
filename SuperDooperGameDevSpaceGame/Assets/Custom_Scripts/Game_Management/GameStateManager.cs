using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public enum GameState { Starting, Playing, End }
    [SerializeField] private GameState currentState;
    [SerializeField] List<SpaceshipMainComponent> allControls;
    float timeRemaining = 30f;

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

    }

    public void EndGame()
    {
        Debug.LogError("GAME ENDEEEEEEEEEEEEEEEEED");
        currentState = GameState.End;
    }

    public void AddSpaceshipToList(SpaceshipMainComponent newSpaceship)
    {
        allControls.Add(newSpaceship);
    }

    public void RemoveSpaceshipFromList(SpaceshipMainComponent removedSpaceship)
    {
        allControls.Remove(removedSpaceship);
        if(allControls.Count == 0 )
        {
            EndGame();
        }
    }
}
