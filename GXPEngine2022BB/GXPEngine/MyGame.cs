using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.Collections.Generic;
using System.IO;

public class MyGame : Game
{
    public string levelName = "mainmenu.tmx";
    public Level level;

    string nextLevel = null;

    float scrollingSpeed = 10.0f;
    bool endLevel;

    Sound menuBackgroundMusic;
    SoundChannel musicChannel;

    public MyGame() : base(1366, 768, true)        // Create a window that's 800x600 and NOT fullscreen
    {
        OnAfterStep += CheckLoadLevel;
        LoadLevel(levelName);
        menuBackgroundMusic = new Sound("Sounds/backgroundMusic.wav", true, true);
        musicChannel = menuBackgroundMusic.Play(false, 0, .5f, 0);
    }

    void Update()
    {
        if (level != null)
        {
            if (levelName == "map.tmx")
            {
                level.y += scrollingSpeed;
                if(level.player.y > level.y)
                {
                    Console.WriteLine("Player out of screen");
                }
                if (level.y >= game.y)
                {
                    scrollingSpeed = 0;
                    level.y = game.y;
                    endLevel = true;
                    if (endLevel)
                    {
                        DestroyLevel();
                        levelName = "endmenu.tmx";
                        LoadLevel(levelName);
                    }
                }
            }
            if (level.player != null)
            {
                if (level.player.playerDead)
                {
                    DestroyLevel();
                    levelName = "endmenu.tmx";
                    LoadLevel(levelName);
                }
            }
        }

        ScrollingSpeed();

        var screenPos = TransformPoint(0, 0);
        if (screenPos.y == game.height)
        {
            scrollingSpeed = 0;
        }
    }

    void ScrollingSpeed()
    {
        if (Settings.score < 500)
        {
            scrollingSpeed = 1f;
        }
        if (Settings.score >= 500 && Settings.score <= 1000)
        {
            scrollingSpeed = 1.5f;
        }
        else if (Settings.score >= 1000 && Settings.score <= 1500)
        {
            scrollingSpeed = 2f;
        }
        else if (Settings.score >= 1500) { scrollingSpeed = 3f; }
        else if (Settings.score >= 2500) { scrollingSpeed = 4f; }
        else if (Settings.score >= 3500) { scrollingSpeed = 5f; }
        
    }

    void CheckLoadLevel()
    {
        if (nextLevel != null)
        {
            DestroyLevel();
            level = new Level(nextLevel);
            AddChild(level);
            level.hud = new HUD(level.player);
            AddChild(level.hud);
            nextLevel = null;
        }
    }

    public void DestroyLevel()
    {
        List<GameObject> children = GetChildren();
        foreach (GameObject child in children)
        {
            child.Destroy();
        }
    }
    public void LoadLevel(string filename)
    {
        nextLevel = filename;
    }

    static void Main()                          // Main() is the first method that's called when the program is run
    {
        Settings.Load();
        new MyGame().Start();                   // Create a "MyGame" and start it
    }
}