using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using System.Drawing;
public class HUD : GameObject {

    EasyDraw score;

    public HUD() {   
        score = new EasyDraw(250, 60);
        score.Fill(Color.Blue);
        //score.TextFont(font);
        score.Text("aaaaaaaa");
        score.SetXY(50, 40);
        AddChild(score);
    }


}
