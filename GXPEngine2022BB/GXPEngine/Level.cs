using GXPEngine;
using System;
using TiledMapParser;
using System.Collections.Generic;

public class Level : GameObject {
    private TiledLoader loader;

    public Player player { get; private set; }

    HUD hud;

    List<Platform> platforms;
    List<DoubleJumpPowerUp> doubleJumps;
    private int platformAmount;
    private int doublePlatformAmount;


    public Level(string filename)
    {
        //SetXY(0, -150);
        loader = new TiledLoader(filename);

        /*
        player = new Player();
        AddChild(player);
        player.SetXY(200, 200);
        */

        platforms = new List<Platform>();
        doubleJumps = new List<DoubleJumpPowerUp>();
        CreateLevel();
        platformAmount = platforms.Count;
        doublePlatformAmount = doubleJumps.Count;
        //PlatformsSpawn();
    }

    void Update()
    {
        hud.ChechScore();
        //PlatformsCheck();
        //PlatformsSpawn();
    }

    /*
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
            DoubleJumpPowerUp doubleJplatform = doubleJumps[i];
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
            DoubleJumpPowerUp platform = new DoubleJumpPowerUp();
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
            Platform platform = new Platform("leaf_platform_80.png");
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
    }*/

    void CreateLevel()
    {
        loader.rootObject = this;
        loader.autoInstance = true;
        loader.AddManualType("Platform", "DoubleJumpPlatform", "Player");
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
            Platform platform = new Platform("leaf_platform_80.png");
            platform.SetXY(obj.X, obj.Y);
            platforms.Add(platform);
            AddChild(platform);
        }

        if (obj.Type == "DoubleJumpPlatform")
        {
            DoubleJumpPowerUp platform = new DoubleJumpPowerUp();
            platform.SetXY(obj.X, obj.Y);
            doubleJumps.Add(platform);
            AddChild(platform);
        }
       if (obj.Type == "Player")
        {
            Player player = new Player();
            player.SetXY(obj.X, obj.Y);
            game.AddChild(player);
        }
    }
}