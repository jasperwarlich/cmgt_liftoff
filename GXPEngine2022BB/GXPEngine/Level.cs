using GXPEngine;
using System;
using TiledMapParser;
using System.Collections.Generic;

public class Level : GameObject {
    private TiledLoader loader;

    public Player player { get; private set; }
    public Level(string filename)
    {
        loader = new TiledLoader(filename);
        CreateLevel();
    }

    void Update()
    {
        this.y = game.y;
    }
    void CreateLevel()
    {
        
        loader.autoInstance = true;
        loader.LoadObjectGroups();
        loader.addColliders = true;
        loader.LoadTileLayers(1);
        loader.addColliders = false;
        loader.rootObject = this;
        loader.LoadTileLayers(0);
            
        
        player = FindObjectOfType<Player>();
    }
}

