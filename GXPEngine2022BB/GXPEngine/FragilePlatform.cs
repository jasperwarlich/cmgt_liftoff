using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class FragilePlatform : Platform
{
    int timer = 0;


    public FragilePlatform(TiledObject obj = null) : base("circle.png")
    {

    }
    public void Timer()
    {
        timer = Time.time / 1000;
        if (timer >= 2)
        {
            this.LateDestroy();
            timer = 0;
        }
    }
}
