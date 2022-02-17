using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class Background : Sprite
{

    public Background(TiledObject obj = null) : base("background.png")
    {
        this.collider.isTrigger = true;
    }
}
