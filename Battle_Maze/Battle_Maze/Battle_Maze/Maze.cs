using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Battle_Maze
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Maze : Microsoft.Xna.Framework.GameComponent
    {
        private Tile[,] tiles;
        private GraphicsDevice graphicsDevice;
        public int size;

        public Maze(Game game, int size)
            : base(game)
        {
            graphicsDevice = game.GraphicsDevice;
            this.size = size;
            tiles = new Tile[size, size];
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        public void LoadContent()
        {
            Texture2D whiteRectangle = new Texture2D(graphicsDevice, 1, 1);
            whiteRectangle.SetData(new Color[] { Color.White });
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (y % 2 == 0)
                    {
                        if (x % 2 == 0)
                            tiles[x, y] = new Tile(whiteRectangle, TileCollision.HardWall);
                        else
                            tiles[x, y] = new Tile(whiteRectangle, TileCollision.SoftWall);
                    }
                    else
                    {
                        if (x % 2 == 0)
                            tiles[x, y] = new Tile(whiteRectangle, TileCollision.SoftWall);
                        else
                            tiles[x, y] = new Tile(whiteRectangle, TileCollision.Path);
                    }
                }
            }
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            for (int x = 0; x < size ; x++){
                for (int y = 0; y < size ; y++)
                {
                    Vector2 position = new Vector2(x, y) * Tile.size;
                    TileCollision tileType = tiles[x,y].collision;
                    if (tileType == TileCollision.Path)
                        spriteBatch.Draw(tiles[x, y].texture, new Rectangle((int)position.X, (int)position.Y, (int)position.X + Tile.width, (int)position.Y + Tile.height), Color.White);
                    else if (tileType == TileCollision.SoftWall)
                        spriteBatch.Draw(tiles[x, y].texture, new Rectangle((int)position.X, (int)position.Y, (int)position.X + Tile.width, (int)position.Y + Tile.height), Color.LightSteelBlue);
                    else
                        spriteBatch.Draw(tiles[x, y].texture, new Rectangle((int)position.X, (int)position.Y, (int)position.X + Tile.width, (int)position.Y + Tile.height), Color.SteelBlue);
                }
            }
        }
    }
}
