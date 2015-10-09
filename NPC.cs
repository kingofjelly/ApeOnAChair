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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace ApeOnAChair
{
    public class NPC
    {
        Vector2 npcPosition = new Vector2();
        Texture2D npcTexture;
        Rectangle npcRectangle = new Rectangle();

        public int MOVEMENT;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -2;
        const int MOVE_RIGHT = 2;
        const int SPEED = 160;

        //start position = 0,0. Top left
        //end position = 700,0. Top right

        //walk down to = 
        //load
        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {

        }

        //update
        public void Update(GameTime theGameTime)
        {

        }

        //draw
        public void Draw(SpriteBatch theSpriteBatch)
        {

        }
    }
}
