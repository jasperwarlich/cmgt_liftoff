using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class Platform : Sprite
{
    private bool startMoving;
    private int movingSpeed = 0;


    public Platform(TiledObject obj = null) : base("leaf_platform_80.png")
    {
        SetXY(Utils.Random(width, game.width - width), Utils.Random(-80, -50));
        this.collider.isTrigger = false;
        startMoving = false;
        movingSpeed = 0;
        Console.WriteLine(height);
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
            movingSpeed = 0;
            this.y += movingSpeed;
        }

        else if (((MyGame)game).level.player.score >= 500)
        {
            movingSpeed = 0;
            this.y += movingSpeed;
        }
        else { movingSpeed = 0; }
    }

    void OnCollision(GameObject other)
    {
        //if (other is Platform)
        //{
        //    SetXY(Utils.Random(100, 1300), Utils.Random(-50, -30));
        //}
    }
}