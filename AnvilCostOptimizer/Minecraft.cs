using System;
using System.Collections.Generic;

namespace Minecraft
{
    public readonly struct ItemInfo
    {
        public readonly int Id;
        public readonly string Name;
        public readonly UInt64 ApplicableEnchantments;

        public ItemInfo(int id, string name, UInt64 enchantments)
        {
            Id = id;
            Name = name;
            ApplicableEnchantments = enchantments;
        }
    }

    public readonly struct EnchantmentInfo
    {
        public readonly int Id;
        public readonly string Name;
        public readonly int Maxlevel;
        public readonly int ItemMultiplier;
        public readonly int BookMultiplier;
        public readonly int ApplicableItems;
        public readonly UInt64 IncompatibleEnchantments;
        
        public EnchantmentInfo(int id, string name, int maxlevel, int itemMultiplier, 
                               int bookMultiplier, int applicable, UInt64 incompatible)
        {
            Id = id;
            Name = name;
            Maxlevel = maxlevel;
            ItemMultiplier = itemMultiplier;
            BookMultiplier = bookMultiplier;
            ApplicableItems = applicable;
            IncompatibleEnchantments = incompatible;
        }
    }

    class MC
    {
        //Items
        public static readonly int TURTLE_SHELL             =  0;
        public static readonly int HELMET                   =  1;
        public static readonly int CHESTPLATE               =  2;
        public static readonly int LEGGINGS                 =  3;
        public static readonly int BOOTS                    =  4;
        public static readonly int SHIELD                   =  5;
        public static readonly int SWORD                    =  6;
        public static readonly int AXE                      =  7;
        public static readonly int PICKAXE                  =  8;
        public static readonly int SHOVEL                   =  9;
        public static readonly int HOE                      = 10;
        public static readonly int SHEARS                   = 11;
        public static readonly int FLINT_AND_STEEL          = 12;
        public static readonly int BOW                      = 13;
        public static readonly int CROSSBOW                 = 14;
        public static readonly int FISHING_ROD              = 15;
        public static readonly int CARROT_ON_A_STICK        = 16;
        public static readonly int WARPED_FUNGUS_ON_A_STICK = 17;
        public static readonly int TRIDENT                  = 18;
        public static readonly int ELYTRA                   = 19;
        public static readonly int HEAD                     = 20;
        public static readonly int BOOK                     = 21;
        
        //Enchantments
        public static readonly int PROTECTION               =  0;
        public static readonly int FIRE_PROTECTION          =  1;
        public static readonly int FEATHER_FALLING          =  2;
        public static readonly int BLAST_PROTECTION         =  3;
        public static readonly int PROJECTILE_PROTECTION    =  4;
        public static readonly int THORNS                   =  5;
        public static readonly int RESPIRATION              =  6;
        public static readonly int DEPTH_STRIDER            =  7;
        public static readonly int AQUA_AFFINITY            =  8;
        public static readonly int SHARPNESS                =  9;
        public static readonly int SMITE                    = 10;
        public static readonly int BANE_OF_ARTHROPODS       = 11;
        public static readonly int KNOCKBACK                = 12;
        public static readonly int FIRE_ASPECT              = 13;
        public static readonly int LOOTING                  = 14;
        public static readonly int EFFICIENCY               = 15;
        public static readonly int SILK_TOUCH               = 16;
        public static readonly int UNBREAKING               = 17;
        public static readonly int FORTUNE                  = 18;
        public static readonly int POWER                    = 19;
        public static readonly int PUNCH                    = 20;
        public static readonly int FLAME                    = 21;
        public static readonly int INFINITY                 = 22;
        public static readonly int LUCK_OF_THE_SEA          = 23;
        public static readonly int LURE                     = 24;
        public static readonly int FROST_WALKER             = 25;
        public static readonly int MENDING                  = 26;
        public static readonly int CURSE_OF_BINDING         = 27;
        public static readonly int CURSE_OF_VANISHING       = 28;
        public static readonly int IMPALING                 = 29;
        public static readonly int RIPTIDE                  = 30;
        public static readonly int LOYALTY                  = 31;
        public static readonly int CHANNELING               = 32;
        public static readonly int MULTISHOT                = 33;
        public static readonly int PIERCING                 = 34;
        public static readonly int QUICK_CHARGE             = 35;
        public static readonly int SOUL_SPEED               = 36;
        public static readonly int SWEEPING_EDGE            = 37;
        
        public static readonly ItemInfo [] Items =
        {
            new ItemInfo( 0, "TURTLE SHELL",             0b11100000000100000000101111011),
            new ItemInfo( 1, "HELMET",                   0b11100000000100000000101111011),
            new ItemInfo( 2, "CHESTPLATE",               0b11100000000100000000000111011),
            new ItemInfo( 3, "LEGGINGS",                 0b11100000000100000000000111011),
            new ItemInfo( 4, "BOOTS",                    0b1000000011110000000100000000010111111),
            new ItemInfo( 5, "SHIELD",                   0b10100000000100000000000000000),
            new ItemInfo( 6, "SWORD",                    0b10000000010100000000100111111000000000),
            new ItemInfo( 7, "AXE",                      0b10100000001111000111000000000),
            new ItemInfo( 8, "PICKAXE",                  0b10100000001111000000000000000),
            new ItemInfo( 9, "SHOVEL",                   0b10100000001111000000000000000),
            new ItemInfo(10, "HOE",                      0b10100000001111000000000000000),
            new ItemInfo(11, "SHEARS",                   0b10100000000101000000000000000),
            new ItemInfo(12, "FLINT AND STEEL",          0b10100000000100000000000000000),
            new ItemInfo(13, "BOW",                      0b10100011110100000000000000000),
            new ItemInfo(14, "CROSSBOW",                 0b111000010100000000100000000000000000),
            new ItemInfo(15, "FISHING ROD",              0b10101100000100000000000000000),
            new ItemInfo(16, "CARROT ON A STICK",        0b10100000000100000000000000000),
            new ItemInfo(17, "WARPED FUNGUS ON A STICK", 0b10100000000100000000000000000),
            new ItemInfo(18, "TRIDENT",                  0b111110100000000100000000000000000),
            new ItemInfo(19, "ELYTRA",                   0b11100000000100000000000000000),
            new ItemInfo(20, "HEAD",                     0b11000000000000000000000000000),
            new ItemInfo(21, "BOOK",                     0b11111111111111111111111111111111111111),
        };
        
        public static readonly EnchantmentInfo [] Enchantments =
        {
            new EnchantmentInfo( 0, "Protection",            4,  1,  1, 0b1000000000000000011111, 0b11010),
            new EnchantmentInfo( 1, "Fire Protection",       4,  2,  1, 0b1000000000000000011111, 0b11001),
            new EnchantmentInfo( 2, "Feather Falling",       4,  2,  1, 0b1000000000000000010000, 0),
            new EnchantmentInfo( 3, "Blast Protection",      4,  4,  2, 0b1000000000000000011111, 0b10011),
            new EnchantmentInfo( 4, "Projectile Protection", 4,  2,  1, 0b1000000000000000011111, 0b01011),
            new EnchantmentInfo( 5, "Thorns",                3,  8,  4, 0b1000000000000000011111, 0),
            new EnchantmentInfo( 6, "Respiration",           3,  4,  2, 0b1000000000000000000011, 0),
            new EnchantmentInfo( 7, "Depth Strider",         3,  4,  2, 0b1000000000000000010000, 0b10000000000000000000000000),
            new EnchantmentInfo( 8, "Aqua Affinity",         1,  4,  2, 0b1000000000000000000011, 0),
            new EnchantmentInfo( 9, "Sharpness",             5,  1,  1, 0b1000000000000011000000, 0b110000000000),
            new EnchantmentInfo(10, "Smite",                 5,  2,  1, 0b1000000000000011000000, 0b101000000000),
            new EnchantmentInfo(11, "Bane of Arthropods",    5,  2,  1, 0b1000000000000011000000, 0b011000000000),
            new EnchantmentInfo(12, "Knockback",             2,  2,  1, 0b1000000000000001000000, 0),
            new EnchantmentInfo(13, "Fire Aspect",           2,  4,  2, 0b1000000000000001000000, 0),
            new EnchantmentInfo(14, "Looting",               3,  4,  2, 0b1000000000000001000000, 0b10000000000000000),
            new EnchantmentInfo(15, "Efficiency",            5,  1,  1, 0b1000000000111110000000, 0),
            new EnchantmentInfo(16, "Silk Touch",            1,  8,  4, 0b1000000000011110000000, 0b1000100000000000000),
            new EnchantmentInfo(17, "Unbreaking",            3,  2,  1, 0b1011111111111111111111, 0),
            new EnchantmentInfo(18, "Fortune",               3,  4,  2, 0b1000000000011110000000, 0b10000000000000000),
            new EnchantmentInfo(19, "Power",                 5,  1,  1, 0b1000000010000000000000, 0),
            new EnchantmentInfo(20, "Punch",                 2,  4,  2, 0b1000000010000000000000, 0),
            new EnchantmentInfo(21, "Flame",                 1,  4,  2, 0b1000000010000000000000, 0),
            new EnchantmentInfo(22, "Infinity",              1,  8,  4, 0b1000000010000000000000, 0b100000000000000000000000000),
            new EnchantmentInfo(23, "Luck of the Sea",       3,  4,  2, 0b1000001000000000000000, 0),
            new EnchantmentInfo(24, "Lure",                  3,  4,  2, 0b1000001000000000000000, 0),
            new EnchantmentInfo(25, "Frost Walker",          2,  4,  2, 0b1000000000000000010000, 0b10000000),
            new EnchantmentInfo(26, "Mending",               1,  4,  2, 0b1011111111111111111111, 0b10000000000000000000000),
            new EnchantmentInfo(27, "Curse of Binding",      1,  8,  4, 0b1110000000000000011111, 0),
            new EnchantmentInfo(28, "Curse of Vanishing",    1,  8,  4, 0b1111111111111111111111, 0),
            new EnchantmentInfo(29, "Impaling",              5,  4,  2, 0b1001000000000000000000, 0),
            new EnchantmentInfo(30, "Riptide",               3,  4,  2, 0b1001000000000000000000, 0b110000000000000000000000000000000),
            new EnchantmentInfo(31, "Loyalty",               3,  1,  1, 0b1001000000000000000000, 0b1000000000000000000000000000000),
            new EnchantmentInfo(32, "Channeling",            1,  8,  4, 0b1001000000000000000000, 0b1000000000000000000000000000000),
            new EnchantmentInfo(33, "Multishot",             1,  4,  2, 0b1000000100000000000000, 0b10000000000000000000000000000000000),
            new EnchantmentInfo(34, "Piercing",              4,  1,  1, 0b1000000100000000000000, 0b1000000000000000000000000000000000),
            new EnchantmentInfo(35, "Quick Charge",          3,  2,  1, 0b1000000100000000000000, 0),
            new EnchantmentInfo(36, "Soul Speed",            3,  8,  4, 0b1000000000000000010000, 0),
            new EnchantmentInfo(37, "Sweeping Edge",         3,  4,  2, 0b1000000000000001000000, 0),
        };
        
        public static int NextLevel(Enchantment e)
        {
            int max = Enchantments[e.Id].Maxlevel;
            int lvl = e.Level + 1;
            return lvl <= max ? lvl : max;
        }
        
        public static bool IsEnchantmentApplicable(int i, int e)
        {
            return 0 != ((1 << i) & Enchantments[e].ApplicableItems) ? true : false;
        }
        
        public static EnchantmentInfo GetEnchantmentInfo(string name)
        {
            return Array.Find(Enchantments, x => x.Name == name);
        }
        
        public static ItemInfo GetItemInfo(string name)
        {
            return Array.Find(Items, x => x.Name == name);
        }
        
        public static string GetEnchantmentName(int eid)
        {
            return Enchantments[eid].Name;
        }
        
        public static string [] GetEnchantmentNamesFromSet(UInt64 set)
        {
            set = 0 == set ? 0b1111111111111111111111111111111111111UL : set;
        
            List<string> names = new List<string>();
        
            foreach (EnchantmentInfo e in Enchantments)
            {
                if (0 != (set & (1UL << e.Id)))
                {
                    names.Add(e.Name);
                }
            }
        
            return names.ToArray();
        }
        
        public static string [] GetItemNamesFromSet(UInt32 set)
        {
            set = 0 == set ? 0b1111111111111111111111U : set;
        
            List<string> names = new List<string>();
        
            foreach (ItemInfo i in Items)
            {
                if (0 != (set & (1U << i.Id)))
                {
                    names.Add(i.Name);
                }
            }
        
            return names.ToArray();
        }
        
        public static Item CopyItem(Item i)
        {
            Item ni = new Item(i.Info.Id)
            {
                AnvilUses = i.AnvilUses,
                SacrificeValue = i.SacrificeValue,
                AppliedEnchantments = i.AppliedEnchantments
            };
        
            foreach (Enchantment e in i.AppliedEnchantmentsList)
            {
                ni.AddEnchantment(e.Id, e.Level, e.Preserved, false);
            }
        
            return ni;
        }
        
        public static AnvilStep CopyAnvilStep(AnvilStep s)
        {
            return new AnvilStep
            {
                Target = CopyItem(s.Target),
                Sacrifice = CopyItem(s.Sacrifice),
                Result = CopyItem(s.Result),
                Cost = s.Cost
            };
        }
        
        public static int EnchantmentValue(int iid, int eid, int level)
        {
            return (iid != BOOK)
                   ? 
                   MC.Enchantments[eid].ItemMultiplier * level 
                   : 
                   MC.Enchantments[eid].BookMultiplier * level;
        }
    }

    public class Enchantment
    {
        public int Id;
        public int Level;
        public bool Preserved;
    
        public Enchantment(int id, int level, bool preserve)
        {
            Id = id;
            Level = level;
            Preserved = preserve;
        }
    }
    
    public class Item
    {
        public int SacrificeValue;
        public int AnvilUses;
        public ItemInfo Info;
        public List<Enchantment> AppliedEnchantmentsList;
        public UInt64 AppliedEnchantments;
    
        public Item(int id)
        {
            AnvilUses = 0;
            AppliedEnchantmentsList = new List<Enchantment>();
            AppliedEnchantments = 0;
            Info = MC.Items[id];
            SacrificeValue = 0;
        }
    
        public void AddEnchantment(int id, int level, bool preserve, bool calcval)
        {
            Enchantment e = new Enchantment(id, level, preserve);
    
            if (calcval == true)
            {
                SacrificeValue += MC.EnchantmentValue(Info.Id, e.Id, e.Level);
            }
    
            AppliedEnchantments |= (1UL << e.Id);
            AppliedEnchantmentsList.Add(e);
        }
    
        public string PrintItemInfo()
        {
            string msg = "";
            msg += $"Anvil Uses:\n    {AnvilUses}\n";
            msg += $"Sacrifice Value:\n    {SacrificeValue}\n";
            msg += "Enchantments:\n";
        
            foreach (Enchantment e in AppliedEnchantmentsList)
            {
                msg += $"    {MC.Enchantments[e.Id].Name} {e.Level}";
                msg += e.Preserved == true ? " \u2713\n" : "\n";
            }
        
            return msg;
        }
    }
    
    public class AnvilStep
    {
        public Item Target;
        public Item Sacrifice;
        public Item Result;
        public int Cost;
    }
}