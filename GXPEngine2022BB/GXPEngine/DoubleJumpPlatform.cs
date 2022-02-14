using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;
public class DoubleJumpPlatform : Sprite
{

    private int movingSpeed;

    public DoubleJumpPlatform(TiledObject obj = null) : base ("circle.png")
    {
        SetXY(Utils.Random(width, game.width - width), Utils.Random(-80, -50));
    }

    public void Update()
    {


        if (((MyGame)game).level.player.y >= y)
        {
            this.collider.isTrigger = true;
        }
        else { this.collider.isTrigger = false; }
        /*if (Input.AnyKey())
        {
            startMoving = true;
        }*/
        IncreaseDifficulty();
    }

    void IncreaseDifficulty()
    {

        if (((MyGame)game).level.player.score < 500)
        {
            movingSpeed = 1;
            this.y += movingSpeed;
        }

        else if (((MyGame)game).level.player.score >= 500)
        {
            movingSpeed = 2;
            this.y += movingSpeed;
        }
        else { movingSpeed = 0; }
    }
}
