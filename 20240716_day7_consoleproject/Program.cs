namespace _20240716_day7_consoleproject
{
    internal class Program
    {
        #region RPG
        enum Scene { Initial, Home, Field, Town, Forest, Cave, Inn, Market }
        enum Class { None, Knight, Mage }
        enum Weapon { None, Sword, Wand }
        enum Armor { None, Shield, Robe }
        enum Mob { Slime, Imp, Goblin, Dragon}
        enum HeroTitle { None, DragonSlayer }
        struct RPGInfo
        {
            public bool RPGplaying;
            public Scene scene;
            public string name;
            public HeroTitle heroTitle;
            public Class Class;
            public Weapon Weapon;
            public Armor Armor;
            public int attack;
            public int defense;
            public int currentHP;
            public int maxHP;
            public int gold;
        }
        struct MobInfo
        {
            public int mobHP;
            public int mobAttack;
            public int dropGold;
            public Mob mob;
        }

        static void InitialScene()
        {
            rpgInfo.scene = Scene.Home;
            rpgInfo.heroTitle = HeroTitle.None;
            rpgInfo.Class = Class.None;
            rpgInfo.Weapon = Weapon.None;
            rpgInfo.Armor = Armor.None;
            rpgInfo.attack = 10;
            rpgInfo.defense = 0;
            rpgInfo.currentHP = 200;
            rpgInfo.maxHP = 200;
            rpgInfo.gold = 100;

            slime.mob = Mob.Slime;
            slime.mobHP = 10;
            slime.mobAttack = 3;
            slime.dropGold = 20;

            imp.mob = Mob.Imp;
            imp.mobHP = 30;
            imp.mobAttack = 7;
            imp.dropGold = 30;

            goblin.mob = Mob.Goblin;
            goblin.mobHP = 80;
            goblin.mobAttack = 15;
            goblin.dropGold = 100;

            dragon.mob = Mob.Dragon;
            dragon.mobHP = 400;
            dragon.mobAttack = 50;
            dragon.dropGold = 1000;

            while (true)
            {
                Console.Write("Enter Charater Name : ");
                rpgInfo.name = Console.ReadLine();
                if (rpgInfo.name == "")
                {
                    Console.WriteLine("Wrong Input");
                    continue;
                }
                break;
            }
            Console.Clear();
        }
        static void Stat()
        {
            Console.SetCursorPosition(20, 2);
            Console.WriteLine("◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇");
            Console.SetCursorPosition(20, 3);
            Console.WriteLine($"  Name : {rpgInfo.name}");
            Console.SetCursorPosition(20, 4);
            Console.WriteLine($" Class : {rpgInfo.Class} || Title : {rpgInfo.heroTitle}");
            Console.SetCursorPosition(20, 5);
            Console.WriteLine($"    HP : {rpgInfo.currentHP} / {rpgInfo.maxHP}");
            Console.SetCursorPosition(20, 6);
            Console.WriteLine($"Weapon : {rpgInfo.Weapon} AP : {rpgInfo.attack} || Armor : {rpgInfo.Armor} DP : {rpgInfo.defense}");
            Console.SetCursorPosition(20, 7);
            Console.WriteLine($"  Gold : {rpgInfo.gold}");
            Console.SetCursorPosition(20, 8);
            Console.WriteLine("◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇");
            Console.WriteLine();
            Console.WriteLine();

        }
        static void HomeScene()
        {
            Console.SetCursorPosition(0, 11);
            Console.Write("\t\t▷▷ HOME ◁      ");
        }
        static void FieldScene()
        {
            Console.SetCursorPosition(0, 11);
            Console.Write("\t\t▷▷ FEILD ◁◁      ");
        }
        static void ForestScene()
        {
            Console.SetCursorPosition(0, 11);
            Console.Write("\t\t▷▷ FOREST ◁◁          ");
        }
        static void CaveScene()
        {
            Console.SetCursorPosition(0, 11);
            Console.Write("\t\t▷▷ CAVE ◁◁             ");
        }
        static void TownScene()
        {
            Console.SetCursorPosition(0, 11);
            Console.Write("\t\t▷▷ TOWN ◁◁           ");
        }
        static void InnScene()
        {
            Console.SetCursorPosition(0, 11);
            Console.Write("\t\t▷▷ INN ◁◁           ");
        }
        static void MarketScene()
        {
            Console.SetCursorPosition(0, 11);
            Console.Write("\t\t▷▷ MARKET ◁◁          ");
        }
        static void Title()
        {
            rpgInfo = new RPGInfo();
            slime = new MobInfo();
            imp = new MobInfo();
            goblin = new MobInfo();
            dragon = new MobInfo();

            rpgInfo.RPGplaying = true;

            Console.WriteLine();
            Console.WriteLine("◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇");
            Console.WriteLine("◇\t\t\t\t\t◇");
            Console.WriteLine("◇\t\t-THE GAME-\t\t◇");
            Console.WriteLine("◇\t\t\t\t\t◇");
            Console.WriteLine("◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇◇");
            Console.WriteLine();

            Console.WriteLine("\t      PRESS ANY KEY");
            Console.ReadKey();
        }
        static bool Combat(int index)
        {
            bool win = true;
            int enemyHP;
            if (index == 0)
                enemyHP = slime.mobHP;
            else if (index == 1)
                enemyHP = imp.mobHP;
            else if (index == 2)
                enemyHP = goblin.mobHP;
            else if (index == 3)
                enemyHP = dragon.mobHP;

            return win;
            
        }

        static RPGInfo rpgInfo;
        static MobInfo slime;
        static MobInfo imp;
        static MobInfo goblin;
        static MobInfo dragon;
        #endregion

        #region MAP
        enum MapNum { Field = 1, Town, Forest, Cave, Inn, Market }
        public struct MapData
        {
            public bool mapPlaying;
            public bool[,] map;
            public ConsoleKey inputKey;
            public Coord playerPosition;
            public Coord warpPoint1;
            public Coord warpPoint2;
            public Coord warpPoint3;
        }
        public struct Coord
        {
            public int x;
            public int y;
        }
        static MapData mapData;
        static void GenerateMap()
        {
            mapData = new MapData();
            mapData.mapPlaying = true;
            mapData.map = new bool[,]
            {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false, false, false, false, false, false,  true,  true,  true,  true,  true,  true, false, false },
                { false, false, false, false, false, false,  true,  true,  true,  true,  true,  true, false, false },
                { false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false, false },
                { false, false, false, false, false, false,  true,  true,  true,  true,  true,  true, false, false },
                { false, false, false, false, false, false,  true,  true,  true,  true,  true,  true, false, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            };
            mapData.playerPosition = new Coord() { x = 2 * 2, y = 3 };
            mapData.warpPoint1 = new Coord() { x = 4 * 2, y = 1 };
            mapData.warpPoint2 = new Coord() { x = 4 * 2, y = 5 };
            mapData.warpPoint3 = new Coord() { x = 1 * 2, y = 3 };

        }
        static void PrintMap()
        {
            for (int x = 0; x < mapData.map.GetLength(0); x++)
            {
                for (int y = 0; y < mapData.map.GetLength(1); y += 2)
                {
                    if (mapData.map[x, y])
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write("□");
                    }
                }
                Console.WriteLine();
            }
        }
        static void PrintPlayer()
        {
            Console.SetCursorPosition(mapData.playerPosition.x, mapData.playerPosition.y);
            Console.Write("☆");
        }

        static void PrintWarpPoint1()
        {
            Console.SetCursorPosition(mapData.warpPoint1.x, mapData.warpPoint1.y);
            Console.Write("Ⅰ");
        }
        static void PrintWarpPoint2()
        {
            Console.SetCursorPosition(mapData.warpPoint2.x, mapData.warpPoint2.y);
            Console.Write("Ⅱ");
        }
        static void PrintWarpPoint3()
        {
            Console.SetCursorPosition(mapData.warpPoint3.x, mapData.warpPoint3.y);
            Console.Write("＠");
        }

        static void Render()
        {
            Console.SetCursorPosition(0, 0);

            PrintMap();
            PrintPlayer();
            PrintWarpPoint1();
            PrintWarpPoint2();
            PrintWarpPoint3();

            Console.WriteLine();
            Console.SetCursorPosition(20, 0);
            if (rpgInfo.scene == Scene.Home)
                Console.WriteLine("Ⅰ : FIELD  Ⅱ : TOWN  ＠ : RESTART     ");
            else if (rpgInfo.scene == Scene.Field)
                Console.WriteLine("Ⅰ : FOREST  Ⅱ : CAVE  ＠ : HOME       ");
            else if (rpgInfo.scene == Scene.Forest)
                Console.WriteLine("Ⅰ : SLIME  Ⅱ : IMP  ＠ : FIELD      ");
            else if (rpgInfo.scene == Scene.Cave)
                Console.WriteLine("Ⅰ : GOBLIN  Ⅱ : DRAGON  ＠ : FIELD     ");
            else if (rpgInfo.scene == Scene.Town)
                Console.WriteLine("Ⅰ : INN  Ⅱ : MARKET  ＠ : HOME      ");
            else if (rpgInfo.scene == Scene.Inn)
                Console.WriteLine("Ⅰ : HPregen  Ⅱ : DEVonly  ＠ : TOWN      ");
            else if (rpgInfo.scene == Scene.Market)
                Console.WriteLine("Ⅰ : WEAPON  Ⅱ : ARMOR  ＠ : TOWN        ");
            Stat();

        }
        static void Input()
        {
            mapData.inputKey = Console.ReadKey(true).Key;
        }
        static void MoveUp()
        {
            Coord nextCoord = new Coord() { x = mapData.playerPosition.x, y = mapData.playerPosition.y - 1 };
            if (mapData.map[nextCoord.y, nextCoord.x])
            {
                mapData.playerPosition = nextCoord;
            }
        }
        static void MoveDown()
        {
            Coord nextCoord = new Coord() { x = mapData.playerPosition.x, y = mapData.playerPosition.y + 1 };
            if (mapData.map[nextCoord.y, nextCoord.x])
            {
                mapData.playerPosition = nextCoord;
            }
        }
        static void MoveLeft()
        {
            Coord nextCoord = new Coord() { x = mapData.playerPosition.x - 2, y = mapData.playerPosition.y };
            if (mapData.map[nextCoord.y, nextCoord.x])
            {
                mapData.playerPosition = nextCoord;
            }
        }
        static void MoveRight()
        {
            Coord nextCoord = new Coord() { x = mapData.playerPosition.x + 2, y = mapData.playerPosition.y };
            if (mapData.map[nextCoord.y, nextCoord.x])
            {
                mapData.playerPosition = nextCoord;
            }
        }
        static void Move()
        {
            switch (mapData.inputKey)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;
            }
        }
        static void Contact()
        {
            if (mapData.playerPosition.x == mapData.warpPoint1.x && mapData.playerPosition.y == mapData.warpPoint1.y)
            {
                if (rpgInfo.scene == Scene.Home)
                {
                    rpgInfo.scene = Scene.Field;
                    FieldScene();
                }
                else if (rpgInfo.scene == Scene.Field)
                {
                    rpgInfo.scene = Scene.Forest;
                    ForestScene();
                }
                else if (rpgInfo.scene == Scene.Town)
                {
                    rpgInfo.scene = Scene.Inn;
                    InnScene();
                }


            }
            if (mapData.playerPosition.x == mapData.warpPoint2.x && mapData.playerPosition.y == mapData.warpPoint2.y)
            {
                if (rpgInfo.scene == Scene.Home)
                {
                    rpgInfo.scene = Scene.Town;
                    TownScene();
                }
                else if (rpgInfo.scene == Scene.Field)
                {
                    rpgInfo.scene = Scene.Cave;
                    CaveScene();
                }
                else if (rpgInfo.scene == Scene.Town)
                {
                    rpgInfo.scene = Scene.Market;
                    MarketScene();
                }

            }
            if (mapData.playerPosition.x == mapData.warpPoint3.x && mapData.playerPosition.y == mapData.warpPoint3.y)
            {
                if (rpgInfo.scene == Scene.Home)
                    InitialScene();
                else if (rpgInfo.scene == Scene.Field)
                {
                    rpgInfo.scene = Scene.Home;
                    HomeScene();
                }
                else if (rpgInfo.scene == Scene.Forest)
                {
                    rpgInfo.scene = Scene.Field;
                    FieldScene();
                }
                else if (rpgInfo.scene == Scene.Cave)
                {
                    rpgInfo.scene = Scene.Field;
                    FieldScene();
                }
                else if (rpgInfo.scene == Scene.Town)
                {
                    rpgInfo.scene = Scene.Home;
                    HomeScene();
                }
                else if (rpgInfo.scene == Scene.Inn)
                {
                    rpgInfo.scene = Scene.Town;
                    TownScene();
                }
                else if (rpgInfo.scene == Scene.Market)
                {
                    rpgInfo.scene = Scene.Town;
                    TownScene();
                }
            }
        }
        static void MapStatUpdate()
        {
            Render();
            Input();
            Move();
            Contact();
        }
        #endregion

        /************************************************************************/

        static void Main(string[] args)
        {
            Title();
            InitialScene();
            GenerateMap();

            while (mapData.mapPlaying)
            {
                MapStatUpdate();
            }

        }
    }
}

