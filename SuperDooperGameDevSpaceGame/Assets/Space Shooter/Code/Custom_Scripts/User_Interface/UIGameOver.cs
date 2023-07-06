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
        for (int i = 0; i < UIManager.Instance.uIPlayers.Length; i++)
        {
            PlayerScoreText[i].text = $"#{i + 1}: {UIManager.Instance.uIPlayers[i].NameText.text} -> {UIManager.Instance.uIPlayers[i].ScoreText.text}";
        }
        /*for (int i = 0; i < PlayerScoreText.Length; i++)
        {
            
            if( i < players.Count )
            {
                PlayerScoreText[i].text = $"#{i+1}: {players[i].playerName} -> {players[i].score}";
            }
            else
            {
                PlayerScoreText[i].text = "";
            }
        }*/
    }

    private static int CompareScores(SpaceshipMainComponent player1, SpaceshipMainComponent player2)
    {
        return player2.score.CompareTo(player1.score);
    }
}
