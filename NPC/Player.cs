
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.NPC;
using Terraria.UI;

namespace Terraria
{
    class Player : Npc
    {
        public const float PLAYER_SPEED = 3f;
        public const float PLAYER_JUMP_POWER = 8f;
        public const float PLAYER_SPEED_ACCELERATION = 0.2f;


        //color base
        public Color HairColor = new Color(240, 20, 20);   //HairColor
        public Color BodyColor = new Color(255, 229, 186); //BodyColor
        public Color ShirtColor = new Color(240, 240, 20); //ShirtColor
        public Color LegsColor = new Color(10, 76, 135);   //LegsColor
        public Color ShoesColor = new Color(30, 30, 30);   //ShoesColor

        //UI
        public UIInventory Inventory;

        //anim sprites player
        AnimSprite asHair;
        AnimSprite asHead;
        AnimSprite asShirt;
        AnimSprite asUnderhsirt;
        AnimSprite asHands;
        AnimSprite asLegs;
        AnimSprite asShoes;

        //constructor
        public Player(World world) : base(world)
        {

            rect = new RectangleShape(new SFML.System.Vector2f(Tile.TILE_SIZE * 1.5f, Tile.TILE_SIZE * 2.8f));
            rect.Origin = new SFML.System.Vector2f(rect.Size.X / 2, 0);
            isRectVisible = false;

            ////ANIMATIONS
            ///asHair//////                                                  14
            asHair = new AnimSprite(Content.ssPlayerHair);
            asHair.Position = new Vector2f(0, 19);
            asHair.Color = HairColor;
            asHair.AddAnimation("idle", new Animation(
                new AnimationFrame(0, 0, 0.1f)
                ));
            asHair.AddAnimation("run", new Animation(
               new AnimationFrame(0, 0, 0.1f),
               new AnimationFrame(0, 1, 0.1f),
               new AnimationFrame(0, 2, 0.1f),
               new AnimationFrame(0, 3, 0.1f),
               new AnimationFrame(0, 4, 0.1f),
               new AnimationFrame(0, 5, 0.1f),
               new AnimationFrame(0, 6, 0.1f),
               new AnimationFrame(0, 7, 0.1f),
               new AnimationFrame(0, 8, 0.1f),
               new AnimationFrame(0, 9, 0.1f),
               new AnimationFrame(0, 10, 0.1f),
               new AnimationFrame(0, 11, 0.1f),
               new AnimationFrame(0, 12, 0.1f),
               new AnimationFrame(0, 13, 0.1f)
               ));

            ///asHead 
            asHead = new AnimSprite(Content.ssPlayerHead);
            asHead.Position = new Vector2f(0, 19);
            asHead.Color = BodyColor;
            asHead.AddAnimation("idle", new Animation(
                new AnimationFrame(0, 0, 0.1f)
                ));
            asHead.AddAnimation("run", new Animation(
               new AnimationFrame(0, 6, 0.1f),
               new AnimationFrame(0, 7, 0.1f),
               new AnimationFrame(0, 8, 0.1f),
               new AnimationFrame(0, 9, 0.1f),
               new AnimationFrame(0, 10, 0.1f),
               new AnimationFrame(0, 11, 0.1f),
               new AnimationFrame(0, 12, 0.1f),
               new AnimationFrame(0, 13, 0.1f),
               new AnimationFrame(0, 14, 0.1f),
               new AnimationFrame(0, 15, 0.1f),
               new AnimationFrame(0, 16, 0.1f),
               new AnimationFrame(0, 17, 0.1f),
               new AnimationFrame(0, 18, 0.1f),
               new AnimationFrame(0, 19, 0.1f)
               ));

            ///asShirt
            asShirt = new AnimSprite(Content.ssPlayerShirt);
            asShirt.Position = new Vector2f(0, 19);
            asShirt.Color = ShirtColor;
            asShirt.AddAnimation("idle", new Animation(
                new AnimationFrame(0, 0, 0.1f)
                ));
            asShirt.AddAnimation("run", new Animation(
                  new AnimationFrame(0, 6, 0.1f),
               new AnimationFrame(0, 7, 0.1f),
               new AnimationFrame(0, 8, 0.1f),
               new AnimationFrame(0, 9, 0.1f),
               new AnimationFrame(0, 10, 0.1f),
               new AnimationFrame(0, 11, 0.1f),
               new AnimationFrame(0, 12, 0.1f),
               new AnimationFrame(0, 13, 0.1f),
               new AnimationFrame(0, 14, 0.1f),
               new AnimationFrame(0, 15, 0.1f),
               new AnimationFrame(0, 16, 0.1f),
               new AnimationFrame(0, 17, 0.1f),
               new AnimationFrame(0, 18, 0.1f),
               new AnimationFrame(0, 19, 0.1f)
               ));

            ///asUndersirt
            asUnderhsirt = new AnimSprite(Content.ssPlayerUndershirt);
            asUnderhsirt.Position = new Vector2f(0, 19);
            asUnderhsirt.Color = ShirtColor;
            asUnderhsirt.AddAnimation("idle", new Animation(
                new AnimationFrame(0, 0, 0.1f)
                ));
            asUnderhsirt.AddAnimation("run", new Animation(
                 new AnimationFrame(0, 6, 0.1f),
               new AnimationFrame(0, 7, 0.1f),
               new AnimationFrame(0, 8, 0.1f),
               new AnimationFrame(0, 9, 0.1f),
               new AnimationFrame(0, 10, 0.1f),
               new AnimationFrame(0, 11, 0.1f),
               new AnimationFrame(0, 12, 0.1f),
               new AnimationFrame(0, 13, 0.1f),
               new AnimationFrame(0, 14, 0.1f),
               new AnimationFrame(0, 15, 0.1f),
               new AnimationFrame(0, 16, 0.1f),
               new AnimationFrame(0, 17, 0.1f),
               new AnimationFrame(0, 18, 0.1f),
               new AnimationFrame(0, 19, 0.1f)
               ));

            ///asHands
            asHands = new AnimSprite(Content.ssPlayerHands);
            asHands.Position = new Vector2f(0, 19);
            asHands.Color = BodyColor;
            asHands.AddAnimation("idle", new Animation(
                new AnimationFrame(0, 0, 0.1f)
                ));
            asHands.AddAnimation("run", new Animation(
                  new AnimationFrame(0, 6, 0.1f),
               new AnimationFrame(0, 7, 0.1f),
               new AnimationFrame(0, 8, 0.1f),
               new AnimationFrame(0, 9, 0.1f),
               new AnimationFrame(0, 10, 0.1f),
               new AnimationFrame(0, 11, 0.1f),
               new AnimationFrame(0, 12, 0.1f),
               new AnimationFrame(0, 13, 0.1f),
               new AnimationFrame(0, 14, 0.1f),
               new AnimationFrame(0, 15, 0.1f),
               new AnimationFrame(0, 16, 0.1f),
               new AnimationFrame(0, 17, 0.1f),
               new AnimationFrame(0, 18, 0.1f),
               new AnimationFrame(0, 19, 0.1f)
               ));

            ///asLegs
            asLegs = new AnimSprite(Content.ssPlayerLegs);
            asLegs.Position = new Vector2f(0, 19);
            asLegs.Color = LegsColor;
            asLegs.AddAnimation("idle", new Animation(
                new AnimationFrame(0, 0, 0.1f)
                ));
            asLegs.AddAnimation("run", new Animation(
                   new AnimationFrame(0, 6, 0.1f),
               new AnimationFrame(0, 7, 0.1f),
               new AnimationFrame(0, 8, 0.1f),
               new AnimationFrame(0, 9, 0.1f),
               new AnimationFrame(0, 10, 0.1f),
               new AnimationFrame(0, 11, 0.1f),
               new AnimationFrame(0, 12, 0.1f),
               new AnimationFrame(0, 13, 0.1f),
               new AnimationFrame(0, 14, 0.1f),
               new AnimationFrame(0, 15, 0.1f),
               new AnimationFrame(0, 16, 0.1f),
               new AnimationFrame(0, 17, 0.1f),
               new AnimationFrame(0, 18, 0.1f),
               new AnimationFrame(0, 19, 0.1f)
               ));

            ///asShoes
            asShoes = new AnimSprite(Content.ssPlayerShoes);
            asShoes.Position = new Vector2f(0, 19);
            asShoes.Color = ShoesColor;
            asShoes.AddAnimation("idle", new Animation(
                new AnimationFrame(0, 0, 0.1f)
                ));
            asShoes.AddAnimation("run", new Animation(
                 new AnimationFrame(0, 6, 0.1f),
               new AnimationFrame(0, 7, 0.1f),
               new AnimationFrame(0, 8, 0.1f),
               new AnimationFrame(0, 9, 0.1f),
               new AnimationFrame(0, 10, 0.1f),
               new AnimationFrame(0, 11, 0.1f),
               new AnimationFrame(0, 12, 0.1f),
               new AnimationFrame(0, 13, 0.1f),
               new AnimationFrame(0, 14, 0.1f),
               new AnimationFrame(0, 15, 0.1f),
               new AnimationFrame(0, 16, 0.1f),
               new AnimationFrame(0, 17, 0.1f),
               new AnimationFrame(0, 18, 0.1f),
               new AnimationFrame(0, 19, 0.1f)
               ));

        }

        public override void OnKill()
        {
            Spawn();
        }

        public override void OnWallCollided()
        {
        }

        public override void UpdateNpc()
        {
            UpdateMovement();

            if (UIManager.Over == null && UIManager.Drag == null)
            {
                var mousePos = Mouse.GetPosition(main.Window);
                var tile = world.GetTileByWorldPos(mousePos);
                if (tile != null)
                {
                    FloatRect tileRect = tile.GetFloatRect();

                    if (Mouse.IsButtonPressed(Mouse.Button.Left))
                    {
                        int i = (int)(mousePos.X / Tile.TILE_SIZE);
                        int j = (int)(mousePos.Y / Tile.TILE_SIZE);
                        world.SetTile(TileType.NONE, i, j);
                    }
                }
                if (Mouse.IsButtonPressed(Mouse.Button.Right))
                {
                    int i = (int)(mousePos.X / Tile.TILE_SIZE);
                    int j = (int)(mousePos.Y / Tile.TILE_SIZE);
                    world.SetTile(TileType.GROUND, i, j);
                }
            }
        }

        public override void DrawNPC(RenderTarget target, RenderStates states)
        {
            target.Draw(asHead, states);
            target.Draw(asHair, states);
            target.Draw(asShirt, states);
            target.Draw(asUnderhsirt, states);
            target.Draw(asHands, states);
            target.Draw(asLegs, states);
            target.Draw(asShoes, states);
        }

        private void UpdateMovement()
        {
            bool isLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
            bool isRight = Keyboard.IsKeyPressed(Keyboard.Key.D);
            bool isJump = Keyboard.IsKeyPressed(Keyboard.Key.Space);
            bool isMove = isLeft || isRight;

            if (isJump && !isFly)
            {
                velocity.Y -= PLAYER_JUMP_POWER;
            }
            if (isMove) // movement
            {
                if (isLeft)
                {
                    if (movement.X > 0)
                        movement.X = 0;

                    movement.X -= PLAYER_SPEED_ACCELERATION;
                    Direction = -1;
                }
                if (isRight)
                {
                    if (movement.X < 0)
                        movement.X = 0;

                    movement.X += PLAYER_SPEED_ACCELERATION;
                    Direction = 1;
                }

                if (movement.X > PLAYER_SPEED)
                    movement.X = PLAYER_SPEED;
                else if (movement.X < -PLAYER_SPEED)
                    movement.X = -PLAYER_SPEED;

                //run animation
                asHair.Play("run");
                asHead.Play("run");
                asShirt.Play("run");
                asUnderhsirt.Play("run");
                asHands.Play("run");
                asLegs.Play("run");
                asShoes.Play("run");
            }
            else //idle
            {
                movement = new Vector2f();

                //idle animation
                asHair.Play("idle");
                asHead.Play("idle");
                asShirt.Play("idle");
                asUnderhsirt.Play("idle");
                asHands.Play("idle");
                asLegs.Play("idle");
                asShoes.Play("idle");
            }
        }
    }
}
