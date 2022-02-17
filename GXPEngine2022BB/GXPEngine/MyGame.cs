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

    Sound menuBackgroundMusic;
    SoundChannel musicChannel;

    public MyGame() : base(1366, 768, false)        // Create a window that's 800x600 and NOT fullscreen
    {
        OnAfterStep += CheckLoadLevel;
        LoadLevel(levelName);
        menuBackgroundMusic = new Sound("Sounds/menuMusic.mp3", true, true);
       // musicChannel = menuBackgroundMusic.Play(false, 0, .5f, 0);
    }

    void Update()
    {
        if (level != null)
        {  
            if (levelName == "map.tmx")
            {
                level.y += .5f;
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
            if (levelName == "mainmenu.tmx") {
                Settings.score = 0;
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