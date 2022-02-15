using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class Leaf : AnimationSprite
{

    public Leaf(TiledObject obj = null) : base("leaf.png", 5, 1)
    {
        this.collider.isTrigger = true;
        SetScaleXY(.5f,.5f);
    }

    void Update() {
        Animate(.05f);
    }
}
