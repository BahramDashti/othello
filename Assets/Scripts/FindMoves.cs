using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class FindMoves
{
    public static int[,]  GETMoves={
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0}
    };
    public static int[,]  G={
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0}
    };
    public void Moves()
    {
        for (int k = 0; k < 8; k++)
        {
            for (int l = 0; l < 8; l++)
            {
                if (GETMoves[k,l]==2)
                {
                    GETMoves[k, l] = 0;
                }
            }
                        
        }

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (Othello.Board[i, j] == Turn.turn)
                {
                    int[,] matrix;
                    matrix = Check(Othello.Board, i, j, Turn.turn);
                    for (int k = 0; k < 8; k++)
                    {
                        for (int l = 0; l < 8; l++)
                        {
                            if (matrix[k,l]==2)
                            {
                                GETMoves[k, l] = 2;
                                
                            }
                        }
                        
                    }
                }
                
            }
        }






    }

    // private void GetMoves(int i,int j)
    // { 
    //   getMoves=
    // }


    private int[,] Check(int[,] board, int i, int j, int turn)
    {
     int[,] _boardCopy = {
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0}
        };

     
        // right

        if (j<7 && board[i, j + 1] == turn * -1)
        {
            for (int k = j + 2; k < 8; k++)
            {
                if (board[i, k] == 0)
                {
                    _boardCopy[i, k] = 2;
                    goto labl1;
                }

                if (board[i, k] == turn)
                {
                    goto labl1;
                }

                if (board[i, k] == 2)
                {
                    goto labl1;
                }

            }
        }


        labl1:
        //left

        if (j>0 && board[i, j - 1] == turn * -1)
        {
            for (int k = j - 2; k > -1; k--)
            {
                if (board[i, k] == 0)
                {
                    _boardCopy[i, k] = 2;
                    goto labl2;
                }

                if (board[i, k] == turn)
                {
                    goto labl2;
                }

                if (board[i, k] == 2)
                {
                    goto labl2;
                }
            }
        }


        labl2:
        //down
        
        if ( i<7 && board[i + 1, j] == turn * -1)
        {
            for (int k = i + 2; k < 8; k++)
            {
                if (board[k, j] == 0)
                {
                    _boardCopy[k, j] = 2;
                    goto labl3;
                }

                if (board[k, j] == turn)
                {
                    goto labl3;
                }

                if (board[i, k] == 2)
                {
                    goto labl3;
                }
            }
        }


        labl3:
        //up

        if (i>0 && board[i - 1, j] == turn * -1)
        {
            for (int k = i - 2; k > -1; k--)
            {
                if (board[k, j] == 0)
                {
                    _boardCopy[k, j] = 2;
                    goto labl4;
                }

                if (board[k, j] == turn)
                {
                    goto labl4;
                }

                if (board[i, k] == 2)
                {
                    goto labl4;
                }
            }
        }


        labl4:
        //upright


        if (i>0 && j<7 &&board[i - 1, j + 1] == turn * -1)
        {
            int s = j + 2;
            for (int k = i - 2; k > -1; k--)
            {

                if (s < 8)
                {
                    if (board[k, s] == 0)
                    {
                        _boardCopy[k, s] = 2;
                        goto labl5;
                    }

                    if (board[k, s] == turn)
                    {
                        goto labl5;
                    }

                    if (board[i, k] == 2)
                    {
                        goto labl5;
                    }

                    s++;
                }
            }
        }

        labl5:
        //upleft

        if (i>0 && j>0 &&board[i - 1, j - 1] == turn * -1)
        {
            int s = j - 2;
            for (int k = i - 2; k > -1; k--)
            {

                if (s > -1)
                {
                    if (board[k, s] == 0)
                    {
                        _boardCopy[k, s] = 2;
                        goto labl6;
                    }

                    if (board[k, s] == turn)
                    {
                        goto labl6;
                    }

                    if (board[i, k] == 2)
                    {
                        goto labl6;
                    }

                    s--;
                }
            }
        }


        labl6:
        //downRight

        if (i<7 && j<7 &&board[i + 1, j + 1] == turn * -1)
        {
            int s = j + 2;
            for (int k = i + 2; k < 8; k++)
            {

                if (s < 8)
                {
                    if (board[k, s] == 0)
                    {
                        _boardCopy[k, s] = 2;
                        goto labl7;
                    }

                    if (board[k, s] == turn)
                    {
                        goto labl7;
                    }

                    if (board[i, k] == 2)
                    {
                        goto labl7;
                    }

                    s++;
                }
            }
        }


        labl7:
        //downLeft
        if (i<7 && j>0 &&board[i + 1, j - 1] == turn * -1)
        {
            int s = j - 2;
            for (int k = i + 2; k < 8; k++)
            {

                if (s > -1)
                {
                    if (board[k, s] == 0)
                    {
                        _boardCopy[k, s] = 2;
                        goto labl8;
                    }

                    if (board[k, s] == turn)
                    {
                        goto labl8;
                    }

                    if (board[i, k] == 2)
                    {
                        goto labl8;
                    }
                }
            }


           
        }
        labl8: ;
        return _boardCopy;
    }
}
