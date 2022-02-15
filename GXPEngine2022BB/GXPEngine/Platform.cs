﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class Platform : Sprite
{
    private int movingSpeed = 0;


    public Platform(String image, TiledObject obj = null) : base(image)
    {
        SetXY(Utils.Random(width, game.width - width), Utils.Random(-80, -50));
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
}