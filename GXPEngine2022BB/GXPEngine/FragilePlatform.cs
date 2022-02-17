using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class FragilePlatform : Platform
{
    public bool detect;

    private int timer = 2500;

    public FragilePlatform(TiledObject obj = null) : base("leaf_platform_80.png")
    {
        detect = false;
    }
    void Update() {
        Console.WriteLine(timer);

    }
    public void Timer()
    {
        timer -= Time.time / 1000;
        if (detect) {          
            if (timer <= 0)
            {
                this.LateDestroy();
                timer = 2500;
            }
        }
    }
}
