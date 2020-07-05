using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria.UI
{
    class UIInventoryCell : UIBase
    {
        public UIInventory Inventory { get; private set; }

        bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                rectShape.FillColor = isSelected ? new Color(240, 240, 0, 255) : new Color(100, 100, 240, 127);
            }
        }
        
        UIItemStack itemStack;
        public UIItemStack ItemStack
        {
            get { return itemStack; }
            set
            {
                //складывание предметов в ячейках
                if (itemStack != null && value != null && itemStack.InfoItem == value.InfoItem)
                {
                    itemStack.ItemCount += value.ItemCount;
                    return;
                }
                //если текущего стека нет то новое значение
                itemStack = value;

                if (itemStack != null) //если не пуст
                {
                    itemStack.Parent = this; //добавляем родителя
                    itemStack.Position = new Vector2i(); //обновляем позицию
                    Childs.Add(itemStack); //добавляем в детей ячейки
                }
            }

            }


        public UIInventoryCell(UIInventory inventory)
        {
            Inventory = inventory;

            rectShape = new RectangleShape((Vector2f)Content.texUIInventoryBack.Size);
            rectShape.Texture = Content.texUIInventoryBack;

            IsSelected = false;
        }

        public override void OnDrop(UIBase ui)
        {
            if (ui is UIItemStack)
                ItemStack = ui as UIItemStack;
        }
    }
}
