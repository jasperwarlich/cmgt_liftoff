using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using System.Drawing;
public class HUD : GameObject
{

    private EasyDraw score;
    private EasyDraw doubleJump;

    private Player player;

    private Font font = Utils.LoadFont("ArcadeNormal-ZDZ.ttf", 15);

    private int lastPoints;

    public HUD(Player player)
    {
        this.player = player;

        score = new EasyDraw(250, 60, false);
        score.Fill(Color.Blue);
        score.TextFont(font);
        score.SetXY(30, 0);
        AddChild(score);

        doubleJump = new EasyDraw(250, 60, false);
        doubleJump.Fill(Color.Blue);
        doubleJump.TextFont(font);
        doubleJump.SetXY(1100, 0);
        AddChild(doubleJump);
    }

    public void ChechScore()
    {
        score.Clear(Color.Transparent);
        if (player != null)
        {
            score.Text(String.Format("Score: " + (int)Settings.score));

            doubleJump.Clear(Color.Transparent);
            doubleJump.Text(String.Format("Double Jump: \n " + (player.doubleJump ? "Active!" : "Not Active!")));
            lastPoints = Settings.score;
        }

        if (((MyGame)game).levelName == "endmenu.tmx")
        {
            score.SetXY((game.width / 2) - 100, (game.height / 2) - 40);
            score.Text(String.Format("Score: " + Settings.score));
        }
    }
}
