using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Serialization;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject blackPrefab;
    [SerializeField] private GameObject whitePrefab;
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;



    // [SerializeField] private GameObject _highlight;
    private Change _change;
    private int hasClicked = 0;
    private TileManager _parent;
    

    public Vector3 Position { get; set; }
    
    public GameObject Bead { get; set; }
    

    public void Init(bool isOffset) {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    private void Awake()
    {
        

        _parent = transform.parent.GetComponent<TileManager>();
        
        _change = new Change(_parent);
        
    }
    private void Start()
    {
        Position=gameObject.transform.position;
        var position = gameObject.transform.position;
        int x = (int) position.x;
        int y = (int) position.y;
        if (Othello.Board[7-y, x] != 0)
        {
            if (Othello.Board[7-y,x] == -1)
            {
                
                Bead = Instantiate(blackPrefab, transform);
                Bead.transform.localPosition = new Vector3(0, 0, 0);
                hasClicked = 1;
            }
            else if (Othello.Board[7-y, x] == 1)
            {
                
                Bead = Instantiate(whitePrefab, transform);
                Bead.transform.localPosition = new Vector3(0, 0, 0);
                hasClicked = 1;
            }
            
           
        }
    }

    public void UpdateTile()
    {
        var position = gameObject.transform.position;
        int x = (int) position.x;
        int y = (int) position.y;
        if (Othello.Board[7-y,x] != 0)
        {


            if (Othello.Board[7 - y, x] != 0)
            {
                if (Othello.Board[7 - y, x] == -1)
                {
                    ClearChildes();
                    Bead = Instantiate(blackPrefab, transform);
                    Bead.transform.localPosition = new Vector3(0, 0, 0);
                    hasClicked = 1;
                    
                    
                }
                else if (Othello.Board[7 - y, x] == 1 )
                {
                    ClearChildes();
                    Bead = Instantiate(whitePrefab, transform);
                    Bead.transform.localPosition = new Vector3(0, 0, 0);
                    hasClicked = 1;
                }
            }
        }
    }

    private void ClearChildes()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            var currentChild = transform.GetChild(i);
            Destroy(currentChild.gameObject);
        }
    }
    

    private void OnMouseDown()
    {
        
        var position = gameObject.transform.position;
        int x = (int) position.x;
        int y = (int) position.y;
        //_parent.ThereIsMove();
        _parent.DrawHint();
        if (FindMoves.GETMoves[7-y,x]==2)
        {

            if (Input.GetMouseButton(0) && hasClicked == 0)
            {
                if (Turn.turn==-1)
                {
                    
                    _parent.clickedTile = Position;
                    var spawnedTile = Instantiate(blackPrefab, transform);
                    spawnedTile.transform.localPosition = new Vector3(0, 0, 0);
                    Othello.Board[7-y,x] = -1;
                    
                    _change.ChangeOthello(Othello.Board,7-y,x,Turn.turn);
                    
                    Turn.turn = 1;
                    _parent.DrawHint();
                }
                if(Turn.AI)
                {
                    StartCoroutine(Delay());
                   
                    
                }

                if (Turn.turn==1 && !Turn.AI)
                {
                    _parent.clickedTile = Position;
                    var spawnedTile = Instantiate(whitePrefab, transform);
                    spawnedTile.transform.localPosition = new Vector3(0, 0, 0);
                    Othello.Board[7-y,x] = 1;
                    _change.ChangeOthello(Othello.Board,7-y,x,Turn.turn);
                    Turn.turn = -1;
                }
                hasClicked = 1; 
                _parent.DrawHint();
                
            }
        }
        
        
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Finished");
        _parent.AiTurn();
    }
    public void Lock()
    {
        hasClicked = 1;
    }
}

    // private void Awake()
    // {
    //     var position = gameObject.transform.position;
    //     int x = (int) position.x;
    //     int y = (int) position.y;
    //     _findMoves = new FindMoves();
    //     
    // }
    //
    // private void Start()
    // {
    //    // Debug.Log("dasdasdasdasdasdad");
    //     var position = gameObject.transform.position;
    //     int x = (int) position.x;
    //     int y = (int) position.y;
    //     if (FindMoves.GETMoves[7-y,x] == 2)
    //     {
    //         Debug.Log("sssssssssssssssssssssssssssssssssss");
    //         var spawnedTile = Instantiate(redPrefab, transform);
    //         spawnedTile.transform.localPosition = new Vector3(0, 0, 0);
    //         
    //     }
    //     
    //     if (Othello.Board[7-y, x] != 0)
    //     {
    //         if (Othello.Board[7-y,x] == -1)
    //         {
    //             var spawnedTile = Instantiate(blackPrefab, transform);
    //             spawnedTile.transform.localPosition = new Vector3(0, 0, 0);
    //             hasClicked = 1;
    //         }
    //         else if (Othello.Board[7-y, x] == 1)
    //         {
    //             var spawnedTile = Instantiate(whitePrefab, transform);
    //             spawnedTile.transform.localPosition = new Vector3(0, 0, 0);
    //             hasClicked = 1;
    //         }
    //         
    //        
    //     }
    //     
    //     
    //     
    // }
    //
    // private void Draw()
    // {
    //     int x = (int) gameObject.transform.position.x;
    //     int y = (int) gameObject.transform.position.y;
    //
    //     if (Othello.Board[7-y, x] != 0)
    //     {
    //         if (Othello.Board[7-y,x] == -1)
    //         {
    //             var spawnedTile = Instantiate(blackPrefab, transform);
    //             spawnedTile.transform.localPosition = new Vector3(0, 0, 0);
    //         }
    //         else if (Othello.Board[7-y,  x] == 1)
    //         {
    //             var spawnedTile = Instantiate(whitePrefab, transform);
    //             spawnedTile.transform.localPosition = new Vector3(0, 0, 0);
    //         }
    //     }
    // }
    //
    //
    // public void Init(bool isOffset) {
    //     _renderer.color = isOffset ? _offsetColor : _baseColor;
    // }
    //
    // private void OnMouseDown()
    // {
    //    
    //     
    //     int x=(int)gameObject.transform.position.x;
    //     int y=(int)gameObject.transform.position.y;
    //     
    //     if (Turn.turn==-1 && hasClicked==0)
    //     {
    //         Turn.turn = 1;
    //         Othello.Board[7-y,x] = -1;
    //         
    //         Draw();
    //         
    //         hasClicked = 1;
    //         
    //         
    //         
    //     } 
    //     else if (Turn.turn==1 && hasClicked==0)
    //     {
    //         Turn.turn = -1;
    //         Othello.Board[7-y, x] = 1;
    //         Draw();
    //         
    //         hasClicked = 1;
    //         
    //     }
    //
    //     Debug.Log(Othello.Board[y,7-x]);
    // }

    // private void OnMouseEnter() {
    //     _highlight.SetActive(true);
    //    
    // }
    //
    // private void OnMouseExit()
    // {
    //     _highlight.SetActive(false);
    // }
    // }
