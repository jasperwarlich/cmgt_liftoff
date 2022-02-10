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
    private float movingSpeed;

    public Platform(TiledObject obj = null) : base("leaf_platform_80.png")
    {
        this.collider.isTrigger = false;
        startMoving = false;
        movingSpeed = 0f;
    }

    protected virtual void Update()
    {
        IncreaseDifficulty();
        if (startMoving)
        {
            movingSpeed = 3f;
            this.y += movingSpeed;
        }
        else { movingSpeed = 0f;  }
        if (this.y > game.height)
        {
            SetXY(Utils.Random(100, 1300), Utils.Random(-50, -30));
        }

        if (((MyGame)game).level.player.y >= y)
        {
            this.collider.isTrigger = true;
        }
        else { this.collider.isTrigger = false; }
        if (Input.AnyKey())
        {
            startMoving = true;
        }
    }

    void IncreaseDifficulty() {
        if (((MyGame)game).level.player.score >= 1000) { movingSpeed = 5f; }
    }

    void OnCollision(GameObject other)
    {
        if (other is Platform)
        {
            SetXY(Utils.Random(100, 1300), Utils.Random(-50, -30));
        }
    }
}