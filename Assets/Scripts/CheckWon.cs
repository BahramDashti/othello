using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckWon : MonoBehaviour
{
    [SerializeField] private static GameObject wonPanel;
    [SerializeField] private static TextMeshProUGUI wonText;
    public static void Won()
    {
        if (Turn.Won)
        {
            
            wonPanel.SetActive(true);
            if (Count.BlackCount>Count.WhiteCount)
            {
                wonText.text = "Human Has Won\n " + Count.BlackCount;
            }
            else if(Count.BlackCount<Count.WhiteCount)
            {
                wonText.text = "Bot Has Won\n " + Count.WhiteCount;
            }
            else
            {
                wonText.text = "TIE";
            }

        }
    }
}
