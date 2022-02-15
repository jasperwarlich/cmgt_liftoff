using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;
public class DoubleJumpPowerUp : AnimationSprite
{


    public DoubleJumpPowerUp(TiledObject obj = null) : base ("leaf.png", 5, 1)
    {
        this.collider.isTrigger = true;
    }

    public void Update()
    {
        Animate(.05f);
    }

}
