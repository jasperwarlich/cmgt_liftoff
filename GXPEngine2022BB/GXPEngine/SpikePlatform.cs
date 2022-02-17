using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class SpikePlatform : Sprite {

    public SpikePlatform(TiledObject obj = null) : base("spikey_tile.png") 
    {
        SetScaleXY(1, .6f);
        this.collider.isTrigger = true;
    }
}
