using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battle_Maze
{
    enum TileCollision
    {
        HardWall = 0,

        SoftWall = 1,

        Path = 2
    }


    class Tile
    {
        public TileCollision Collision;

        public const int height = 30;
        public const int width = 30;

        public Tile(TileCollision collision)
        {
            Collision = collision;
        }
    }   
}
