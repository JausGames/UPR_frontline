using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTrap : MazeTile
{
    // Start is called before the first frame update
    void Awake()
    {
        type = TileTypes.Trap;
        sprite = Resources.Load<Sprite>("Sprites/tile01");
        renderer = GetComponent<SpriteRenderer>();
        SetColor(new Color(0.6f, 0, 0));
        SetGameEnder(true);
    }
}
