namespace Hypex.Infrastructure.Persistence.Seed;

/// <summary>Seed products (RU/UZ/EN) across all five categories.</summary>
internal static partial class SeedCatalog
{
    public static readonly IReadOnlyList<ProductSeed> Products = new List<ProductSeed>
    {
        // ==================== LAPTOPS (Cat 1) ====================
        new(
            "macbook-pro-14-m3-pro",
            CatLaptops, BrApple, 1999.00m, 34,
            new("MacBook Pro 14 M3 Pro", "MacBook Pro 14 M3 Pro", "MacBook Pro 14 M3 Pro"),
            new(
                "14-дюймовый ноутбук с чипом Apple M3 Pro, дисплеем Liquid Retina XDR и автономностью до 18 часов.",
                "Apple M3 Pro chipli 14 dyuymli noutbuk, Liquid Retina XDR displey va 18 soatgacha quvvat bilan ishlaydi.",
                "A 14-inch laptop with the Apple M3 Pro chip, Liquid Retina XDR display and up to 18 hours of battery life."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1611186871348-b1ce696e52c9?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1541807084-5c52b6b3adef?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M3 Pro", "Apple M3 Pro", "Apple M3 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("18 ГБ", "18 GB", "18 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("512 ГБ SSD", "512 GB SSD", "512 GB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("14.2 дюйма Liquid Retina XDR", "14.2 dyuym Liquid Retina XDR", "14.2 inch Liquid Retina XDR")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("18-ядерный GPU", "18 yadroli GPU", "18-core GPU")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.61 кг", "1.61 kg", "1.61 kg")),
            },
            4.9, 214),

        new(
            "macbook-air-13-m3",
            CatLaptops, BrApple, 1099.00m, 58,
            new("MacBook Air 13 M3", "MacBook Air 13 M3", "MacBook Air 13 M3"),
            new(
                "Тонкий и лёгкий ноутбук на чипе Apple M3 с безвентиляторным охлаждением и дисплеем Liquid Retina.",
                "Apple M3 chipli yupqa va yengil noutbuk, ventilyatorsiz sovutish tizimi va Liquid Retina displey bilan.",
                "A thin and light laptop powered by the Apple M3 chip with fanless cooling and a Liquid Retina display."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1611186871348-b1ce696e52c9?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1531297484001-80022131f5a1?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M3", "Apple M3", "Apple M3")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("16 ГБ", "16 GB", "16 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("512 ГБ SSD", "512 GB SSD", "512 GB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("13.6 дюйма Liquid Retina", "13.6 dyuym Liquid Retina", "13.6 inch Liquid Retina")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("10-ядерный GPU", "10 yadroli GPU", "10-core GPU")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.24 кг", "1.24 kg", "1.24 kg")),
            },
            4.8, 176),

        new(
            "asus-rog-zephyrus-g14",
            CatLaptops, BrAsus, 1799.00m, 21,
            new("ASUS ROG Zephyrus G14", "ASUS ROG Zephyrus G14", "ASUS ROG Zephyrus G14"),
            new(
                "Компактный игровой ноутбук с процессором Ryzen 9, видеокартой RTX 4070 и OLED-экраном 120 Гц.",
                "Ryzen 9 protsessori, RTX 4070 videokartasi va 120 Hz OLED ekranli ixcham geyming noutbuk.",
                "A compact gaming laptop with a Ryzen 9 processor, RTX 4070 graphics and a 120 Hz OLED display."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1603302576837-37561b2e2302?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1595044426077-d36d9236d54a?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1618424181497-157f25b6ddd5?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("AMD Ryzen 9 8945HS", "AMD Ryzen 9 8945HS", "AMD Ryzen 9 8945HS")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("32 ГБ", "32 GB", "32 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("1 ТБ SSD", "1 TB SSD", "1 TB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("14 дюймов OLED 120 Гц", "14 dyuym OLED 120 Hz", "14 inch OLED 120 Hz")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("NVIDIA GeForce RTX 4070", "NVIDIA GeForce RTX 4070", "NVIDIA GeForce RTX 4070")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.5 кг", "1.5 kg", "1.5 kg")),
            },
            4.7, 143),

        new(
            "dell-xps-13-plus",
            CatLaptops, BrDell, 1399.00m, 0,
            new("Dell XPS 13 Plus", "Dell XPS 13 Plus", "Dell XPS 13 Plus"),
            new(
                "Премиальный ультрабук с процессором Intel Core Ultra 7, безрамочным дисплеем InfinityEdge и сенсорной панелью функций.",
                "Intel Core Ultra 7 protsessori, ramkasiz InfinityEdge displey va sensorli funksiya paneliga ega premium ultrabuk.",
                "A premium ultrabook with an Intel Core Ultra 7 processor, an InfinityEdge borderless display and a touch function row."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1593642702821-c8da6771f0c6?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1588872657578-7efd1f1555ed?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Intel Core Ultra 7 155H", "Intel Core Ultra 7 155H", "Intel Core Ultra 7 155H")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("16 ГБ", "16 GB", "16 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("512 ГБ SSD", "512 GB SSD", "512 GB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("13.4 дюйма OLED 3.5K", "13.4 dyuym OLED 3.5K", "13.4 inch OLED 3.5K")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("Intel Arc Graphics", "Intel Arc Graphics", "Intel Arc Graphics")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.24 кг", "1.24 kg", "1.24 kg")),
            },
            4.5, 89),

        new(
            "lenovo-thinkpad-x1-carbon-gen12",
            CatLaptops, BrLenovo, 1649.00m, 27,
            new("Lenovo ThinkPad X1 Carbon Gen 12", "Lenovo ThinkPad X1 Carbon Gen 12", "Lenovo ThinkPad X1 Carbon Gen 12"),
            new(
                "Лёгкий бизнес-ноутбук из углеродного волокна с надёжной клавиатурой и защитой военного стандарта.",
                "Uglerod tolasidan yasalgan yengil biznes-noutbuk, ishonchli klaviatura va harbiy standart himoyasi bilan.",
                "A lightweight carbon-fiber business laptop with a reliable keyboard and military-grade durability."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1525547719571-a2d4ac8945e2?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Intel Core Ultra 7 155U", "Intel Core Ultra 7 155U", "Intel Core Ultra 7 155U")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("32 ГБ", "32 GB", "32 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("1 ТБ SSD", "1 TB SSD", "1 TB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("14 дюймов IPS 2.8K", "14 dyuym IPS 2.8K", "14 inch IPS 2.8K")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("Intel Graphics", "Intel Graphics", "Intel Graphics")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.12 кг", "1.12 kg", "1.12 kg")),
            },
            4.6, 112),

        new(
            "hp-spectre-x360-14",
            CatLaptops, BrHp, 1499.00m, 40,
            new("HP Spectre x360 14", "HP Spectre x360 14", "HP Spectre x360 14"),
            new(
                "Ноутбук-трансформер 2-в-1 с сенсорным OLED-дисплеем, поворотом на 360 градусов и пером в комплекте.",
                "Sensorli OLED displeyli, 360 gradusga buriladigan va qalam bilan birga keladigan 2-in-1 transformer noutbuk.",
                "A 2-in-1 convertible laptop with a touch OLED display, a 360-degree hinge and an included pen."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1544731612-de7f96afe55f?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1629131726692-1accd0c53ce0?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Intel Core Ultra 7 155H", "Intel Core Ultra 7 155H", "Intel Core Ultra 7 155H")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("16 ГБ", "16 GB", "16 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("1 ТБ SSD", "1 TB SSD", "1 TB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("14 дюймов OLED 2.8K сенсорный", "14 dyuym OLED 2.8K sensorli", "14 inch OLED 2.8K touch")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("Intel Arc Graphics", "Intel Arc Graphics", "Intel Arc Graphics")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.44 кг", "1.44 kg", "1.44 kg")),
            },
            4.4, 67),

        // ==================== TABLETS (Cat 2) ====================
        new(
            "ipad-pro-13-m4",
            CatTablets, BrApple, 1299.00m, 45,
            new("iPad Pro 13 M4", "iPad Pro 13 M4", "iPad Pro 13 M4"),
            new(
                "Самый мощный iPad с чипом Apple M4 и дисплеем Ultra Retina XDR OLED толщиной всего 5.1 мм.",
                "Apple M4 chipi va Ultra Retina XDR OLED displeyli, atigi 5.1 mm qalinlikdagi eng kuchli iPad.",
                "The most powerful iPad with the Apple M4 chip and an Ultra Retina XDR OLED display just 5.1 mm thin."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1544244015-0df4b3ffc6b0?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1561154464-82e9adf32764?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1557825835-70d97c4aa567?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M4", "Apple M4", "Apple M4")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("13 дюймов Ultra Retina XDR OLED", "13 dyuym Ultra Retina XDR OLED", "13 inch Ultra Retina XDR OLED")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("До 10 часов", "10 soatgacha", "Up to 10 hours")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("iPadOS", "iPadOS", "iPadOS")),
            },
            4.8, 158),

        new(
            "samsung-galaxy-tab-s9-ultra",
            CatTablets, BrSamsung, 1199.00m, 30,
            new("Samsung Galaxy Tab S9 Ultra", "Samsung Galaxy Tab S9 Ultra", "Samsung Galaxy Tab S9 Ultra"),
            new(
                "Огромный 14.6-дюймовый AMOLED-планшет с влагозащитой IP68 и пером S Pen в комплекте.",
                "IP68 suvdan himoya va S Pen qalami bilan keladigan ulkan 14.6 dyuymli AMOLED planshet.",
                "A huge 14.6-inch AMOLED tablet with IP68 water resistance and an included S Pen."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1585790050230-5dd28404ccb9?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1623126908029-58cb08a2b272?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 8 Gen 2", "Snapdragon 8 Gen 2", "Snapdragon 8 Gen 2")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("14.6 дюйма Dynamic AMOLED 2X", "14.6 dyuym Dynamic AMOLED 2X", "14.6 inch Dynamic AMOLED 2X")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("11200 мА·ч", "11200 mA·soat", "11200 mAh")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Android", "Android", "Android")),
            },
            4.6, 94),

        new(
            "xiaomi-pad-6",
            CatTablets, BrXiaomi, 349.00m, 76,
            new("Xiaomi Pad 6", "Xiaomi Pad 6", "Xiaomi Pad 6"),
            new(
                "Доступный планшет с экраном 144 Гц, стереодинамиками Dolby Atmos и быстрой зарядкой 33 Вт.",
                "144 Hz ekran, Dolby Atmos stereo dinamiklar va 33 Vt tezkor quvvatlash bilan hamyonbop planshet.",
                "An affordable tablet with a 144 Hz display, Dolby Atmos stereo speakers and 33 W fast charging."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1542751110-97427bbecf20?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1585123334904-845d60e97b29?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 870", "Snapdragon 870", "Snapdragon 870")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("128 ГБ", "128 GB", "128 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("11 дюймов IPS 144 Гц", "11 dyuym IPS 144 Hz", "11 inch IPS 144 Hz")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("8840 мА·ч", "8840 mA·soat", "8840 mAh")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Android", "Android", "Android")),
            },
            4.5, 203),

        new(
            "huawei-matepad-pro-11",
            CatTablets, BrHuawei, 599.00m, 18,
            new("Huawei MatePad Pro 11", "Huawei MatePad Pro 11", "Huawei MatePad Pro 11"),
            new(
                "Планшет с ярким OLED-дисплеем 120 Гц, четырьмя динамиками и поддержкой пера M-Pencil.",
                "Yorqin OLED 120 Hz displey, to'rtta dinamik va M-Pencil qalami qo'llab-quvvatlashiga ega planshet.",
                "A tablet with a bright 120 Hz OLED display, quad speakers and M-Pencil stylus support."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1587033411391-5d9e51cce126?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1600541519467-937869997e34?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 8+ Gen 1", "Snapdragon 8+ Gen 1", "Snapdragon 8+ Gen 1")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("11 дюймов OLED 120 Гц", "11 dyuym OLED 120 Hz", "11 inch OLED 120 Hz")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("8300 мА·ч", "8300 mA·soat", "8300 mAh")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("HarmonyOS", "HarmonyOS", "HarmonyOS")),
            },
            4.3, 51),

        new(
            "lenovo-tab-p12",
            CatTablets, BrLenovo, 329.00m, 62,
            new("Lenovo Tab P12", "Lenovo Tab P12", "Lenovo Tab P12"),
            new(
                "Большой 12.7-дюймовый планшет для развлечений с экраном 3K, четырьмя динамиками JBL и пером в комплекте.",
                "3K ekran, to'rtta JBL dinamigi va qalam bilan keladigan katta 12.7 dyuymli ko'ngilochar planshet.",
                "A large 12.7-inch entertainment tablet with a 3K display, quad JBL speakers and an included pen."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1623126908029-58cb08a2b272?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1544244015-0df4b3ffc6b0?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("MediaTek Dimensity 7050", "MediaTek Dimensity 7050", "MediaTek Dimensity 7050")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("128 ГБ", "128 GB", "128 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("12.7 дюйма IPS 3K", "12.7 dyuym IPS 3K", "12.7 inch IPS 3K")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("10200 мА·ч", "10200 mA·soat", "10200 mAh")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Android", "Android", "Android")),
            },
            4.2, 38),

        // ==================== PHONES (Cat 3) ====================
        new(
            "iphone-15-pro-max",
            CatPhones, BrApple, 1199.00m, 52,
            new("iPhone 15 Pro Max", "iPhone 15 Pro Max", "iPhone 15 Pro Max"),
            new(
                "Титановый флагман с чипом A17 Pro, кнопкой действия и 5-кратным телеобъективом.",
                "A17 Pro chipi, Action tugmasi va 5 barobar teleob'ektivga ega titan flagman.",
                "A titanium flagship with the A17 Pro chip, an Action button and a 5x telephoto camera."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1695048133142-1a20484d2569?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1678652197831-2d180705cd2c?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1592286927505-1def25115558?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A17 Pro", "Apple A17 Pro", "Apple A17 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.7 дюйма Super Retina XDR", "6.7 dyuym Super Retina XDR", "6.7 inch Super Retina XDR")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп тройная", "48 MP uchlik", "48 MP triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("4441 мА·ч", "4441 mA·soat", "4441 mAh")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("iOS", "iOS", "iOS")),
            },
            4.9, 512),

        new(
            "iphone-15",
            CatPhones, BrApple, 799.00m, 88,
            new("iPhone 15", "iPhone 15", "iPhone 15"),
            new(
                "Смартфон с динамическим островом Dynamic Island, камерой 48 Мп и разъёмом USB-C.",
                "Dynamic Island, 48 MP kamera va USB-C ulagichiga ega smartfon.",
                "A smartphone with Dynamic Island, a 48 MP camera and a USB-C port."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1592750475338-74b7b21085ab?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1510557880182-3d4d3cba35a5?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A16 Bionic", "Apple A16 Bionic", "Apple A16 Bionic")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("6 ГБ", "6 GB", "6 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("128 ГБ", "128 GB", "128 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.1 дюйма Super Retina XDR", "6.1 dyuym Super Retina XDR", "6.1 inch Super Retina XDR")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп двойная", "48 MP ikkilik", "48 MP dual")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("3349 мА·ч", "3349 mA·soat", "3349 mAh")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("iOS", "iOS", "iOS")),
            },
            4.7, 401),

        new(
            "galaxy-s24-ultra",
            CatPhones, BrSamsung, 1299.00m, 47,
            new("Samsung Galaxy S24 Ultra", "Samsung Galaxy S24 Ultra", "Samsung Galaxy S24 Ultra"),
            new(
                "Флагман с титановым корпусом, встроенным пером S Pen, камерой 200 Мп и функциями Galaxy AI.",
                "Titan korpus, o'rnatilgan S Pen qalami, 200 MP kamera va Galaxy AI funksiyalariga ega flagman.",
                "A flagship with a titanium frame, a built-in S Pen, a 200 MP camera and Galaxy AI features."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1610945265064-0e34e5519bbf?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1610792516307-ea5acd9c3b00?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 8 Gen 3", "Snapdragon 8 Gen 3", "Snapdragon 8 Gen 3")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("512 ГБ", "512 GB", "512 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.8 дюйма Dynamic AMOLED 2X", "6.8 dyuym Dynamic AMOLED 2X", "6.8 inch Dynamic AMOLED 2X")),
                new("camera", new("Камера", "Kamera", "Camera"), new("200 Мп четверная", "200 MP to'rtlik", "200 MP quad")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("5000 мА·ч", "5000 mA·soat", "5000 mAh")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Android", "Android", "Android")),
            },
            4.8, 367),

        new(
            "galaxy-s24",
            CatPhones, BrSamsung, 799.00m, 64,
            new("Samsung Galaxy S24", "Samsung Galaxy S24", "Samsung Galaxy S24"),
            new(
                "Компактный флагман с ярким экраном 2600 нит, тройной камерой и умными функциями Galaxy AI.",
                "2600 nit yorqin ekran, uchlik kamera va aqlli Galaxy AI funksiyalariga ega ixcham flagman.",
                "A compact flagship with a bright 2600-nit display, a triple camera and smart Galaxy AI features."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1610792516307-ea5acd9c3b00?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1610945265064-0e34e5519bbf?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Exynos 2400", "Exynos 2400", "Exynos 2400")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.2 дюйма Dynamic AMOLED 2X", "6.2 dyuym Dynamic AMOLED 2X", "6.2 inch Dynamic AMOLED 2X")),
                new("camera", new("Камера", "Kamera", "Camera"), new("50 Мп тройная", "50 MP uchlik", "50 MP triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("4000 мА·ч", "4000 mA·soat", "4000 mAh")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Android", "Android", "Android")),
            },
            4.6, 289),

        new(
            "xiaomi-14-pro",
            CatPhones, BrXiaomi, 899.00m, 39,
            new("Xiaomi 14 Pro", "Xiaomi 14 Pro", "Xiaomi 14 Pro"),
            new(
                "Флагман с оптикой Leica, переменной диафрагмой и сверхбыстрой зарядкой 120 Вт.",
                "Leica optikasi, o'zgaruvchan diafragma va 120 Vt o'ta tezkor quvvatlashga ega flagman.",
                "A flagship with Leica optics, a variable aperture and ultra-fast 120 W charging."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1616348436168-de43ad0db179?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1598327105666-5b89351aff97?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 8 Gen 3", "Snapdragon 8 Gen 3", "Snapdragon 8 Gen 3")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.73 дюйма LTPO AMOLED", "6.73 dyuym LTPO AMOLED", "6.73 inch LTPO AMOLED")),
                new("camera", new("Камера", "Kamera", "Camera"), new("50 Мп Leica тройная", "50 MP Leica uchlik", "50 MP Leica triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("4880 мА·ч", "4880 mA·soat", "4880 mAh")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Android", "Android", "Android")),
            },
            4.5, 156),

        new(
            "google-pixel-8-pro",
            CatPhones, BrGoogle, 999.00m, 0,
            new("Google Pixel 8 Pro", "Google Pixel 8 Pro", "Google Pixel 8 Pro"),
            new(
                "Смартфон с чипом Tensor G3, продвинутыми функциями ИИ и семью годами обновлений Android.",
                "Tensor G3 chipi, ilg'or sun'iy intellekt funksiyalari va yetti yillik Android yangilanishlariga ega smartfon.",
                "A smartphone with the Tensor G3 chip, advanced AI features and seven years of Android updates."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1565849904461-04a58ad377e0?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1598965402089-897ce52e8355?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Google Tensor G3", "Google Tensor G3", "Google Tensor G3")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("128 ГБ", "128 GB", "128 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.7 дюйма LTPO OLED", "6.7 dyuym LTPO OLED", "6.7 inch LTPO OLED")),
                new("camera", new("Камера", "Kamera", "Camera"), new("50 Мп тройная", "50 MP uchlik", "50 MP triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("5050 мА·ч", "5050 mA·soat", "5050 mAh")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Android", "Android", "Android")),
            },
            4.6, 198),

        new(
            "huawei-p60-pro",
            CatPhones, BrHuawei, 899.00m, 22,
            new("Huawei P60 Pro", "Huawei P60 Pro", "Huawei P60 Pro"),
            new(
                "Камерофон с ультрасветосильным объективом, дизайном под жемчуг и защитой IP68.",
                "O'ta yorug' ob'ektiv, marvarid uslubidagi dizayn va IP68 himoyaga ega kamerafon.",
                "A camera phone with an ultra-bright lens, a pearl-inspired design and IP68 protection."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1533228100845-08145b01de14?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1580910051074-3eb694886505?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 8+ Gen 1", "Snapdragon 8+ Gen 1", "Snapdragon 8+ Gen 1")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.67 дюйма LTPO OLED", "6.67 dyuym LTPO OLED", "6.67 inch LTPO OLED")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп тройная", "48 MP uchlik", "48 MP triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("4815 мА·ч", "4815 mA·soat", "4815 mAh")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("HarmonyOS", "HarmonyOS", "HarmonyOS")),
            },
            4.3, 74),

        new(
            "xiaomi-redmi-note-13-pro",
            CatPhones, BrXiaomi, 349.00m, 105,
            new("Xiaomi Redmi Note 13 Pro", "Xiaomi Redmi Note 13 Pro", "Xiaomi Redmi Note 13 Pro"),
            new(
                "Народный смартфон с камерой 200 Мп, экраном AMOLED 120 Гц и зарядкой 67 Вт.",
                "200 MP kamera, AMOLED 120 Hz ekran va 67 Vt quvvatlashga ega ommabop smartfon.",
                "A crowd-favorite smartphone with a 200 MP camera, a 120 Hz AMOLED display and 67 W charging."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1598327105666-5b89351aff97?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1616348436168-de43ad0db179?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 7s Gen 2", "Snapdragon 7s Gen 2", "Snapdragon 7s Gen 2")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.67 дюйма AMOLED 120 Гц", "6.67 dyuym AMOLED 120 Hz", "6.67 inch AMOLED 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("200 Мп тройная", "200 MP uchlik", "200 MP triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("5100 мА·ч", "5100 mA·soat", "5100 mAh")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Android", "Android", "Android")),
            },
            4.5, 342),

        // ==================== GADGETS (Cat 4) ====================
        new(
            "apple-watch-series-9",
            CatGadgets, BrApple, 399.00m, 71,
            new("Apple Watch Series 9", "Apple Watch Series 9", "Apple Watch Series 9"),
            new(
                "Умные часы с чипом S9, жестом двойного касания и ярким дисплеем до 2000 нит.",
                "S9 chipi, ikki marta bosish ishorasi va 2000 nitgacha yorqin displeyga ega aqlli soat.",
                "A smartwatch with the S9 chip, a double-tap gesture and a bright display up to 2000 nits."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1434493789847-2f02dc6ca35d?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1546868871-7041f2a55e12?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("screen", new("Экран", "Ekran", "Screen"), new("1.9 дюйма Retina LTPO OLED", "1.9 dyuym Retina LTPO OLED", "1.9 inch Retina LTPO OLED")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("До 18 часов", "18 soatgacha", "Up to 18 hours")),
                new("connectivity", new("Связь", "Aloqa", "Connectivity"), new("GPS, Bluetooth 5.3, Wi-Fi", "GPS, Bluetooth 5.3, Wi-Fi", "GPS, Bluetooth 5.3, Wi-Fi")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("watchOS", "watchOS", "watchOS")),
                new("waterproof", new("Водозащита", "Suvdan himoya", "Water resistance"), new("50 метров", "50 metr", "50 meters")),
                new("color", new("Цвет", "Rang", "Color"), new("Тёмная ночь", "Tungi qora", "Midnight")),
            },
            4.7, 231),

        new(
            "samsung-galaxy-watch-6",
            CatGadgets, BrSamsung, 329.00m, 54,
            new("Samsung Galaxy Watch 6", "Samsung Galaxy Watch 6", "Samsung Galaxy Watch 6"),
            new(
                "Смарт-часы с вращающимся сенсорным безелем, отслеживанием сна и датчиком состава тела.",
                "Aylanuvchi sensorli bezel, uyqu kuzatuvi va tana tarkibi sensoriga ega aqlli soat.",
                "A smartwatch with a rotating touch bezel, sleep tracking and a body-composition sensor."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1617043786394-f977fa12eddf?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1508685096489-7aacd43bd3b1?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("screen", new("Экран", "Ekran", "Screen"), new("1.5 дюйма Super AMOLED", "1.5 dyuym Super AMOLED", "1.5 inch Super AMOLED")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("425 мА·ч", "425 mA·soat", "425 mAh")),
                new("connectivity", new("Связь", "Aloqa", "Connectivity"), new("GPS, Bluetooth 5.3, Wi-Fi", "GPS, Bluetooth 5.3, Wi-Fi", "GPS, Bluetooth 5.3, Wi-Fi")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Wear OS", "Wear OS", "Wear OS")),
                new("waterproof", new("Водозащита", "Suvdan himoya", "Water resistance"), new("5 АТМ + IP68", "5 ATM + IP68", "5 ATM + IP68")),
                new("color", new("Цвет", "Rang", "Color"), new("Графит", "Grafit", "Graphite")),
            },
            4.5, 147),

        new(
            "xiaomi-power-bank-20000",
            CatGadgets, BrXiaomi, 39.00m, 118,
            new("Xiaomi Power Bank 20000 мА·ч", "Xiaomi Power Bank 20000 mA·soat", "Xiaomi Power Bank 20000 mAh"),
            new(
                "Внешний аккумулятор на 20000 мА·ч с быстрой зарядкой 22.5 Вт и двумя портами USB.",
                "20000 mA·soat sig'imli, 22.5 Vt tezkor quvvatlash va ikkita USB portli tashqi batareya.",
                "A 20000 mAh power bank with 22.5 W fast charging and two USB ports."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1609091839311-d5365f9ff1c5?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1583863788434-e58a36330cf0?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("capacity", new("Ёмкость", "Sig'im", "Capacity"), new("20000 мА·ч", "20000 mA·soat", "20000 mAh")),
                new("power", new("Мощность", "Quvvat", "Power output"), new("22.5 Вт", "22.5 Vt", "22.5 W")),
                new("connectivity", new("Порты", "Portlar", "Ports"), new("2x USB-A, 1x USB-C", "2x USB-A, 1x USB-C", "2x USB-A, 1x USB-C")),
                new("weight", new("Вес", "Vazn", "Weight"), new("435 г", "435 g", "435 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный", "Qora", "Black")),
            },
            4.4, 528),

        new(
            "logitech-mx-master-3s",
            CatGadgets, BrLogitech, 99.00m, 83,
            new("Logitech MX Master 3S", "Logitech MX Master 3S", "Logitech MX Master 3S"),
            new(
                "Беспроводная мышь для профессионалов с бесшумными кнопками и датчиком 8000 DPI.",
                "Ovozsiz tugmalar va 8000 DPI sensoriga ega professionallar uchun simsiz sichqoncha.",
                "A wireless mouse for professionals with quiet clicks and an 8000 DPI sensor."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1527814050087-3793815479db?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1615663245857-ac93bb7c39e7?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("sensor", new("Сенсор", "Sensor", "Sensor"), new("8000 DPI", "8000 DPI", "8000 DPI")),
                new("connectivity", new("Связь", "Aloqa", "Connectivity"), new("Bluetooth, Logi Bolt USB", "Bluetooth, Logi Bolt USB", "Bluetooth, Logi Bolt USB")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("До 70 дней", "70 kungacha", "Up to 70 days")),
                new("weight", new("Вес", "Vazn", "Weight"), new("141 г", "141 g", "141 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Графит", "Grafit", "Graphite")),
            },
            4.8, 419),

        new(
            "logitech-mx-keys-s",
            CatGadgets, BrLogitech, 109.00m, 46,
            new("Logitech MX Keys S", "Logitech MX Keys S", "Logitech MX Keys S"),
            new(
                "Беспроводная клавиатура с умной подсветкой, тихими клавишами и подключением до трёх устройств.",
                "Aqlli yoritish, tinch tugmalar va uchtagacha qurilmaga ulanadigan simsiz klaviatura.",
                "A wireless keyboard with smart backlighting, quiet keys and connection to up to three devices."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1587829741301-dc798b83add3?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1618384887929-16ec33fab9ef?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("layout", new("Раскладка", "Klaviatura tuzilishi", "Layout"), new("Полноразмерная", "To'liq o'lchamli", "Full-size")),
                new("connectivity", new("Связь", "Aloqa", "Connectivity"), new("Bluetooth, Logi Bolt USB", "Bluetooth, Logi Bolt USB", "Bluetooth, Logi Bolt USB")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("До 10 дней с подсветкой", "Yoritish bilan 10 kungacha", "Up to 10 days with backlight")),
                new("backlight", new("Подсветка", "Yoritish", "Backlight"), new("Есть, автоматическая", "Bor, avtomatik", "Yes, automatic")),
                new("color", new("Цвет", "Rang", "Color"), new("Графит", "Grafit", "Graphite")),
            },
            4.7, 168),

        new(
            "sony-wf-1000xm5",
            CatGadgets, BrSony, 299.00m, 37,
            new("Sony WF-1000XM5", "Sony WF-1000XM5", "Sony WF-1000XM5"),
            new(
                "Полностью беспроводные наушники с лучшим в классе шумоподавлением и звуком Hi-Res.",
                "Sinfidagi eng yaxshi shovqin bostirish va Hi-Res ovozga ega to'liq simsiz quloqchinlar.",
                "Fully wireless earbuds with best-in-class noise cancellation and Hi-Res audio."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1590658268037-6bf12165a8df?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1606220588913-b3aacb4d2f46?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("type", new("Тип", "Turi", "Type"), new("Полностью беспроводные", "To'liq simsiz", "True wireless")),
                new("anc", new("Шумоподавление", "Shovqin bostirish", "Noise cancelling"), new("Активное", "Faol", "Active")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("До 24 часов с кейсом", "Keys bilan 24 soatgacha", "Up to 24 hours with case")),
                new("connectivity", new("Связь", "Aloqa", "Connectivity"), new("Bluetooth 5.3, LDAC", "Bluetooth 5.3, LDAC", "Bluetooth 5.3, LDAC")),
                new("waterproof", new("Водозащита", "Suvdan himoya", "Water resistance"), new("IPX4", "IPX4", "IPX4")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный", "Qora", "Black")),
            },
            4.6, 203),

        new(
            "huawei-band-9",
            CatGadgets, BrHuawei, 59.00m, 96,
            new("Huawei Band 9", "Huawei Band 9", "Huawei Band 9"),
            new(
                "Лёгкий фитнес-браслет с AMOLED-экраном, мониторингом сна и автономностью до 14 дней.",
                "AMOLED ekran, uyqu monitoringi va 14 kungacha quvvat bilan ishlaydigan yengil fitnes-bilaguzuk.",
                "A lightweight fitness band with an AMOLED screen, sleep monitoring and up to 14 days of battery life."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1575311373937-040b8e1fd5b6?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1510017803434-a899398421b3?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("screen", new("Экран", "Ekran", "Screen"), new("1.47 дюйма AMOLED", "1.47 dyuym AMOLED", "1.47 inch AMOLED")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("До 14 дней", "14 kungacha", "Up to 14 days")),
                new("connectivity", new("Связь", "Aloqa", "Connectivity"), new("Bluetooth 5.0", "Bluetooth 5.0", "Bluetooth 5.0")),
                new("waterproof", new("Водозащита", "Suvdan himoya", "Water resistance"), new("5 АТМ", "5 ATM", "5 ATM")),
                new("weight", new("Вес", "Vazn", "Weight"), new("14 г", "14 g", "14 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный", "Qora", "Black")),
            },
            4.3, 312),

        // ==================== HEADSETS (Cat 5) ====================
        new(
            "sony-wh-1000xm5",
            CatHeadsets, BrSony, 399.00m, 43,
            new("Sony WH-1000XM5", "Sony WH-1000XM5", "Sony WH-1000XM5"),
            new(
                "Полноразмерные наушники с эталонным шумоподавлением, звуком Hi-Res и автономностью 30 часов.",
                "Namunali shovqin bostirish, Hi-Res ovoz va 30 soatlik quvvatga ega quloqni to'liq qoplaydigan quloqchinlar.",
                "Over-ear headphones with reference-grade noise cancellation, Hi-Res audio and 30 hours of battery life."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1618366712010-f4ae9c647dcb?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1546435770-a3e426bf472b?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1583394838336-acd977736f90?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("type", new("Тип", "Turi", "Type"), new("Полноразмерные", "Quloqni qoplaydigan", "Over-ear")),
                new("anc", new("Шумоподавление", "Shovqin bostirish", "Noise cancelling"), new("Активное", "Faol", "Active")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("До 30 часов", "30 soatgacha", "Up to 30 hours")),
                new("connectivity", new("Связь", "Aloqa", "Connectivity"), new("Bluetooth 5.2, LDAC", "Bluetooth 5.2, LDAC", "Bluetooth 5.2, LDAC")),
                new("weight", new("Вес", "Vazn", "Weight"), new("250 г", "250 g", "250 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный", "Qora", "Black")),
            },
            4.8, 456),

        new(
            "airpods-pro-2-usb-c",
            CatHeadsets, BrApple, 249.00m, 79,
            new("AirPods Pro 2 USB-C", "AirPods Pro 2 USB-C", "AirPods Pro 2 USB-C"),
            new(
                "Наушники с чипом H2, адаптивным звуком, активным шумоподавлением и зарядным кейсом USB-C.",
                "H2 chipi, moslashuvchan ovoz, faol shovqin bostirish va USB-C quvvatlash keysiga ega quloqchinlar.",
                "Earbuds with the H2 chip, adaptive audio, active noise cancellation and a USB-C charging case."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1600294037681-c80b4cb5b434?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1606400082777-ef05f3c5cde2?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("type", new("Тип", "Turi", "Type"), new("Внутриканальные беспроводные", "Kanal ichi simsiz", "In-ear true wireless")),
                new("anc", new("Шумоподавление", "Shovqin bostirish", "Noise cancelling"), new("Активное, адаптивное", "Faol, moslashuvchan", "Active, adaptive")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("До 30 часов с кейсом", "Keys bilan 30 soatgacha", "Up to 30 hours with case")),
                new("connectivity", new("Связь", "Aloqa", "Connectivity"), new("Bluetooth 5.3", "Bluetooth 5.3", "Bluetooth 5.3")),
                new("waterproof", new("Водозащита", "Suvdan himoya", "Water resistance"), new("IP54", "IP54", "IP54")),
                new("color", new("Цвет", "Rang", "Color"), new("Белый", "Oq", "White")),
            },
            4.7, 388),

        new(
            "jbl-tune-770nc",
            CatHeadsets, BrJbl, 129.00m, 0,
            new("JBL Tune 770NC", "JBL Tune 770NC", "JBL Tune 770NC"),
            new(
                "Беспроводные наушники с адаптивным шумоподавлением, фирменным звуком JBL Pure Bass и работой до 70 часов.",
                "Moslashuvchan shovqin bostirish, JBL Pure Bass ovozi va 70 soatgacha ishlaydigan simsiz quloqchinlar.",
                "Wireless headphones with adaptive noise cancelling, signature JBL Pure Bass sound and up to 70 hours of playback."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1484704849700-f032a568e944?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("type", new("Тип", "Turi", "Type"), new("Полноразмерные", "Quloqni qoplaydigan", "Over-ear")),
                new("anc", new("Шумоподавление", "Shovqin bostirish", "Noise cancelling"), new("Активное, адаптивное", "Faol, moslashuvchan", "Active, adaptive")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("До 70 часов", "70 soatgacha", "Up to 70 hours")),
                new("connectivity", new("Связь", "Aloqa", "Connectivity"), new("Bluetooth 5.3", "Bluetooth 5.3", "Bluetooth 5.3")),
                new("weight", new("Вес", "Vazn", "Weight"), new("220 г", "220 g", "220 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Синий", "Ko'k", "Blue")),
            },
            4.3, 174),

        new(
            "samsung-galaxy-buds-2-pro",
            CatHeadsets, BrSamsung, 229.00m, 58,
            new("Samsung Galaxy Buds 2 Pro", "Samsung Galaxy Buds 2 Pro", "Samsung Galaxy Buds 2 Pro"),
            new(
                "Компактные наушники с интеллектуальным шумоподавлением, звуком Hi-Fi 24 бит и защитой IPX7.",
                "Aqlli shovqin bostirish, 24 bit Hi-Fi ovoz va IPX7 himoyaga ega ixcham quloqchinlar.",
                "Compact earbuds with intelligent noise cancelling, 24-bit Hi-Fi audio and IPX7 protection."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1631867675167-90a456a90863?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1590658268037-6bf12165a8df?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("type", new("Тип", "Turi", "Type"), new("Внутриканальные беспроводные", "Kanal ichi simsiz", "In-ear true wireless")),
                new("anc", new("Шумоподавление", "Shovqin bostirish", "Noise cancelling"), new("Активное", "Faol", "Active")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("До 29 часов с кейсом", "Keys bilan 29 soatgacha", "Up to 29 hours with case")),
                new("connectivity", new("Связь", "Aloqa", "Connectivity"), new("Bluetooth 5.3", "Bluetooth 5.3", "Bluetooth 5.3")),
                new("waterproof", new("Водозащита", "Suvdan himoya", "Water resistance"), new("IPX7", "IPX7", "IPX7")),
                new("color", new("Цвет", "Rang", "Color"), new("Графит", "Grafit", "Graphite")),
            },
            4.5, 221),

        new(
            "logitech-g-pro-x-2",
            CatHeadsets, BrLogitech, 249.00m, 24,
            new("Logitech G PRO X 2 Lightspeed", "Logitech G PRO X 2 Lightspeed", "Logitech G PRO X 2 Lightspeed"),
            new(
                "Профессиональная игровая гарнитура с графеновыми драйверами, беспроводным соединением Lightspeed и микрофоном Blue VO!CE.",
                "Grafen drayverlar, Lightspeed simsiz ulanish va Blue VO!CE mikrofoniga ega professional geyming garnitura.",
                "A pro gaming headset with graphene drivers, Lightspeed wireless connectivity and a Blue VO!CE microphone."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1599669454699-248893623440?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1608156639585-b3a032ef9689?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("type", new("Тип", "Turi", "Type"), new("Полноразмерная игровая", "Quloqni qoplaydigan geyming", "Over-ear gaming")),
                new("microphone", new("Микрофон", "Mikrofon", "Microphone"), new("Съёмный, Blue VO!CE", "Olinadigan, Blue VO!CE", "Detachable, Blue VO!CE")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("До 50 часов", "50 soatgacha", "Up to 50 hours")),
                new("connectivity", new("Связь", "Aloqa", "Connectivity"), new("Lightspeed, Bluetooth, 3.5 мм", "Lightspeed, Bluetooth, 3.5 mm", "Lightspeed, Bluetooth, 3.5 mm")),
                new("weight", new("Вес", "Vazn", "Weight"), new("345 г", "345 g", "345 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный", "Qora", "Black")),
            },
            4.6, 98),

        new(
            "jbl-live-670nc",
            CatHeadsets, BrJbl, 149.00m, 61,
            new("JBL Live 670NC", "JBL Live 670NC", "JBL Live 670NC"),
            new(
                "Накладные наушники с адаптивным шумоподавлением, настраиваемым эквалайзером и автономностью до 65 часов.",
                "Moslashuvchan shovqin bostirish, sozlanadigan ekvalayzer va 65 soatgacha quvvatga ega quloq ustiga qo'yiladigan quloqchinlar.",
                "On-ear headphones with adaptive noise cancelling, a customizable equalizer and up to 65 hours of battery life."),
            new List<string>
            {
                "https://images.unsplash.com/photo-1545127398-14699f92334b?w=1200&q=80&auto=format&fit=crop",
                "https://images.unsplash.com/photo-1524678606370-a47ad25cb82a?w=1200&q=80&auto=format&fit=crop",
            },
            new List<AttributeSeed>
            {
                new("type", new("Тип", "Turi", "Type"), new("Накладные", "Quloq ustiga", "On-ear")),
                new("anc", new("Шумоподавление", "Shovqin bostirish", "Noise cancelling"), new("Активное, адаптивное", "Faol, moslashuvchan", "Active, adaptive")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("До 65 часов", "65 soatgacha", "Up to 65 hours")),
                new("connectivity", new("Связь", "Aloqa", "Connectivity"), new("Bluetooth 5.3", "Bluetooth 5.3", "Bluetooth 5.3")),
                new("weight", new("Вес", "Vazn", "Weight"), new("208 г", "208 g", "208 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный", "Qora", "Black")),
            },
            4.2, 87),
    };
}
