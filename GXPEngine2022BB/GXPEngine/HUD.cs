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
    Player player;

    public HUD(Player player)
    {
        this.player = player;

        score = new EasyDraw(250, 60);
        score.Fill(Color.Blue);
        //score.TextFont(font);
        score.Text("aaaaaaaa");
        score.SetXY(30, 0);
        AddChild(score);
    }

    public void ChechScore()
    {
        score.Clear(Color.Transparent);
        score.Text(String.Format("Score:" + (int)player.y));
    }
}
