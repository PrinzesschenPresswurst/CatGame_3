using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private Sprite rockSprite;
    private static Sprite rock;
    [SerializeField] private Sprite paperSprite;
    private static Sprite paper;
    [SerializeField] private Sprite scissorsSprite;
    private static Sprite scissors;
    [SerializeField] private GameObject player1Feedback;
    [SerializeField] private GameObject player2Feedback;
    private static Sprite _sprite;
    private static SpriteRenderer _spriteRenderer1;
    private static SpriteRenderer _spriteRenderer2;

    private void Start()
    {
        _spriteRenderer1 = player1Feedback.GetComponent<SpriteRenderer>();
        _spriteRenderer2 = player2Feedback.GetComponent<SpriteRenderer>();
        rock = rockSprite;
        paper = paperSprite;
        scissors = scissorsSprite;
    }

    public static void DisplayPick(Player player)
    {
        if (player.CurrentPick == Player.Pick.Paper)
            _sprite = paper;
        else if (player.CurrentPick == Player.Pick.Rock)
            _sprite = rock;
        else if (player.CurrentPick == Player.Pick.Scissors)
            _sprite = scissors;

        Debug.Log(_spriteRenderer1);
        Debug.Log(_spriteRenderer1.sprite);
        if (player == Game.Player1)
            _spriteRenderer1.sprite = _sprite;
        else if (player == Game.Player2)
            _spriteRenderer2.sprite = _sprite;
    }
}
