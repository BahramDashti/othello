using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Count : MonoBehaviour
{
   public static int WhiteCount=0;
   public static int BlackCount=0;
   [SerializeField] private  TextMeshProUGUI _textMeshProUGUIB;
   [SerializeField] private  TextMeshProUGUI _textMeshProUGUIW;

   private void Start()
   {
      for (int i = 0; i < 8; i++)
      {
         for (int j = 0; j < 8; j++)
         {
            if (Othello.Board[i,j]==-1)
            {
               BlackCount += 1;

            }

            if (Othello.Board[i,j]==1)
            {
               WhiteCount += 1;
            }


         }
      }

      _textMeshProUGUIB.text = BlackCount.ToString();
      _textMeshProUGUIW.text = WhiteCount.ToString();
   }

   public void ChangeCount()
   {
      WhiteCount = 0;
      BlackCount = 0;
      for (int i = 0; i < 8; i++)
      {
         for (int j = 0; j < 8; j++)
         {
            if (Othello.Board[i,j]==-1)
            {
               BlackCount += 1;

            }

            if (Othello.Board[i,j]==1)
            {
               WhiteCount += 1;
            }


         }
      }
      _textMeshProUGUIB.text = BlackCount.ToString();
      _textMeshProUGUIW.text = WhiteCount.ToString();
   }
}
