using UnityEngine;
using UnityEditor;

using System.Collections;
using System.Collections.Generic;

using UnityEngine.Tilemaps;

public class MyTileMapEvent : MonoBehaviour
{
    Tilemap tile;
    bool paint;
    bool clear;
    // Start is called before the first frame update
    void Start()
    {

        paint = false;
        clear = false;
        tile = gameObject.GetComponent<Tilemap>();
        paintSomething();
    }

    public void paintSomething()
    {
        paint = true;
        clear = false;
        
    }

    public void removeSomething()
    {
        paint = false;
        clear = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (paint) { 
            tile.SetTile(new Vector3Int(0, -1, 1), Resources.Load<Tile>("MyTile"));
            tile.SetTile(new Vector3Int(1, -1, 1), Resources.Load<Tile>("MyTile2"));
        }
        if (clear) { 
            tile.SetTile(new Vector3Int(0, -1, 1), null);
            tile.SetTile(new Vector3Int(1, -1, 1), null);
        }
    }
}
