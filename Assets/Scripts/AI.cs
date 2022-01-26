using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI
{
    
    private ChangeForAi _change = new ChangeForAi();
    public static int[,] CopyOthello=new int[8,8];
    private FindMovesForAi _findMoves = new FindMovesForAi();
    private static int BetaAA;
  
   // public static ArrayList i = new ArrayList();
   // public static ArrayList j = new ArrayList();
    
    private static int[,] b_Weight =
    {
        {100, -10, 11, 6, 6, 11, -10, 100},
        {-10, -20, 1, 2, 2, 1, -20, -10},
        {10, 1, 5, 4, 4, 5, 1, 10},
        {6, 2, 4, 2, 2, 4, 2, 6},
        {6, 2, 4, 2, 2, 4, 2, 6},
        {10, 1, 5, 4, 4, 5, 1, 10},
        {-10, -20, 1, 2, 2, 1, -20, -10},
        {100, -10, 11, 6, 6, 11, -10, 100}
    };

    public int AlphaBeta(Node node, int depth, int alpha, int beta, int turn)
    {
        
        if (!CheckWin(turn))
        {
            if (Count.WhiteCount>Count.BlackCount)
            {
                return 1000;
            }
            if (Count.WhiteCount<Count.BlackCount)
            {
                return -1000;
            }

            return 0;
        }

        if (depth==0)
        {
            return node.Score;
        }

        int value = 0;
        if (turn == 1)
        {
            value = Int32.MinValue;
            for (int m = 0; m < node.PossibleI.Count; m++)
            {
                Node child = new Node();
                child.Score= node.Score;
                child.i = (int) node.PossibleI[m];
                child.j = (int) node.PossibleJ[m];
                child.Score += b_Weight[child.i,child.j];
                // child.BoardCopy = new int[node.BoardCopy.Length,node.BoardCopy.Length];
                ArrayCopy(node.BoardCopy, child.BoardCopy);
                child.BoardCopy[child.i,child.j] = 1;
                _change.ChangeOthello(child.BoardCopy, child.i, child.j, turn);
                ArrayCopy(child.BoardCopy, FindMovesForAi.GETMoves);
                _findMoves.Moves(child.BoardCopy, -1);
              
                select_bot();
                arraylistcopy(TileManager.i,child.PossibleI);
                arraylistcopy(TileManager.j,child.PossibleJ);
                value = Math.Max(value, AlphaBeta(child, depth - 1, alpha, beta, -1));
                beta = BetaAA;
                alpha = Math.Max(alpha, value);
                if (alpha >= beta) {
                    for (int n = 0; n <TileManager.l.Count; n++) {
                        if (TileManager.l[n].Equals((int) node.PossibleI[m]) && TileManager.k[n].Equals((int) node.PossibleJ[m])) {
                            TileManager.Aj = (int) node.PossibleJ[m];
                            TileManager.Ai = (int) node.PossibleI[m];
                            break;
                        }
                    }
                }
            }
        } else {
            for (int m = 0; m < node.PossibleI.Count; m++) {
                Node child = new Node();
                child.Score= node.Score;
                child.i = (int) node.PossibleI[m];
                child.j = (int) node.PossibleJ[m];
                child.Score -= b_Weight[child.i,child.j];
                // child.BoardCopy = new int[node.BoardCopy.Length,node.BoardCopy.Length];
                ArrayCopy(node.BoardCopy, child.BoardCopy);
                child.BoardCopy[child.i,child.j] = -1;
                _change.ChangeOthello(child.BoardCopy, child.i, child.j, turn);
                ArrayCopy(child.BoardCopy, FindMovesForAi.GETMoves);
                _findMoves.Moves(child.BoardCopy, 1);
                select_bot();
                arraylistcopy(TileManager.i,child.PossibleI);
                arraylistcopy(TileManager.j,child.PossibleJ);
                value= Math.Min(value, AlphaBeta(child, depth - 1, alpha, beta, 1));
                beta = Math.Min(beta, value);
                if (alpha >= beta)
                {
                    BetaAA = beta;
                    break;
                }
            }
        }
        return node.Score;
    }

    public static void select_bot() {
        TileManager.i.Clear();
        TileManager.j.Clear();
        for (int q = 0; q < 8; q++) {
            for (int a = 0; a < 8; a++) {
                if (FindMoves.GETMoves[q,a] == 2) {
                    TileManager.i.Add(q);
                    TileManager.j.Add(a);
//                    System.out.println("( " + q + " , " + a + " )  --->" + b_Weight[q][a]);
                }
            }
        }
    }
    public static void arraylistcopy(ArrayList list, ArrayList possible) {
        for (int q = 0; q < list.Count; q++)
        {
            var ss = list[q];
            possible.Add(ss);
        }
    }
    public void ArrayCopy(int[,] nodeBoardCopy, int[,] childBoardCopy)
    {
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                childBoardCopy[i,j] = nodeBoardCopy[i,j];
            }
        }
    }

    private bool CheckWin(int turn)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (FindMovesForAi.GETMoves[i,j]==2)
                {
                   goto OUT1; 
                } 
            }
        }

        _findMoves.Moves(CopyOthello,turn*-1);
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (FindMovesForAi.GETMoves[i,j]==2)
                {
                    return false; 
                } 
            }
        }

        OUT1: 
        return true;
    }
}