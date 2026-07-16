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
    public const int CatSmartwatches = 6;
    public const int CatTvs = 7;
    public const int CatMonitors = 8;
    public const int CatPeripherals = 9;
    public const int CatAccessories = 10;

    public static readonly IReadOnlyList<CategorySeed> Categories = new List<CategorySeed>
    {
        new(CatLaptops,      "laptops",      new("Ноутбуки",       "Noutbuklar",       "Laptops")),
        new(CatTablets,      "tablets",      new("Планшеты",       "Planshetlar",      "Tablets")),
        new(CatPhones,       "phones",       new("Смартфоны",      "Smartfonlar",      "Smartphones")),
        new(CatGadgets,      "gadgets",      new("Гаджеты",        "Gadjetlar",        "Gadgets")),
        new(CatHeadsets,     "headsets",     new("Гарнитуры",      "Garnituralar",     "Headsets")),
        new(CatSmartwatches, "smartwatches", new("Умные часы",     "Aqlli soatlar",    "Smart watches")),
        new(CatTvs,          "tvs",          new("Телевизоры",     "Televizorlar",     "TVs")),
        new(CatMonitors,     "monitors",     new("Мониторы",       "Monitorlar",       "Monitors")),
        new(CatPeripherals,  "peripherals",  new("Клавиатуры и мыши", "Klaviatura va sichqonchalar", "Keyboards & mice")),
        new(CatAccessories,  "accessories",  new("Аксессуары",     "Aksessuarlar",     "Accessories")),
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
        // Brand logos: Simple Icons monochrome SVGs via jsDelivr CDN (stable, version-pinned).
        new(BrApple,    "apple",    "Apple",    "https://cdn.jsdelivr.net/npm/simple-icons@13/icons/apple.svg"),
        new(BrSamsung,  "samsung",  "Samsung",  "https://cdn.jsdelivr.net/npm/simple-icons@13/icons/samsung.svg"),
        new(BrXiaomi,   "xiaomi",   "Xiaomi",   "https://cdn.jsdelivr.net/npm/simple-icons@13/icons/xiaomi.svg"),
        new(BrSony,     "sony",     "Sony",     "https://cdn.jsdelivr.net/npm/simple-icons@13/icons/sony.svg"),
        new(BrAsus,     "asus",     "ASUS",     "https://cdn.jsdelivr.net/npm/simple-icons@13/icons/asus.svg"),
        new(BrLenovo,   "lenovo",   "Lenovo",   "https://cdn.jsdelivr.net/npm/simple-icons@13/icons/lenovo.svg"),
        new(BrDell,     "dell",     "Dell",     "https://cdn.jsdelivr.net/npm/simple-icons@13/icons/dell.svg"),
        new(BrHp,       "hp",       "HP",       "https://cdn.jsdelivr.net/npm/simple-icons@13/icons/hp.svg"),
        new(BrGoogle,   "google",   "Google",   "https://cdn.jsdelivr.net/npm/simple-icons@13/icons/google.svg"),
        new(BrJbl,      "jbl",      "JBL",      "https://cdn.jsdelivr.net/npm/simple-icons@13/icons/jbl.svg"),
        new(BrLogitech, "logitech", "Logitech", "https://cdn.jsdelivr.net/npm/simple-icons@13/icons/logitech.svg"),
        new(BrHuawei,   "huawei",   "Huawei",   "https://cdn.jsdelivr.net/npm/simple-icons@13/icons/huawei.svg"),
    };
}
