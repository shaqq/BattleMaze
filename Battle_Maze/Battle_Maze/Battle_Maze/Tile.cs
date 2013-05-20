using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

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
        public TileCollision collision;
        public Texture2D texture;

        public const int height = 30;
        public const int width = 30;
        public static readonly Vector2 size = new Vector2(width, height);

        public Tile(Texture2D Texture, TileCollision Collision)
        {
            texture = Texture;
            collision = Collision;
        }
    }   
}
