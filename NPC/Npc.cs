using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Terraria.NPC
{
   
    abstract class Npc : Entity
    {
        public Vector2f StartPosition;
       
        public int Direction
        {
            set
            {
                int dir = value >= 0 ? 1 : -1;
                Scale = new Vector2f(dir, 1);
            }
            get
            {
                int dir = Scale.X >= 0 ? 1 : -1;
                return dir;
            }

        }

        //constuctor
        public Npc(World world) : base(world)
        {
        
        }

        // возрoждение существа
        public void Spawn()
        {
            Position = StartPosition;
            velocity = new Vector2f();
        }

        //Update
        public override void Update()
        {
            UpdateNpc();
            base.Update();



            //если обьект упал за мир
            if (Position.Y > main.Window.Size.Y)
                OnKill();
        }

        //draw
        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            if (isRectVisible)
                target.Draw(rect, states);

            DrawNPC(target, states);
        }

        
        public abstract void OnKill();
        public abstract void UpdateNpc();
        public abstract void DrawNPC(RenderTarget target, RenderStates states);
    }
}
