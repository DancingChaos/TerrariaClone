using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria
{
    //frame
    class AnimationFrame
    {
        public int i, j;
        public float time;


        public AnimationFrame(int i, int j, float time)
        {
            this.i = i;
            this.j = j;
            this.time = time;
        }
    }

    //animation
    class Animation
    {
        AnimationFrame[] frames;

        float timer;
        AnimationFrame currFrame;
        int currFrameIndex;

        //constructor
        public Animation(params AnimationFrame[] frames)
        {
            this.frames = frames;
            Reset();
        }

        //play animation again
        public void Reset()
        {
            timer = 0f;
            currFrameIndex = 0;
            currFrame = frames[currFrameIndex];
        }

        //next frame
        public void NextFrame()
        {
            timer = 0f;
            currFrameIndex++;

            if (currFrameIndex == frames.Length)
                currFrameIndex = 0;

            currFrame = frames[currFrameIndex];
        }

        //ger current frame
        public AnimationFrame GetFrame(float speed)
        {
            timer += speed;

            if (timer >= currFrame.time)
                NextFrame();

            return currFrame;
        }

    }




    //sprite with animation
    class AnimSprite : Transformable , Drawable
    {
        public float speed = 0.05f;

        RectangleShape rectShape;
        SpriteSheet ss;   //sprite set
        SortedDictionary<string, Animation> animations = new SortedDictionary<string, Animation>();
        Animation currAnim; // current animation
        string currAnimName;  //name current animation

        //color animSprite change
        public Color Color
        {
            set { rectShape.FillColor = value; }
            get { return rectShape.FillColor; }
        }

        //constructor
        public AnimSprite( SpriteSheet ss)
        {
            this.ss = ss;
            rectShape = new RectangleShape(new Vector2f(ss.SubWight, ss.SubHeight));
            rectShape.Origin = new Vector2f(ss.SubWight / 2, ss.SubHeight / 2);
            rectShape.Texture = ss.Texture;
        }

        //add animation
        public void AddAnimation(string name, Animation animation)
        {
            animations[name] = animation;
            currAnim = animation;
            currAnimName = name;
        }

        //play
        public void Play(string name)
        {
            if (currAnimName == name)
                return;

            currAnim = animations[name];
            currAnimName = name;
            currAnim.Reset();
        }

        //get texture rect
        public IntRect GetTextureRect()
        {
            var currFrame = currAnim.GetFrame(speed);
            return ss.GetTextureRect(currFrame.i, currFrame.j);
        }

        //realise interface
        public void Draw(RenderTarget target, RenderStates states)
        {
            rectShape.TextureRect = GetTextureRect();

            states.Transform *=Transform;
            target.Draw(rectShape, states);
        }
    }
}
