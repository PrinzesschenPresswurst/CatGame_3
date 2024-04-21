using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectMoveWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerPick;
    [SerializeField] private TextMeshProUGUI botPick;

    private void Start()
    {
        playerPick.gameObject.SetActive(false);
        botPick.gameObject.SetActive(false);
    }

    private void CloseWindow()
    {
        Game.MovePicked.Invoke();
        
        playerPick.gameObject.SetActive(true);
        playerPick.text = Game.Player1.CurrentPick.ToString();
        
        botPick.gameObject.SetActive(true);
        botPick.text = Game.Player2.CurrentPick.ToString();
        
        gameObject.SetActive(false);
    }

    public void PickRock()
    {
        Game.Player1.CurrentPick = Player.Pick.Rock;
        CloseWindow();
    }

    public void PickPaper()
    {
        Game.Player1.CurrentPick = Player.Pick.Paper;
        CloseWindow();
    }

    public void PickScissors()
    {
        Game.Player1.CurrentPick = Player.Pick.Scissors;
        CloseWindow();
    }
}
