using GXPEngine;
using System;
using TiledMapParser;
using System.Collections.Generic;

public class Level : GameObject {
    private TiledLoader loader;

    public Player player { get; private set; }

    HUD hud;

    List<Platform> platforms;
    List<DoubleJumpPlatform> doubleJumps;
    private int platformAmount;
    private int doublePlatformAmount;


    public Level(string filename)
    {
        //SetXY(0, -150);
        loader = new TiledLoader(filename);

        platforms = new List<Platform>();
        doubleJumps = new List<DoubleJumpPlatform>();
        CreateLevel();
        platformAmount = platforms.Count;
        doublePlatformAmount = doubleJumps.Count;
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
            }          
        }

        for (int i = 0; i < doubleJumps.Count; i++)
        {
            DoubleJumpPlatform doubleJplatform = doubleJumps[i];
            if (doubleJplatform.y > game.height)
            {
                doubleJumps.Remove(doubleJplatform);
                RemoveChild(doubleJplatform);
            }
        }
    }

    private void PlatformsSpawn()
    {
        if (doubleJumps.Count < doublePlatformAmount)
        {
            DoubleJumpPlatform platform = new DoubleJumpPlatform();
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
            }
            
            doubleJumps.Add(platform);
            AddChild(platform);
        }

        if (platforms.Count < platformAmount)
        {
            Platform platform = new Platform();
            while (true)
            {

                GameObject[] collisions = platform.GetCollisions();


                for (int i = 0; i < collisions.Length; i++)
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
            }

            platforms.Add(platform);
            AddChild(platform);
        }
    }

    void CreateLevel()
    {
        loader.autoInstance = true;
        loader.AddManualType("Platform", "DoubleJumpPlatform");
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

        if (obj.Type == "DoubleJumpPlatform")
        {
            DoubleJumpPlatform platform = new DoubleJumpPlatform();
            platform.SetXY(obj.X, obj.Y);
            doubleJumps.Add(platform);
            AddChild(platform);
        }

    }
}