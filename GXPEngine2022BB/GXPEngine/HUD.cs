using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using System.Drawing;
public class HUD : GameObject
{

    EasyDraw score;
    EasyDraw doubleJump;

    Player player;

    public HUD(Player player)
    {
        this.player = player;

        score = new EasyDraw(250, 60, false);
        score.Fill(Color.Blue);
        //score.TextFont(font);
        score.SetXY(30, 0);
        AddChild(score);

        doubleJump = new EasyDraw(250, 60, false);
        doubleJump.Fill(Color.Blue);
        //score.TextFont(font);
        doubleJump.SetXY(1100, 0);
        AddChild(doubleJump);
    }

    public void ChechScore()
    {
        score.Clear(Color.Transparent);
        if (player != null)
        {
            score.Text(String.Format("Score: " + (int)player.score));

            doubleJump.Clear(Color.Transparent);
            doubleJump.Text(String.Format("Double Jump: " + player.doubleJump));
        }
    }
}
