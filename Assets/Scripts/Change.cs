using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change
{
    public TileManager TileManager { get;  }

    public Change(TileManager tileManager)
    {
        TileManager = tileManager;
    }
    
    public void ChangeOthello(int[,] board, int i, int j, int turn)
    {
        // Right
        if (j < 6 && board[i, j + 1] == turn * (-1) && board[i, j + 2] != 0)
        {
            for (int q = j + 2; q < 8; q++)
            {
                if (board[i, q] == 0)
                {
                    break;
                }
                else if (board[i, q] == turn)
                {
                    for (int k = q; k > j; k--)
                    {
                        board[i, k] = turn;
                    }

                    break;
                }
            }

        }

        //Lft
        if (j > 1 && board[i, j - 1] == turn * (-1) && board[i, j - 2] != 0)
        {


            for (int q = j - 2; q > -1; q--)
            {
                if (board[i, q] == 0)
                {
                    break;
                }
                else if (board[i, q] == turn)
                {
                    for (int k = q; k < j; k++)
                    {
                        board[i, k] = turn;
                    }

                    break;
                }
            }
        }


        //down

        if (i < 6 && board[i + 1, j] == turn * (-1) && board[i + 2, j] != 0)
        {
            for (int q = i + 2; q < 8; q++)
            {
                if (board[q, j] == 0)
                {
                    break;
                }
                else if (board[q, j] == turn)
                {
                    for (int k = q; k > i; k--)
                    {
                        board[k, j] = turn;
                    }

                    break;
                }
            }
        }

        //up
        if (i > 1 && board[i - 1, j] == turn * (-1) && board[i - 2, j] != 0)
        {
            for (int q = i - 2; q >= 0; q--)
            {
                if (board[q, j] == 0)
                {
                    break;
                }
                else if (board[q, j] == turn)
                {
                    for (int k = q; k < i; k++)
                    {
                        board[k, j] = turn;
                    }

                    break;
                }
            }
        }


        //upright
        if (i >1 && j < 6 && board[i - 1, j + 1] == turn * (-1) && board[i - 2, j + 2] != 0)
        {
            for (int k = 0; i-2-k >= 0 && 8 > j+2+k; k++)
            {

                if (board[i-2-k, j+2+k] == 0)
                {
                    break;
                }
                else if (board[i-2-k, j+2+k] == turn)
                {
                    for (int s = k; i-2-s <= i; s--)
                    {
                        board[i-2-s, j+2+s] = turn;
                        
                    }
                    break;
                }
            }
        }
        //upleft

        if (i >1 && j > 1 && board[i - 1, j - 1] == turn * (-1) && board[i - 2, j - 2] != 0)
        {
            for (int k = 0; i-2-k >= 0  && 0 <= j-2-k; k++)
            {

                if (board[i-2-k, j-2-k] == 0)
                {
                    break;
                }
                else if (board[i-2-k, j-2-k] == turn)
                {
                    for (int s = k; i-2-s <= i; s--)
                    {
                        board[i-2-s, j-2-s] = turn;
                        
                    }
                    break;
                }
            }
        }
        //downRight

        if (i < 6 && j < 6 && board[i + 1, j + 1] == turn * (-1) && board[i + 2, j + 2] != 0)
        {
            for (int k = 0; k + 2 + i < 8 && 8 > k + 2 + j; k++)
            {

                if (board[k + 2 + i, k + 2 + j] == 0)
                {
                    break;
                }
                else if (board[k + 2 + i, k + 2 + j] == turn)
                {
                    for (int s = k; s+2+i >= i; s--)
                    {
                        board[s + 2 + i, s + 2 + j] = turn;
                        
                    }
                    break;
                }
            }
        }

//downLeft

        if (i < 6 && j > 1 && board[i + 1, j - 1] == turn * (-1) && board[i + 2, j - 2] != 0)
        {
            for (int k = 0; k + 2 + i < 8 && 0 <= j-2-k; k++)
            {

                if (board[k + 2 + i, j-2-k] == 0)
                {
                    break;
                }
                else if (board[k + 2 + i, j-2-k] == turn)
                {
                    for (int s = k; s+2+i >= i; s--)
                    {
                        board[s + 2 + i, j-2-s] = turn;
                        
                    }
                    break;
                }
            }
        }
        
        Othello.Board = board;
        foreach (var keyValue in TileManager.Tiles)
        {
            keyValue.Value.UpdateTile();
        }

    }

}
