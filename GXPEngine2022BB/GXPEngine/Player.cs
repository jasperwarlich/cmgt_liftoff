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
    private bool isJumping;
    private int boundary;
    private float highest;
    private bool firstTime;

    public Player(TiledObject obj = null) : base("barry.png", 7, 1, -1, false, true)
    {
        boundary = game.height / 2;
    }

    void Update()
    {
        Movement();
        PlayerJump();
        // CameraFollow();
       // if (this.y > game.y) { Console.WriteLine("aaaaaaaa"); }
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
            if (ySpeed > 0)
            {
                isJumping = false;
            }
            ySpeed = 0;
        }

        if (Input.GetKeyDown(Key.SPACE) && !isJumping)
        {
            ySpeed = jumpSpeed;
            // isJumping = true;
        }
    }

    void CameraFollow()
    {
        parent.y = game.height - boundary - y;
        if (!firstTime)
        {
            firstTime = true;
            highest = parent.y;
        }
        if (parent.y <= highest) parent.y = highest;
        else
        {
            highest = parent.y;
        }
    }

    void OnCollision(GameObject other)
    {
        if (other is Platform && other.y > this.y + 50)
        {
            other.collider.isTrigger = false;

        }
        // else { other.collider.isTrigger = true; }
    }
}