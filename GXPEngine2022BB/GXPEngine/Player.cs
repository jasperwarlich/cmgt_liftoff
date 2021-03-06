using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class Player : AnimationSprite
{
    public bool doubleJump { get; private set; }

    public int score { get; private set; }

    public bool playerDead { get; private set; }

    private int speed = 5;
    private float gravity = 0.5f;
    private float ySpeed = 0;
    private float jumpSpeed = -17;
    private bool isJumping;
    private bool isMoving;
    private bool isFacingRight;

    private int boundary;
    private float highest;
    private bool firstTime;

    private Sprite sensor;
    private Sprite sensorHead;

    private Sound jumpSound;
    private Sound pickSound;

    private int timer;

    public Player(TiledObject obj = null) : base("Spritesheet_grasshopper_final.png", 5, 3, -1, false, true)
    {
        jumpSound = new Sound("Sounds/jumpSound.mp3");
        pickSound = new Sound("Sounds/pickSound.mp3");

        boundary = game.height / 2;

        SetOrigin(width / 2, height / 2);
        this.SetScaleXY(.5f, .5f);

        score = 0;
        playerDead = false;
        isJumping = false;

        sensor = new Sprite("circle.png");
        AddChild(sensor);
        sensor.SetXY((width / 2) - 60, height + 50);
        sensor.alpha = 0;

        sensorHead = new Sprite("circle.png");
        AddChild(sensorHead);
        sensorHead.SetXY((width / 2) - 60, -200);
        sensorHead.alpha = 0;
        sensorHead.collider.isTrigger = true;

        Settings.score = 0;
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
            SetCycle(8, 4);
            Animate(0.02f);
        }
        else
        {
            //Walking animation
            SetCycle(1, 8);
            Animate(0.02f);
        }
        //Jumping animation
        if (isJumping)
        {
            SetCycle(12, 3);
            Animate(0.02f);
        }
    }

    void Movement()
    {
        int xSpeed = 0;

        if (Input.GetKey(Key.D))
        {
            xSpeed = speed;
            isMoving = true;
            if (!isFacingRight)
            {
                Flip();
            }
        }
        else if (Input.GetKey(Key.A))
        {
            xSpeed = -speed;
            isMoving = true;
            if (isFacingRight)
            {
                Flip();
            }
        }
        else { isMoving = false; }

        //Translate(xSpeed, 0);
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
                jumpSound.Play(false, 0, 10, 0);
            }
            else if (doubleJump)
            {
                ySpeed = jumpSpeed;
                doubleJump = false;
                jumpSound.Play(false, 0, 10, 0);
            }

        }
        if (isJumping)
        {
            Settings.score++;
            isMoving = false;
        }
    }

    void PlayerDead()
    {
        var screenPos = TransformPoint(0, 0);
        if (screenPos.y > game.height)
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
            pickSound.Play(false, 0, 10, 0);
        }

        if (other is Leaf)
        {
            Settings.score += 100;
            other.LateDestroy();
            pickSound.Play(false, 0, 10, 0);
        }
        if (other is Platform) { 
            other.collider.isTrigger = true;
        }
        if (other is SpikePlatform)
        {
            playerDead = true;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        scaleX *= -1;
    }

    void CheckPlatform()
    {
        foreach (GameObject other in sensor.GetCollisions())
        {
            if (other is Platform)
            {
                other.collider.isTrigger = false;
            }
            else { other.collider.isTrigger = true; }


            if (other is FragilePlatform)
            {
                
                FragilePlatform fragilePlatform = other as FragilePlatform;
                fragilePlatform.detect = true;
                if (fragilePlatform.detect == true) {
                    timer -= Time.deltaTime;
                    //Console.WriteLine(timer);
                }
                if (isJumping) {
                    timer = 1500;
                }
                if (timer <= 0) { other.LateDestroy(); }
            }            
        }

        foreach (GameObject other in sensorHead.GetCollisions())
        {

            if (other is Platform)
            {
                other.collider.isTrigger = true;
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