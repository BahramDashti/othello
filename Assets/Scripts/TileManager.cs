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
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;

    public Vector2 clickedTile;
    private Dictionary<Vector2, Tile> _tiles;
    
    private FindMoves _findMoves;
    private Change _change;
    void Awake() {
        GenerateGrid();
        _findMoves = new FindMoves();
    }

    private void Start()
    {
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
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (FindMoves.GETMoves[i,j]==2)
                {
                    goto OUT1;
                }

               
            }
        }

        Turn.turn = Turn.turn * -1;
        _findMoves.Moves();
        DrawHint();
        //todo:when all board is same color
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
        // _findMoves.Moves();
        
        OUT1: ;
    }
    public void DrawHint()
    {
        //_change.ChangeOthello(Othello.Board,7-(int)clickedTile.x,(int)clickedTile.y,Turn.turn);
        foreach (Transform child in hint.transform) {
            Destroy(child.gameObject);
        }
        _findMoves.Moves();
        Debug.Log("VAR");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (FindMoves.GETMoves[i,j]==2)
                {
                    var hintRed=  Instantiate(redPrefab, new Vector2(j, 7-i), Quaternion.identity);
                    hintRed.transform.parent = hint.transform;
                }

               
            }
        }
    }
}
