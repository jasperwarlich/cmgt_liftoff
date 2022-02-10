using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.Collections.Generic;

public class MyGame : Game
{
    string levelName = "map.tmx";
    string nextLevel = null;
    public Level level;

    public MyGame() : base(1366, 768, false)        // Create a window that's 800x600 and NOT fullscreen
    {
        OnAfterStep += CheckLoadLevel;
        LoadLevel(levelName);
    }

    void Update()
    {
        if (level != null)
        {
            if (level.player.playerDead)
            {
                DestroyLevel();
                LoadLevel(levelName);
            }
        }
    }
    
    void CheckLoadLevel()
    {
        if (nextLevel != null)
        {
            DestroyLevel();
            level = new Level(nextLevel);
            AddChild(level);
            nextLevel = null;
        }
    }

    void DestroyLevel()
    {
        List<GameObject> children = GetChildren();
        foreach (GameObject child in children)
        {
            child.Destroy();
        }
    }
    void LoadLevel(string filename)
    {
        nextLevel = filename;
    }
    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();                   // Create a "MyGame" and start it
    }
}