using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;
public class Platform : Sprite
{
   
    public Platform(TiledObject obj = null) : base("circle.png")
    {
        this.collider.isTrigger = false;
    }

    void Update()
    {

    }
}