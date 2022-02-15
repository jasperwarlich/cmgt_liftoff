using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class Player : AnimationSprite
{
    private int speed = 3;
    private float gravity = 0.9f;
    private float ySpeed = 0;
    private float jumpSpeed = -25;
    private bool isJumping;
    private bool isMoving;
    private bool isFacingRight;

    public bool doubleJump { get; private set; }

    public int score { get; private set; }

    public bool playerDead { get; private set; }

    private int boundary;
    private float highest;
    private bool firstTime;

    Sprite sensor;

    public Player(TiledObject obj = null) : base("playerSpritesheet.png", 4, 4, -1, false, true)
    {
        boundary = game.height / 2;
        SetOrigin(width/2, height/2);
        this.SetScaleXY(.5f,.5f);
        score = 0;
        playerDead = false;
        isJumping = false;
        sensor = new Sprite("circle.png");
        AddChild(sensor);
        sensor.SetXY((width/2) - 60, height);
        sensor.alpha = 0.5f;
    }

    void Update()
    {
        Animate(.06f);
        Movement();
        PlayerJump();
        PlayerDead();
        Animations();
        CheckPlatform();
       // CameraFollow();
        // if (this.y > game.y) { Console.WriteLine("aaaaaaaa"); }
    }
    private void Animations()
    {
        //Moving animation
        if (!isMoving)
        {
            //Idle animation
            SetCycle(1, 3);
            Animate(0.02f);
        }
        else
        {
            //Walking animation
            SetCycle(7, 8);
            Animate(0.02f);
        }
        //Jumping animation
        if (isJumping)
        {
            SetCycle(4, 3);
            Animate(0.02f);
        }
    }

    void Movement()
    {
        int xSpeed = 0;

        if (Input.GetKey(Key.D)) {
            xSpeed = speed;
            isMoving = true;
            if (!isFacingRight)
            {
                Flip();
            }
        }
        else if (Input.GetKey(Key.A)) { 
            xSpeed = -speed; 
            isMoving = true;
            if (isFacingRight)
            {
                Flip();
            }
        }
        else { isMoving = false; }


        Move(xSpeed, 0);
        //MoveUntilCollision(xSpeed, 0);
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
        else { isJumping = true; }

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
        if (isJumping)
        {
            score++;
            isMoving = false;
        }
    }

    void PlayerDead() {
        if (this.y > game.height)
        {
            playerDead = true;
        }
    }

    void OnCollision(GameObject other)
    {
        if (other is DoubleJumpPowerUp)
        {
            doubleJump = true;
            other.LateDestroy();
        }

        if (other is Wings)
        {
            score += 100;
            other.LateDestroy();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        scaleX *= -1;
    }

    void CheckPlatform() {
        foreach (GameObject other in sensor.GetCollisions())
        {
            if (other is FragilePlatform) {
               FragilePlatform fragilePlatform = other as FragilePlatform;
                fragilePlatform.Timer();
            }
        }
    }
    /*void CameraFollow()
    {
        game.y = game.height - boundary - y;
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