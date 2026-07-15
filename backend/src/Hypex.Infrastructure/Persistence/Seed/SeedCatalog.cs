namespace Hypex.Infrastructure.Persistence.Seed;

/// <summary>Static seed catalog: categories, brands, and products (RU/UZ/EN).</summary>
internal static partial class SeedCatalog
{
    // Stable category ids referenced by products.
    public const int CatLaptops = 1;
    public const int CatTablets = 2;
    public const int CatPhones = 3;
    public const int CatGadgets = 4;
    public const int CatHeadsets = 5;

    public static readonly IReadOnlyList<CategorySeed> Categories = new List<CategorySeed>
    {
        new(CatLaptops, "laptops",  new("Ноутбуки",  "Noutbuklar",   "Laptops")),
        new(CatTablets, "tablets",  new("Планшеты",  "Planshetlar",  "Tablets")),
        new(CatPhones,  "phones",   new("Смартфоны", "Smartfonlar",  "Smartphones")),
        new(CatGadgets, "gadgets",  new("Гаджеты",   "Gadjetlar",    "Gadgets")),
        new(CatHeadsets,"headsets", new("Гарнитуры", "Garnituralar", "Headsets")),
    };

    // Stable brand ids referenced by products.
    public const int BrApple = 1;
    public const int BrSamsung = 2;
    public const int BrXiaomi = 3;
    public const int BrSony = 4;
    public const int BrAsus = 5;
    public const int BrLenovo = 6;
    public const int BrDell = 7;
    public const int BrHp = 8;
    public const int BrGoogle = 9;
    public const int BrJbl = 10;
    public const int BrLogitech = 11;
    public const int BrHuawei = 12;

    public static readonly IReadOnlyList<BrandSeed> Brands = new List<BrandSeed>
    {
        new(BrApple,    "apple",    "Apple"),
        new(BrSamsung,  "samsung",  "Samsung"),
        new(BrXiaomi,   "xiaomi",   "Xiaomi"),
        new(BrSony,     "sony",     "Sony"),
        new(BrAsus,     "asus",     "ASUS"),
        new(BrLenovo,   "lenovo",   "Lenovo"),
        new(BrDell,     "dell",     "Dell"),
        new(BrHp,       "hp",       "HP"),
        new(BrGoogle,   "google",   "Google"),
        new(BrJbl,      "jbl",      "JBL"),
        new(BrLogitech, "logitech", "Logitech"),
        new(BrHuawei,   "huawei",   "Huawei"),
    };
}
