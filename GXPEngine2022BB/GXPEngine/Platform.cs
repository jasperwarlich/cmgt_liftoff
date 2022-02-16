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

    }

    public void Update()
    {
       /*if (((MyGame)game).level.player.y > y)
        {
            this.collider.isTrigger = true;
        }
        else { this.collider.isTrigger = false; }
        */
    }
}