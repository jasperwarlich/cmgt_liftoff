using GXPEngine;
using System;
using TiledMapParser;
using System.Collections.Generic;

public class Level : GameObject {
    private TiledLoader loader;

    public Player player { get; private set; }

    HUD hud;

    List<Platform> platforms;
    private int platformAmount;

    public Level(string filename)
    {
        //SetXY(0, -150);
        loader = new TiledLoader(filename);
        platforms = new List<Platform>();
        CreateLevel();
        platformAmount = platforms.Count;
        //PlatformsSpawn();
    }

    void Update()
    {
        foreach (Platform p in platforms)
        {
            p.Update();
        }
        hud.ChechScore();
        PlatformsCheck();
        PlatformsSpawn();
    }

    private void PlatformsCheck()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            Platform platform = platforms[i];
            if (platform.y > game.height)
            {
                platforms.Remove(platform);
                RemoveChild(platform);
                //while (true)
                //{
                //    SetXY(platform.x, Utils.Random(-180, -80));
                //    bool good = (platform.GetCollisions().Length <= 1);
 
                    
                //    //foreach (Platform plat in platforms)
                //    //{
                //    //    if (!platform.Equals(plat) && (platform.y + platform.height <= plat.y || platform.y >= plat.y + plat.height)) awesome = true;
                //    //    else awesome = false;
                //    //    if (!platform.Equals(plat)) Console.WriteLine(Mathf.Abs(platform.y - plat.y));

                //    //}

                //    if (good && awesome) break;
                //}
            }
            
        }
    }

    private void PlatformsSpawn()
    {
        if (platforms.Count < platformAmount)
        {
            Platform platform = new Platform();
            while (true)
            {

                GameObject[] collisions = platform.GetCollisions();


                for (int i  = 0; i < collisions.Length; i++)
                {
                    if (collisions[i].GetType().Equals(typeof(Player)) && collisions.Length >= 1) continue;
                    else
                    {
                        platform.y += platform.height;
                        break;
                    }
                   // break;
                }

                collisions = platform.GetCollisions();
                if (collisions.Length <= 1) break;

                //foreach (Platform p in platforms)
                //{
                //    if (platform.y + platform.height < p.y && platform.y > p.y + p.height) good = true;
                //    else
                //    {
                //        good = false;
                //        break;
                //    }
                //}
                //if (good) break;
            }
            
            platforms.Add(platform);
            AddChild(platform);
        }
    }

    void CreateLevel()
    {
        loader.autoInstance = true;
        loader.AddManualType("Platform");
        loader.OnObjectCreated += TiledLoader_OnObjectCreated;
        loader.LoadObjectGroups();
        loader.addColliders = true;
        loader.LoadTileLayers(0);
        loader.addColliders = false;
        loader.LoadTileLayers(1);
       
        player = game.FindObjectOfType<Player>();
        hud = new HUD(player);
        game.AddChild(hud);
    }

    private void TiledLoader_OnObjectCreated(Sprite sprite, TiledObject obj)
    {
        if (obj.Type == "Platform") { 
            Platform platform = new Platform();
            platform.SetXY(obj.X, obj.Y);
            platforms.Add(platform);
            AddChild(platform);
        }
    }
}