using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class Platform : Sprite
{
    public Platform(String image, TiledObject obj = null) : base(image)
    {
        this.collider.isTrigger = true;
    }
    
}