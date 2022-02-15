using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class Wings : AnimationSprite
{

    public Wings(TiledObject obj = null) : base("wings.png", 2, 1)
    {
        this.collider.isTrigger = true;
    }

    void Update() {
        Animate(.05f);
    }
}
