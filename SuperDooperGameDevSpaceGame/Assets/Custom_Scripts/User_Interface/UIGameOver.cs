using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] PlayerScoreText; 

    public void ShowScores(List<SpaceshipMainComponent> players)
    {
        players.Sort(CompareScores);
        for (int i = 0; i < PlayerScoreText.Length; i++)
        {
            
            if( i < players.Count )
            {
                Debug.Log($"{players[i].name}");
                PlayerScoreText[i].text = $"Rank {i+1}: {players[i].score} {players[i].playerName}";
            }
            else
            {
                PlayerScoreText[i].text = "";
            }
        }
    }

    private static int CompareScores(SpaceshipMainComponent player1, SpaceshipMainComponent player2)
    {
        return player1.score.CompareTo(player2.score);
    }
}
