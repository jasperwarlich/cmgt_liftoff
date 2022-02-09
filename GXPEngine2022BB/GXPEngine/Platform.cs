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
        this.y += 1f;
        //Console.WriteLine(y);
        if (this.y > game.height)
        {
            SetXY(Utils.Random(100, 1300), Utils.Random(-150, -100));
        }

        if (((MyGame)game).level.player.y > y)
        {
            this.collider.isTrigger = true;
        }
        else { this.collider.isTrigger = false; }
    }

    void OnCollision(GameObject other)
    {
        if (other is Platform)
        {
            SetXY(Utils.Random(100, 1300), Utils.Random(-150, -100));
        }
    }
}