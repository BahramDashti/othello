using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int[,] BoardCopy = new int[8, 8];
    public int i = 0;
    public int j = 0;
    public int Score = 0;
    public ArrayList PossibleI = new ArrayList();
    public ArrayList PossibleJ = new ArrayList();
}
