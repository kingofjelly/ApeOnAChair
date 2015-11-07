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

        public enum NPCState
        {
            Walking,
            Inspecting
        }

        public int MOVEMENT_DIR;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;
        const int NPC_SPEED = 160;
        const int NPC_HALT = 0;

        public Vector2 mDirection = Vector2.Zero;
        public Vector2 mSpeed = Vector2.Zero;

        public NPCState npcState = new NPCState();

        //start position = 0,0. Top left
        //end position = 700,0. Top right

        //walk down to = 0,400
        //walk right to = 300, 400 > 550, 400
        //stop
        //walk to = 700, 400
        //walk up to = 700,0
        //top area can be randomised ways they reach your cubicle
        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            npcTexture = theContentManager.Load<Texture2D>(theAssetName);
        }

        //update
        public void Update(GameTime theGameTime)
        {
            UpdateNpcPathing();
            //here we need to also do a check, so when in inspecting state, if user spins OR spin timer runs out, game over
            //player character and spin timer to be accessible from main game
            npcPosition += mDirection * mSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            npcRectangle = new Rectangle((int)npcPosition.X, (int)npcPosition.Y, 91, 91);
            
        }

        //draw
        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(npcTexture, npcPosition, Color.White);
        }
        //update movement based upon location

        public void UpdateNpcPathing()
        {
            //throw coin to decide what side it takes? learn pathing through pacman?
            //this walks the sprite downt the left wall, across the map and up the right wall towards
            //the top right corner
            mSpeed = Vector2.Zero;
            mDirection = Vector2.Zero;
           //keep update clear. do working here
            if (npcRectangle.X == 0 && npcRectangle.Y != 400)//means left side
            {
                //then move down
                mSpeed.Y = NPC_SPEED;
                mDirection.Y = MOVE_DOWN;
                npcState = NPCState.Walking;


            }
           
            if (npcRectangle.Y == 400)
            {
                if (npcRectangle.X >= 0 && npcRectangle.X != 709)
                {
                //you've gone down far enough. send it across the screen.
                //walk to 700, 400
                mSpeed.X = NPC_SPEED;
                mDirection.X = MOVE_RIGHT;
                npcState = NPCState.Inspecting;
                }
            }
           
            if (npcRectangle.X == 709)
            {
                //go up. you're 709 across. move to final postion.
                //Veritical = Y axes. Horizontal = X axis.
                if (npcRectangle.Y >= 0 && npcRectangle.Y <= 700)
                {
                    mSpeed.Y = NPC_SPEED;
                    mDirection.Y = MOVE_UP;
                    npcState = NPCState.Walking;
                }
                
            }
            
        }
    }
}
