namespace Terraria.Items
{
    class InfoItem
    {
        public static InfoItem ItemGround = new InfoItem().SetSprite(Content.ssGround, 9, 3);

        //-------------------------------------------------------
        public SpriteSheet SpriteSheet { get; private set; }
        public int SpriteI { get; private set; }
        public int SpriteJ { get; private set; }
        //max items in stack
        public int MaxCountInStack { get; private set; } = 64;

       public InfoItem SetSprite(SpriteSheet ss, int i, int j)
        {
            SpriteSheet = ss;
            SpriteI = i;
            SpriteJ = j;
            return this;
        }

        public InfoItem SetMaxCountInStack (int value)
        {
            MaxCountInStack = value;
            return this;
        }
    }
}
