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
    private float gravity = 0.9f;
    private float ySpeed = 0;
    private float jumpSpeed = -25;
    private bool isJumping;
    private bool doubleJump;

    public int score { get; private set; }

    public bool playerDead { get; private set; }

    //private int boundary;
    //private float highest;
    //private bool firstTime;

    public Player(TiledObject obj = null) : base("barry.png", 7, 1, -1, false, true)
    {
        // boundary = game.height / 2;
        score = 0;
        playerDead = false;
    }

    void Update()
    {
        Movement();
        PlayerJump();
        PlayerDead();
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

        if (Input.GetKeyDown(Key.SPACE))
        {
            if (!isJumping)
            {
                ySpeed = jumpSpeed;
                isJumping = true;
            }
            else if (doubleJump)
            {
                ySpeed = jumpSpeed;
                doubleJump = false;
            }
        }   
        if(isJumping)
            score++;
    }

    void PlayerDead() {
        if (this.y > game.height)
        {
            playerDead = true;
        }
    }

    void OnCollision(GameObject other)
    {
        if (other is DoubleJumpPlatform)
        {
            doubleJump = true;
        }
        else { doubleJump = false; }
    }

    /*void CameraFollow()
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
    }*/

}