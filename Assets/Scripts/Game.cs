using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject nameWindow;
    [SerializeField] private GameObject selectMoveWindow; 
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private TextMeshProUGUI outcomeDisplay;
    [SerializeField] private TextMeshProUGUI endStateDisplay;

    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private Canvas endCanvas;
    
    public static UnityEvent PlayerNameSelected = new UnityEvent();
    public static UnityEvent MovePicked = new UnityEvent();
    public static UnityEvent RoundEnded = new UnityEvent();

    private int _round;
    public static Player Player1 { get; private set; }
    public static Player Player2 { get; set; }
    
    void Start()
    {
        SetStartState();
        CreatePlayer();
        PlayerNameSelected.AddListener(RunRound);
        MovePicked.AddListener(EvaluateMove);
        RoundEnded.AddListener(RunRound);
        
    }

    private void SetStartState()
    {
        gameCanvas.gameObject.SetActive(true);
        endCanvas.gameObject.SetActive(false);
        nameWindow.gameObject.SetActive(false);
        selectMoveWindow.gameObject.SetActive(false);
        Debug.Log("Game Started");
    }

    private void CreatePlayer()
    {
        Player1 = new Player();
        Player2 = new Player();
        nameWindow.gameObject.SetActive(true);
    }

    private void RunRound()
    {
        _round++;
        Debug.Log("round " + _round + " started" );
        
        Player2.PickRandom();
        selectMoveWindow.gameObject.SetActive(true);
        
    }

    private void EvaluateMove()
    {
        if (Player1.CurrentPick == Player2.CurrentPick)
            outcomeDisplay.text = "Draw!";
        else if (Player1.CurrentPick == Player.Pick.Rock && Player2.CurrentPick == Player.Pick.Scissors)
            PlayerWin(Player1);
        else if (Player1.CurrentPick == Player.Pick.Paper && Player2.CurrentPick == Player.Pick.Rock)
            PlayerWin(Player1);
        else if (Player1.CurrentPick == Player.Pick.Scissors && Player2.CurrentPick == Player.Pick.Paper)
            PlayerWin(Player1);
        else PlayerWin(Player2);

        scoreDisplay.text = Player1.Score + " - " + Player2.Score;
        PlayerVisuals.DisplayPick(Player1);
        PlayerVisuals.DisplayPick(Player2);

        if (Player1.Score >= 3 || Player2.Score >= 3)
            StartCoroutine(HandleGameEnd());
        else
            StartCoroutine(PrepareNextRound());
    }

    private void PlayerWin(Player player)
    {
        player.Score++;
        outcomeDisplay.text = player.PlayerName + " wins";
    }
    IEnumerator PrepareNextRound()
    {
        yield return new WaitForSeconds(1); // Wait for 1 second before starting next round
        selectMoveWindow.gameObject.SetActive(true);
        RoundEnded.Invoke();
    }

    IEnumerator HandleGameEnd()
    {
        yield return new WaitForSeconds(1);
        gameCanvas.gameObject.SetActive(false);
        endCanvas.gameObject.SetActive(true);

        if (Player1.Score < Player2.Score)
            endStateDisplay.text = "The bots won this time. Sad.";
        else endStateDisplay.text = "A true Mastermind, " + Player1.PlayerName;
    }
}
