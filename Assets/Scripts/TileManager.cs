using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private GameObject hint;
    [SerializeField] private GameObject redPrefab;
    [SerializeField] private int _width, _height;
    [SerializeField] private Count count;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;
    private Change _change; 
    public Vector2 clickedTile;
    public static ArrayList i;
    public static ArrayList j;
    public static ArrayList l;
    public static ArrayList k;
    public static int Ai;
    public static int Aj;
    private Dictionary<Vector2, Tile> _tiles;

    public Dictionary<Vector2, Tile> Tiles => _tiles;
    
    private FindMoves _findMoves;
    private FindMovesForAi _findMovesForAi;
    private AI _ai;
    void Awake()
    {
       _ai = new AI();
        _change = new Change(this);
        _findMovesForAi = new FindMovesForAi();
        //_ai = new AI();
        count = count.GetComponent<Count>();
        GenerateGrid();
        _findMoves = new FindMoves();
    }

    private void Start()
    {
        _ai.ArrayCopy(Othello.Board,AI.CopyOthello);
        i = new ArrayList();
        j = new ArrayList(); 
        l = new ArrayList();
        k = new ArrayList();
        _findMoves.Moves();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (FindMoves.GETMoves[i,j]==2)
                {
                  var hintRed=  Instantiate(redPrefab, new Vector2(7-i, j), Quaternion.identity);
                  hintRed.transform.parent = hint.transform;
                }

               
            }
        }
    }

    
        
    

    void GenerateGrid() {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                var spawnedTile = Instantiate(_tilePrefab, transform);
                spawnedTile.transform.localPosition = new Vector3(x, y, 0);
                spawnedTile.name = $"Tile {x} {y}";
 
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
 
 
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
 
        _cam.transform.position = new Vector3((float)_width/2 -0.5f, (float)_height / 2 - 0.5f,-10);
    }
 
    public Tile GetTileAtPosition(Vector2 pos) {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }

    public void ThereIsMove()
    {
        // for (int i = 0; i < 8; i++)
        // {
        //     for (int j = 0; j < 8; j++)
        //     {
        //         if (FindMoves.GETMoves[i,j]==2)
        //         {
        //             goto OUT1;
        //         }
        //
        //        
        //     }
        // }

        Turn.turn = Turn.turn * -1;
        _findMoves.Moves();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (FindMoves.GETMoves[i, j] == 2)
                {
                    goto OUT2;
                }


            }
        }

        Turn.Won = true;
        
        
        OUT2:
        DrawHint();
       
        
       
       
        // _findMoves.Moves();
    }

    public void AiTurn()
    {
        Node node = new Node();
       
        _ai.ArrayCopy(Othello.Board, node.BoardCopy);
       _findMovesForAi.Moves(Othello.Board,Turn.turn);
       l.Clear();
       k.Clear();
       AI.select_bot();
        AI.arraylistcopy(i,node.PossibleI);
        AI.arraylistcopy(j,node.PossibleJ);
        AI.arraylistcopy(i,l);
        AI.arraylistcopy(j,k);
        if (l.Count>1)
        {
            _ai.AlphaBeta(node, 5, Int32.MinValue, Int32.MaxValue, Turn.turn);
            Debug.Log(Ai+" "+Aj);
            Othello.Board[Ai, Aj] = 1;
            _change.ChangeOthello(Othello.Board,Ai,Aj,Turn.turn);
        }
        else if (l.Count==1)
        {
            Debug.Log(Ai+" "+Aj);
            Othello.Board[(int)l[0], (int)k[0]] = 1;
            _change.ChangeOthello(Othello.Board,(int)l[0],(int)k[0],Turn.turn);
        }
        _ai.ArrayCopy(Othello.Board,AI.CopyOthello);
        Turn.turn=Turn.turn *-1;
        //hasClicked = 1; 
        DrawHint();
    }
    public void DrawHint()
    {
        if (!Turn.Won)
        {
            bool flage = false;
            count.ChangeCount();
            //_change.ChangeOthello(Othello.Board,7-(int)clickedTile.x,(int)clickedTile.y,Turn.turn);
            foreach (Transform child in hint.transform) {
                Destroy(child.gameObject);
            }
            _findMoves.Moves();
            //Debug.Log("VAR");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (FindMoves.GETMoves[i,j]==2)
                    {
                        var hintRed=  Instantiate(redPrefab, new Vector2(j, 7-i), Quaternion.identity);
                        hintRed.transform.parent = hint.transform;
                        flage = true;
                    }

               
                }
            }

            if (!flage)
            {
                ThereIsMove();
            }
        }
    }

  
}
