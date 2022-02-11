using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Blabla : Sprite {

    int numberToSpawn = 10;

    List<Sprite> platforms = new List<Sprite>();
    public Blabla() : base ("leaf_platform_80.png") {
        
        int randomPlatform = 10;
        Sprite toSpawn = new Sprite("leaf_platform_80.png");

        int screenX, screenY;

        for (int i = 0; i < numberToSpawn; i++)
        {
            randomPlatform = Utils.Random(0, platforms.Count);
            toSpawn = platforms[randomPlatform];
            platforms.Add(toSpawn);
            screenX = Utils.Random(50, 1300);
            screenY = Utils.Random(0, 100);
            toSpawn.SetXY(screenX, screenY);
            game.AddChild(toSpawn);
        }
    }
    void Update() {
        Console.WriteLine(platforms.Count);
    }
}
