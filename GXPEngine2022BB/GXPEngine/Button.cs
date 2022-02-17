using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class Button : Sprite
{

    public Button(TiledObject obj = null) : base("startButton.png")
    {
    }

    void Update()
    {
        //Check if the cursor is over the start button and if it is pressed
        if (this.HitTestPoint(Input.mouseX, Input.mouseY))
        {
            this.SetColor(1, 1, 1);
            if (Input.GetMouseButtonDown(0))
            {
                ((MyGame)game).levelName = "map.tmx";
                ((MyGame)game).DestroyLevel();
                ((MyGame)game).LoadLevel(((MyGame)game).levelName);
            }
        }
        else
        {
            this.SetColor(0, 0, 0);
        }
    }
}

public class BackButton : Sprite {

    public BackButton() : base("backButton.png") {
    }

    void Update()
    {
        //Check if the cursor is over the start button and if it is pressed
        if (this.HitTestPoint(Input.mouseX, Input.mouseY))
        {
            this.SetColor(1, 1, 1);
            if (Input.GetMouseButtonDown(0))
            {
                ((MyGame)game).levelName = "mainmenu.tmx";
                ((MyGame)game).DestroyLevel();
                ((MyGame)game).LoadLevel(((MyGame)game).levelName);
            }
        }
        else
        {
            this.SetColor(0, 0, 0);
        }
    }
}