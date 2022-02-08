using GXPEngine;
using TiledMapParser;

public class Level : GameObject {
    private TiledLoader loader;


    public Level(string filename)
    {
        loader = new TiledLoader(filename);
        CreateLevel();
    }
    void Update()
    {

    }
    void CreateLevel()
    {
        loader.autoInstance = true;
        loader.addColliders = false;
        loader.LoadTileLayers(0);
        loader.addColliders = true;
        loader.LoadTileLayers(1);
        loader.LoadObjectGroups();
    }

}

