using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class FragilePlatform : Platform
{
    int timer = 1000;

    public bool detect;
    public FragilePlatform(TiledObject obj = null) : base("circle.png")
    {
        detect = false;
    }

    //void Update() { base.Update(); }

    public void Timer()
    {
        timer -= Time.time / 1000;
        
        if (detect) {
           
            if (timer <= 0)
            {
                this.LateDestroy();
                timer = 1000;
            }
        }
    }
}
