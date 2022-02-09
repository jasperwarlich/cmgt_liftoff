using GXPEngine;
using System;
using TiledMapParser;
using System.Collections.Generic;

public class Level : GameObject {
    private TiledLoader loader;

    public Player player { get; private set; }

    HUD hud;

    public Level(string filename)
    {
        loader = new TiledLoader(filename);
        CreateLevel();
    }

    void Update()
    {
        Console.WriteLine(player);
    }
    void CreateLevel()
    {
      
        loader.autoInstance = true;
        loader.LoadObjectGroups();
        loader.addColliders = true;
        loader.LoadTileLayers(1);
        loader.addColliders = false;
        loader.LoadTileLayers(0);
       
        player = game.FindObjectOfType<Player>();
        hud = new HUD();
        game.AddChild(hud);
    }
}