using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSetter : MonoBehaviour
{
    private MazeMap map;
    [SerializeField] List<MazeTile> tileList = new List<MazeTile>();
    [SerializeField] Pathfinding pathfinding;
    private TypeToTileConverter converter;
    private List<MazeBot> bots = new List<MazeBot>();

    public List<MazeBot> Bots { get => bots; set => bots = value; }
    public MazeMap Map { get => map; set => map = value; }

    private void Awake()
    {
        this.converter = TypeToTileConverter.GetInstance();
        converter.SetArray(tileList.ToArray());
        map = new MazeMap(6, 12, 0.5f, tileList[0], MazeModes.Bet);

    }

    private void Start()
    {
        var mazeManager = new MazeManager();
        var http = gameObject.AddComponent<HttpRequestHelper>();
        CoroutineWithData cd = new CoroutineWithData(this,http.GetMazeJsonUpr());
        StartCoroutine(mazeManager.WaitForJson(cd, FileMode.Load));


        CreateBot();
    }

    internal void SetBots(List<MazeBot> deadBots)
    {
        foreach (MazeBot bot in deadBots)
            bots.Remove(bot);
    }

    public void CreateBot()
    {
        Vector2[] corresp = new Vector2[8];
        corresp[0] = new Vector2( 1, 0);
        corresp[1] = new Vector2( 2, 0);
        corresp[2] = new Vector2( 3, 0);
        corresp[3] = new Vector2( 4, 0);
        corresp[4] = new Vector2( 1, 11);
        corresp[5] = new Vector2( 2, 11);
        corresp[6] = new Vector2( 3, 11);
        corresp[7] = new Vector2( 4, 11);

        Debug.Log("MazeBet, CreateBot : start");
        pathfinding = new Pathfinding(map.GetGrid());

        for (int i = 0; i < 8; i++)
        {
            var team = "";
            if (i < 4) team = "blue";
            else team = "red";
            GameObject gameObject = new GameObject("bot_" + team +"_"+ i, typeof(BotBank));
            var bot = gameObject.GetComponent<BotBank>();
            
            bot.SetGrid(map.GetGrid());
            bot.Initialize((int)corresp[i].x, (int)corresp[i].y);

            var col = gameObject.AddComponent<BoxCollider2D>();
            col.isTrigger = true;
            col.size = new Vector2(0.04f, 0.04f);



            if (i < 4) bot.SetColor(Color.blue);
            else { bot.SetColor(Color.red); bot.Team = 1; };

            bots.Add(gameObject.GetComponent<BotBank>());
        }
    }

    public List<MazeTile> CheckPathfinding(MazeTile startTile, MazeTile endTile)
    {
        return pathfinding.FindPath(startTile.GetXPos(), startTile.GetYPos(), endTile.GetXPos(), endTile.GetYPos());
    }

    public MazeBot CheckBotOnATile(MazeTile tile)
    {
        foreach(MazeBot bot in bots)
        {
            if (bot.CurrentTile == tile) return bot;
        }
        return null;
    }
    public MazeBot CheckBotOnATile(int x, int y)
    {
        foreach (MazeBot bot in bots)
        {
            if (bot.CurrentTile.GetXPos() == x && bot.CurrentTile.GetXPos() == y) return bot;
        }
        return null;
    }

}
