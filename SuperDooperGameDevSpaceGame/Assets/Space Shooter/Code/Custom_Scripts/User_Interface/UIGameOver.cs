using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    public GameObject MainCanvasObject;
    [SerializeField] TextMeshProUGUI[] PlayerScoreText; 

    public void ShowScores(List<SpaceshipMainComponent> players)
    {
        MainCanvasObject.SetActive(true);
        players.Sort(CompareScores);
        for (int i = 0; i < players.Count; i++)
        {
            PlayerScoreText[i].text = $"#{i + 1}: {players[i].playerName} = {players[i].score}";
        }

    }

    private static int CompareScores(SpaceshipMainComponent player1, SpaceshipMainComponent player2)
    {
        return player2.score.CompareTo(player1.score);
    }
}
