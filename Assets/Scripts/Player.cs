using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    public string PlayerName { get; set; }
    public Pick CurrentPick { get; set; }
    public int Score { get; set; }
   
    
    public Player()
    {
        Debug.Log("creating new player");
        PlayerName = "Bot";
        CurrentPick = Pick.Paper;
        Score = 0;
    }

    public void PickRandom()
    {
        CurrentPick = (Pick)Random.Range(0, 2);
    }

    public enum Pick
    {
        Rock, 
        Paper, 
        Scissors
    }
}
