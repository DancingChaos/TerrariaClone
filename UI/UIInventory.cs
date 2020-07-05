using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Items;

namespace Terraria.UI
{
    class UIInventory : UIWindow
    {
        public List<UIInventoryCell> cells = new List<UIInventoryCell>();

        public UIInventory()
        {
            isVisibleTitleBar = false;
            BodyColor = Color.Transparent;

            int cellCount = 10;

            for (int i = 0; i < cellCount; i++)
                addCell();

            cells[0].IsSelected = true;

            Size = new Vector2i((int)Content.texUIInventoryBack.Size.X * cellCount, (int)Content.texUIInventoryBack.Size.Y);
        }

        public void addCell()
        {
            var cell = new UIInventoryCell(this);
            cell.Position = new Vector2i(cells.Count * cell.Wight, 0);
            cells.Add(cell);
            Childs.Add(cell);
        }

        // Возвращает ячейку со свободным местом по информации о предмете
        UIInventoryCell GetNotFullCellByInfoItem(InfoItem infoItem)
        {
            foreach (var c in cells)
                if (c.ItemStack != null && c.ItemStack.InfoItem == infoItem && !c.ItemStack.IsFull)
                    return c;

            return null;
        }

        public bool AddItemStack(UIItemStack itemStack)
        {
            var cell = GetNotFullCellByInfoItem(itemStack.InfoItem);

            if (cell != null)
            {
                cell.ItemStack = itemStack;
                return true;
            }
            else
            {
                foreach (var c in cells)
                {
                    if (c.ItemStack == null)
                    {
                        c.ItemStack = itemStack;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
