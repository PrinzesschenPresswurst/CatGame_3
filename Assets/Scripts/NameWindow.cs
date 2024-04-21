using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI playerName;
    public void ReadPlayerName()
    {
        Debug.Log("changed text");
        Debug.Log(nameText.text);
        Game.Player1.PlayerName = nameText.text;
    }

    public void CloseWindow()
    {
        playerName.text = Game.Player1.PlayerName;
        Game.PlayerNameSelected.Invoke();
        gameObject.SetActive(false);
    }
    
    
}
