﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace Terraria.UI
{
    abstract class UIBase : Transformable, Drawable
    {
        public UIBase OldParent = null;           //предыдущий родитель до перетаскивания
        public UIBase Parent = null;              //parents
        public List<UIBase> Childs = new List<UIBase>(); //ne bei detei

        public new Vector2i Position
        {
            get { return (Vector2i)base.Position; }
            set { base.Position = (Vector2f)value; }
        }
        public new Vector2i Origin
        {
            get { return (Vector2i)base.Origin; }
            set { base.Position = (Vector2f)value; }
        }

        public Vector2i GlobalPosition
        {
            get
            {
                if (Parent == null)
                    return Position;
                else
                    return Parent.GlobalPosition;
            }
        }

        public Vector2i GlobalOrigin
        {
            get
            {
                if (Parent == null)
                    return Origin;
                else
                    return Parent.GlobalOrigin;
            }
        }

        public int Wight
        {
            get { return (int)rectShape.Size.X; }
            set { rectShape.Size = new Vector2f(value, rectShape.Size.Y); }
        }
        public int Height
        {
            get { return (int)rectShape.Size.Y; }
            set { rectShape.Size = new Vector2f(rectShape.Size.X, value); }
        }
        public Vector2i Size
        {
            get { return (Vector2i)rectShape.Size; }
            set { rectShape.Size = (Vector2f)(value); }
        }

        public bool IsAllowDrag = false; //можно тащить обьект мышкой
        public Vector2i DragOffset { get; private set; }

        protected RectangleShape rectShape;

        public virtual void UpdateOver(Vector2i mousePos)
        {
            var localMousePos = mousePos - GlobalPosition + GlobalOrigin;

            if (rectShape.GetLocalBounds().Contains(localMousePos.X, localMousePos.Y)) 
            {
                if (UIManager.Drag == null)
                {
                    if (IsAllowDrag && Mouse.IsButtonPressed(Mouse.Button.Left))
                    {
                        UIManager.Drag = this;
                        DragOffset = mousePos - GlobalPosition;
                        OnDragBegin();
                    }
                }

                if (UIManager.Drag != this)
                    UIManager.Over = this;

                for (int i = 0; i < Childs.Count; i++)
                    Childs[i].UpdateOver(mousePos);
            }
        }

        public virtual void Update()
        {
            foreach (var c in Childs)
                c.Update();
        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(rectShape, states);

            foreach (var c in Childs)
                if (c != UIManager.Drag)
                    target.Draw(c, states);
        }

        //когда текущий обьект драгают
        public virtual void OnDragBegin()
        {
            OldParent = Parent;

            if (Parent != null)
                Parent.Childs.Remove(this);

            Parent = null;
        }
        //когда текущий обьект дропают
        public virtual void OnDrop(UIBase ui)
        {

        }

        //когда текущий обьект невозможно дропнуть
        public virtual void OnCancelDrag()
        {
            if (OldParent != null)
                OldParent.Childs.Add(this);

            Parent = OldParent;
            Position = new Vector2i();
        }
    }
}
