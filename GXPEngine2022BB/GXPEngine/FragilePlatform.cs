using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class FragilePlatform : Platform
{
    public bool detect;

    public FragilePlatform(TiledObject obj = null) : base("leaf_platform_80.png")
    {
        detect = false;
    }
}
