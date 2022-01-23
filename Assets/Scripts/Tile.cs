using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Tile : MonoBehaviour
{

    [SerializeField] private GameObject blackPrefab;
    [SerializeField] private GameObject whitePrefab;
    [SerializeField] private GameObject redPrefab;
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;

    private FindMoves _findMoves;
   // [SerializeField] private GameObject _highlight;
    private int hasClicked = 0;

    private void Awake()
    {
        var position = gameObject.transform.position;
        int x = (int) position.x;
        int y = (int) position.y;
        _findMoves = new FindMoves();
        
    }

    private void Start()
    {
       // Debug.Log("dasdasdasdasdasdad");
        var position = gameObject.transform.position;
        int x = (int) position.x;
        int y = (int) position.y;
        if (FindMoves.GETMoves[7-y,x] == 2)
        {
            Debug.Log("sssssssssssssssssssssssssssssssssss");
            var spawnedTile = Instantiate(redPrefab, transform);
            spawnedTile.transform.localPosition = new Vector3(0, 0, 0);
            
        }
        
        if (Othello.Board[7-y, x] != 0)
        {
            if (Othello.Board[7-y,x] == -1)
            {
                var spawnedTile = Instantiate(blackPrefab, transform);
                spawnedTile.transform.localPosition = new Vector3(0, 0, 0);
                hasClicked = 1;
            }
            else if (Othello.Board[7-y, x] == 1)
            {
                var spawnedTile = Instantiate(whitePrefab, transform);
                spawnedTile.transform.localPosition = new Vector3(0, 0, 0);
                hasClicked = 1;
            }
            
           
        }
        
        
        
    }

    private void Draw()
    {
        int x = (int) gameObject.transform.position.x;
        int y = (int) gameObject.transform.position.y;

        if (Othello.Board[7-y, x] != 0)
        {
            if (Othello.Board[7-y,x] == -1)
            {
                var spawnedTile = Instantiate(blackPrefab, transform);
                spawnedTile.transform.localPosition = new Vector3(0, 0, 0);
            }
            else if (Othello.Board[7-y,  x] == 1)
            {
                var spawnedTile = Instantiate(whitePrefab, transform);
                spawnedTile.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
    

    public void Init(bool isOffset) {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    private void OnMouseDown()
    {
       
        
        int x=(int)gameObject.transform.position.x;
        int y=(int)gameObject.transform.position.y;
        
        if (Turn.turn==-1 && hasClicked==0)
        {
            Turn.turn = 1;
            Othello.Board[7-y,x] = -1;
            
            Draw();
            
            hasClicked = 1;
            
            
            
        } 
        else if (Turn.turn==1 && hasClicked==0)
        {
            Turn.turn = -1;
            Othello.Board[7-y, x] = 1;
            Draw();
            
            hasClicked = 1;
            
        }

        Debug.Log(Othello.Board[y,7-x]);
    }

    // private void OnMouseEnter() {
    //     _highlight.SetActive(true);
    //    
    // }
    //
    // private void OnMouseExit()
    // {
    //     _highlight.SetActive(false);
    // }
}
