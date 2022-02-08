using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class Player : AnimationSprite
{
    private int speed = 5;
    private float gravity = 0.2f;
    private float ySpeed = 0;
    private float jumpSpeed = -10;
    int boundary;
    float highest;
    bool firstTime;
    public Player(TiledObject obj = null) : base("barry.png", 7, 1, -1, false, true)
    {
        boundary = game.height / 2;
        Console.WriteLine(highest);
    }
    void Update()
    {
        Movement();
        PlayerJump();
        CameraFollow();
    }

    void Movement()
    {
        int xSpeed = 0;

        if (Input.GetKey(Key.D)) xSpeed = speed;
        if (Input.GetKey(Key.A)) xSpeed = -speed;

        MoveUntilCollision(xSpeed, 0);
    }

    void PlayerJump()
    {
        ySpeed += gravity;

        if (MoveUntilCollision(0, ySpeed) != null)
        {
            ySpeed = 0;
        }

        if (Input.GetKeyDown(Key.SPACE))
        {
            ySpeed = jumpSpeed;
        }
    }

    void CameraFollow()
    {
        parent.y = game.height - boundary - y;
        if (!firstTime) {
            firstTime = true;
            highest = parent.y;
        }
        if (parent.y <= highest) parent.y = highest;
        else {
            highest = parent.y;
        }
    }
}