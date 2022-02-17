using GXPEngine;
using System;
using TiledMapParser;
using System.Collections.Generic;

public class Level : GameObject
{

    public Player player { get; private set; }

    private TiledLoader loader;
    public HUD hud;

    private List<Platform> platforms;


    public Level(string filename)
    {
        loader = new TiledLoader(filename);

        var myMap = loader.map;
        int heightpixels = myMap.Height * myMap.TileHeight;
        SetXY(0, -heightpixels + game.height);

        CreateLevel();
    }

    void Update()
    {
        hud.ChechScore();
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
        loader.AddManualType("Platform", "FragilePlatform", "Player", "Wings", "DoubleJump", "Button", "BackButton", "Background");
        loader.OnObjectCreated += TiledLoader_OnObjectCreated;
        loader.LoadObjectGroups();
        loader.addColliders = true;
        loader.LoadTileLayers(0);
        loader.addColliders = false;
        loader.LoadTileLayers(1);

        player = FindObjectOfType<Player>();
        //hud = new HUD(player);
        //parent.AddChild(hud);
    }

    private void TiledLoader_OnObjectCreated(Sprite sprite, TiledObject obj)
    {
        if (obj.Type == "Platform")
        {
            Platform platform = new Platform("solidTile.png");
            platform.SetXY(obj.X, obj.Y);
            AddChild(platform);
        }

        if (obj.Type == "FragilePlatform")
        {
            FragilePlatform fragilePlatform = new FragilePlatform();
            fragilePlatform.SetXY(obj.X, obj.Y);
            AddChild(fragilePlatform);
        }

        if (obj.Type == "Leaf")
        {
            Leaf wings = new Leaf();
            wings.SetXY(obj.X, obj.Y);
            AddChild(wings);
        }

        if (obj.Type == "DoubleJumpPowerUp")
        {
            DoubleJumpPowerUp doubleJump = new DoubleJumpPowerUp();
            doubleJump.SetXY(obj.X, obj.Y);
            AddChild(doubleJump);
        }

        if (obj.Type == "Player")
        {
            Player player = new Player();
            player.SetXY(obj.X, obj.Y);
            AddChild(player);
        }

        if (obj.Type == "Button")
        {
            Button button = new Button();
            button.SetXY(obj.X, obj.Y);
            AddChild(button);
        }

        if (obj.Type == "BackButton")
        {
            BackButton button = new BackButton();
            button.SetXY(obj.X, obj.Y);
            AddChild(button);
        }
        if (obj.Type == "Background")
        {
            Background background = new Background();
            background.SetXY(obj.X, obj.Y);
            AddChild(background);
        }
    }

 
}
