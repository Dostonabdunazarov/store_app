namespace Hypex.Infrastructure.Persistence.Seed;

internal static partial class SeedCatalog
{
    private static IEnumerable<ProductSeed> Products2026() => new List<ProductSeed>
    {
        new(
            "macbook-air-13-m4",
            CatLaptops, BrApple, 999.00m, 34,
            new("MacBook Air 13 M4", "MacBook Air 13 M4", "MacBook Air 13 M4"),
            new(
                "Тонкий безвентиляторный ноутбук на чипе Apple M4 с 16 ГБ памяти и новым цветом «Небесно-голубой». Камера Center Stage 12 Мп и поддержка двух внешних дисплеев.",
                "Apple M4 chipli yupqa va ventilyatorsiz noutbuk, 16 GB xotira va yangi Sky Blue rangi bilan. 12 MP Center Stage kamera va ikkita tashqi displeyni qo'llab-quvvatlaydi.",
                "A thin, fanless laptop with the Apple M4 chip, 16 GB of memory and the new Sky Blue finish. It adds a 12 MP Center Stage camera and support for two external displays."),
            new List<string>
            {
                "/products/macbook-air-13-m4/1.webp",
                "/products/macbook-air-13-m4/2.webp",
                "/products/macbook-air-13-m4/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M4, 10-ядерный CPU", "Apple M4, 10 yadroli CPU", "Apple M4, 10-core CPU")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("8-ядерный GPU", "8 yadroli GPU", "8-core GPU")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("16 ГБ", "16 GB", "16 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ SSD", "256 GB SSD", "256 GB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("13.6 дюйма Liquid Retina", "13.6 dyuym Liquid Retina", "13.6 inch Liquid Retina")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 18 ч", "18 soatgacha", "up to 18 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.24 кг", "1.24 kg", "1.24 kg")),
                new("color", new("Цвет", "Rang", "Color"), new("Небесно-голубой, тёмная ночь, сияющая звезда, серебристый", "Osmon ko'k, tungi qora, yulduzli, kumush rang", "Sky Blue, Midnight, Starlight, Silver")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("macOS Sequoia", "macOS Sequoia", "macOS Sequoia")),
            }),

        new(
            "macbook-air-15-m4",
            CatLaptops, BrApple, 1199.00m, 21,
            new("MacBook Air 15 M4", "MacBook Air 15 M4", "MacBook Air 15 M4"),
            new(
                "15.3-дюймовый безвентиляторный ноутбук на чипе Apple M4 с дисплеем Liquid Retina и шестью динамиками. Базовая конфигурация включает 16 ГБ памяти.",
                "Apple M4 chipli 15.3 dyuymli ventilyatorsiz noutbuk, Liquid Retina displey va oltita karnay bilan. Asosiy konfiguratsiyada 16 GB xotira bor.",
                "A 15.3-inch fanless laptop with the Apple M4 chip, a Liquid Retina display and a six-speaker sound system. The base configuration includes 16 GB of memory."),
            new List<string>
            {
                "/products/macbook-air-15-m4/1.webp",
                "/products/macbook-air-15-m4/2.webp",
                "/products/macbook-air-15-m4/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M4, 10-ядерный CPU", "Apple M4, 10 yadroli CPU", "Apple M4, 10-core CPU")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("10-ядерный GPU", "10 yadroli GPU", "10-core GPU")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("16 ГБ", "16 GB", "16 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ SSD", "256 GB SSD", "256 GB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("15.3 дюйма Liquid Retina", "15.3 dyuym Liquid Retina", "15.3 inch Liquid Retina")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 18 ч", "18 soatgacha", "up to 18 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.51 кг", "1.51 kg", "1.51 kg")),
                new("color", new("Цвет", "Rang", "Color"), new("Небесно-голубой, тёмная ночь, сияющая звезда, серебристый", "Osmon ko'k, tungi qora, yulduzli, kumush rang", "Sky Blue, Midnight, Starlight, Silver")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("macOS Sequoia", "macOS Sequoia", "macOS Sequoia")),
            }),

        new(
            "macbook-air-13-m5",
            CatLaptops, BrApple, 1299.00m, 47,
            new("MacBook Air 13 M5", "MacBook Air 13 M5", "MacBook Air 13 M5"),
            new(
                "13-дюймовый MacBook Air на чипе Apple M5 с накопителем 512 ГБ в базе, Wi-Fi 7 и Bluetooth 6 благодаря чипу N1. Остаётся полностью безвентиляторным.",
                "Apple M5 chipli 13 dyuymli MacBook Air, bazaviy xotirasi 512 GB, N1 chipi tufayli Wi-Fi 7 va Bluetooth 6 bilan. Butunlay ventilyatorsiz qoladi.",
                "The 13-inch MacBook Air with the Apple M5 chip, 512 GB of base storage, and Wi-Fi 7 and Bluetooth 6 via the N1 chip. It remains completely fanless."),
            new List<string>
            {
                "/products/macbook-air-13-m5/1.webp",
                "/products/macbook-air-13-m5/2.webp",
                "/products/macbook-air-13-m5/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M5, 10-ядерный CPU", "Apple M5, 10 yadroli CPU", "Apple M5, 10-core CPU")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("8-ядерный GPU с Neural Accelerators", "Neural Accelerators bilan 8 yadroli GPU", "8-core GPU with Neural Accelerators")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("16 ГБ", "16 GB", "16 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("512 ГБ SSD", "512 GB SSD", "512 GB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("13.6 дюйма Liquid Retina", "13.6 dyuym Liquid Retina", "13.6 inch Liquid Retina")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 18 ч", "18 soatgacha", "up to 18 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.23 кг", "1.23 kg", "1.23 kg")),
                new("color", new("Цвет", "Rang", "Color"), new("Небесно-голубой, тёмная ночь, сияющая звезда, серебристый", "Osmon ko'k, tungi qora, yulduzli, kumush rang", "Sky Blue, Midnight, Starlight, Silver")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("macOS Tahoe", "macOS Tahoe", "macOS Tahoe")),
            }),

        new(
            "macbook-air-15-m5",
            CatLaptops, BrApple, 1499.00m, 15,
            new("MacBook Air 15 M5", "MacBook Air 15 M5", "MacBook Air 15 M5"),
            new(
                "15.3-дюймовый MacBook Air на чипе Apple M5 с 10-ядерным GPU и накопителем 512 ГБ в алюминиевом безвентиляторном корпусе. Чип N1 добавляет Wi-Fi 7 и Bluetooth 6.",
                "Apple M5 chipli 15.3 dyuymli MacBook Air, 10 yadroli GPU va 512 GB xotira, alyuminiy ventilyatorsiz korpusda. N1 chipi Wi-Fi 7 va Bluetooth 6 ni qo'shadi.",
                "The 15.3-inch MacBook Air with the Apple M5 chip, a 10-core GPU and 512 GB of storage in a fanless aluminum design. The N1 chip brings Wi-Fi 7 and Bluetooth 6."),
            new List<string>
            {
                "/products/macbook-air-15-m5/1.webp",
                "/products/macbook-air-15-m5/2.webp",
                "/products/macbook-air-15-m5/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M5, 10-ядерный CPU", "Apple M5, 10 yadroli CPU", "Apple M5, 10-core CPU")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("10-ядерный GPU с Neural Accelerators", "Neural Accelerators bilan 10 yadroli GPU", "10-core GPU with Neural Accelerators")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("16 ГБ", "16 GB", "16 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("512 ГБ SSD", "512 GB SSD", "512 GB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("15.3 дюйма Liquid Retina", "15.3 dyuym Liquid Retina", "15.3 inch Liquid Retina")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 18 ч", "18 soatgacha", "up to 18 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.51 кг", "1.51 kg", "1.51 kg")),
                new("color", new("Цвет", "Rang", "Color"), new("Небесно-голубой, тёмная ночь, сияющая звезда, серебристый", "Osmon ko'k, tungi qora, yulduzli, kumush rang", "Sky Blue, Midnight, Starlight, Silver")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("macOS Tahoe", "macOS Tahoe", "macOS Tahoe")),
            }),

        new(
            "macbook-pro-14-m4",
            CatLaptops, BrApple, 1599.00m, 28,
            new("MacBook Pro 14 M4", "MacBook Pro 14 M4", "MacBook Pro 14 M4"),
            new(
                "14-дюймовый MacBook Pro на чипе Apple M4 с 16 ГБ памяти, тремя портами Thunderbolt 4 и цветом «Чёрный космос» в базе. Дисплей Liquid Retina XDR достигает 1600 нит в HDR.",
                "Apple M4 chipli 14 dyuymli MacBook Pro, 16 GB xotira, uchta Thunderbolt 4 porti va bazada Space Black rangi bilan. Liquid Retina XDR displey HDR da 1600 nitgacha yetadi.",
                "A 14-inch MacBook Pro with the Apple M4 chip, 16 GB of memory, three Thunderbolt 4 ports and a Space Black option in the base model. The Liquid Retina XDR display reaches 1600 nits peak HDR."),
            new List<string>
            {
                "/products/macbook-pro-14-m4/1.webp",
                "/products/macbook-pro-14-m4/2.webp",
                "/products/macbook-pro-14-m4/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M4, 10-ядерный CPU", "Apple M4, 10 yadroli CPU", "Apple M4, 10-core CPU")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("10-ядерный GPU", "10 yadroli GPU", "10-core GPU")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("16 ГБ", "16 GB", "16 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("512 ГБ SSD", "512 GB SSD", "512 GB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("14.2 дюйма Liquid Retina XDR, 120 Гц", "14.2 dyuym Liquid Retina XDR, 120 Hz", "14.2 inch Liquid Retina XDR, 120 Hz")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 24 ч", "24 soatgacha", "up to 24 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.55 кг", "1.55 kg", "1.55 kg")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный космос, серебристый", "Kosmik qora, kumush rang", "Space Black, Silver")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("macOS Sequoia", "macOS Sequoia", "macOS Sequoia")),
            }),

        new(
            "macbook-pro-14-m4-pro",
            CatLaptops, BrApple, 1999.00m, 52,
            new("MacBook Pro 14 M4 Pro", "MacBook Pro 14 M4 Pro", "MacBook Pro 14 M4 Pro"),
            new(
                "14-дюймовый MacBook Pro на чипе M4 Pro с портами Thunderbolt 5 и мощным GPU для творческих и разработческих задач. Базовые 24 ГБ памяти и до 22 часов работы.",
                "M4 Pro chipli 14 dyuymli MacBook Pro, Thunderbolt 5 portlari va ijodiy hamda dasturlash vazifalari uchun kuchli GPU bilan. Bazada 24 GB xotira va 22 soatgacha ishlaydi.",
                "A 14-inch MacBook Pro with the M4 Pro chip, Thunderbolt 5 ports and a powerful GPU for demanding creative and development work. It starts with 24 GB of memory and up to 22 hours of battery life."),
            new List<string>
            {
                "/products/macbook-pro-14-m4-pro/1.webp",
                "/products/macbook-pro-14-m4-pro/2.webp",
                "/products/macbook-pro-14-m4-pro/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M4 Pro, 12-ядерный CPU", "Apple M4 Pro, 12 yadroli CPU", "Apple M4 Pro, 12-core CPU")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("16-ядерный GPU", "16 yadroli GPU", "16-core GPU")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("24 ГБ", "24 GB", "24 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("512 ГБ SSD", "512 GB SSD", "512 GB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("14.2 дюйма Liquid Retina XDR, 120 Гц", "14.2 dyuym Liquid Retina XDR, 120 Hz", "14.2 inch Liquid Retina XDR, 120 Hz")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 22 ч", "22 soatgacha", "up to 22 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.60 кг", "1.60 kg", "1.60 kg")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный космос, серебристый", "Kosmik qora, kumush rang", "Space Black, Silver")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("macOS Sequoia", "macOS Sequoia", "macOS Sequoia")),
            }),

        new(
            "macbook-pro-16-m4-max",
            CatLaptops, BrApple, 3499.00m, 12,
            new("MacBook Pro 16 M4 Max", "MacBook Pro 16 M4 Max", "MacBook Pro 16 M4 Max"),
            new(
                "16-дюймовый MacBook Pro на чипе M4 Max для 3D-рендеринга, видео и локальных ИИ-моделей, до 128 ГБ памяти. Дисплей Liquid Retina XDR 16.2 дюйма и Thunderbolt 5.",
                "M4 Max chipli 16 dyuymli MacBook Pro, 3D-renderlash, video va mahalliy AI modellari uchun, 128 GB gacha xotira bilan. 16.2 dyuymli Liquid Retina XDR displey va Thunderbolt 5.",
                "A 16-inch MacBook Pro with the M4 Max chip for 3D rendering, video and local AI models, with up to 128 GB of unified memory. It has a 16.2-inch Liquid Retina XDR display and Thunderbolt 5."),
            new List<string>
            {
                "/products/macbook-pro-16-m4-max/1.webp",
                "/products/macbook-pro-16-m4-max/2.webp",
                "/products/macbook-pro-16-m4-max/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M4 Max, 14-ядерный CPU", "Apple M4 Max, 14 yadroli CPU", "Apple M4 Max, 14-core CPU")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("32-ядерный GPU", "32 yadroli GPU", "32-core GPU")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("36 ГБ", "36 GB", "36 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("1 ТБ SSD", "1 TB SSD", "1 TB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("16.2 дюйма Liquid Retina XDR, 120 Гц", "16.2 dyuym Liquid Retina XDR, 120 Hz", "16.2 inch Liquid Retina XDR, 120 Hz")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 21 ч", "21 soatgacha", "up to 21 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("2.15 кг", "2.15 kg", "2.15 kg")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный космос, серебристый", "Kosmik qora, kumush rang", "Space Black, Silver")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("macOS Sequoia", "macOS Sequoia", "macOS Sequoia")),
            }),

        new(
            "macbook-pro-14-m5",
            CatLaptops, BrApple, 1599.00m, 39,
            new("MacBook Pro 14 M5", "MacBook Pro 14 M5", "MacBook Pro 14 M5"),
            new(
                "14-дюймовый MacBook Pro на чипе M5 с Neural Accelerator в каждом ядре GPU и до 3.5 раз большей производительностью ИИ, чем у M4. Сохраняет до 24 часов работы и дисплей Liquid Retina XDR.",
                "M5 chipli 14 dyuymli MacBook Pro, GPU ning har bir yadrosida Neural Accelerator bor, AI unumdorligi M4 ga nisbatan 3.5 barobargacha yuqori. 24 soatgacha ishlaydi va Liquid Retina XDR displeyi saqlanadi.",
                "A 14-inch MacBook Pro with the M5 chip, a Neural Accelerator in every GPU core and up to 3.5x the AI performance of the M4 model. It keeps up to 24 hours of battery life and the Liquid Retina XDR display."),
            new List<string>
            {
                "/products/macbook-pro-14-m5/1.webp",
                "/products/macbook-pro-14-m5/2.webp",
                "/products/macbook-pro-14-m5/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M5, 10-ядерный CPU", "Apple M5, 10 yadroli CPU", "Apple M5, 10-core CPU")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("10-ядерный GPU с Neural Accelerators", "Neural Accelerators bilan 10 yadroli GPU", "10-core GPU with Neural Accelerators")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("16 ГБ", "16 GB", "16 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("512 ГБ SSD", "512 GB SSD", "512 GB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("14.2 дюйма Liquid Retina XDR, 120 Гц", "14.2 dyuym Liquid Retina XDR, 120 Hz", "14.2 inch Liquid Retina XDR, 120 Hz")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 24 ч", "24 soatgacha", "up to 24 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.55 кг", "1.55 kg", "1.55 kg")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный космос, серебристый", "Kosmik qora, kumush rang", "Space Black, Silver")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("macOS Tahoe", "macOS Tahoe", "macOS Tahoe")),
            }),

        new(
            "macbook-pro-14-m5-pro",
            CatLaptops, BrApple, 2499.00m, 24,
            new("MacBook Pro 14 M5 Pro", "MacBook Pro 14 M5 Pro", "MacBook Pro 14 M5 Pro"),
            new(
                "14-дюймовый MacBook Pro на чипе M5 Pro с архитектурой Fusion, Thunderbolt 5 и накопителем 1 ТБ в базе. Для разработчиков и авторов, которым нужна профессиональная мощность в компактном корпусе.",
                "M5 Pro chipli 14 dyuymli MacBook Pro, Fusion arxitekturasi, Thunderbolt 5 va bazada 1 TB xotira bilan. Ixcham korpusda professional quvvat kerak bo'lgan dasturchilar va ijodkorlar uchun.",
                "A 14-inch MacBook Pro with the M5 Pro chip, Fusion Architecture, Thunderbolt 5 and 1 TB of storage as standard. Aimed at developers and creators who need pro performance in a portable size."),
            new List<string>
            {
                "/products/macbook-pro-14-m5-pro/1.webp",
                "/products/macbook-pro-14-m5-pro/2.webp",
                "/products/macbook-pro-14-m5-pro/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M5 Pro, 15-ядерный CPU", "Apple M5 Pro, 15 yadroli CPU", "Apple M5 Pro, 15-core CPU")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("16-ядерный GPU с Neural Accelerators", "Neural Accelerators bilan 16 yadroli GPU", "16-core GPU with Neural Accelerators")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("24 ГБ", "24 GB", "24 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("1 ТБ SSD", "1 TB SSD", "1 TB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("14.2 дюйма Liquid Retina XDR, 120 Гц", "14.2 dyuym Liquid Retina XDR, 120 Hz", "14.2 inch Liquid Retina XDR, 120 Hz")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 22 ч", "22 soatgacha", "up to 22 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.60 кг", "1.60 kg", "1.60 kg")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный космос, серебристый", "Kosmik qora, kumush rang", "Space Black, Silver")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("macOS Tahoe", "macOS Tahoe", "macOS Tahoe")),
            }),

        new(
            "macbook-pro-16-m5-max",
            CatLaptops, BrApple, 4399.00m, 58,
            new("MacBook Pro 16 M5 Max", "MacBook Pro 16 M5 Max", "MacBook Pro 16 M5 Max"),
            new(
                "Самый мощный несенсорный MacBook Pro Apple: чип M5 Max с 18-ядерным CPU, до 40-ядерного GPU и до 128 ГБ памяти. Накопитель 2 ТБ и дисплей Liquid Retina XDR 16.2 дюйма.",
                "Apple ning eng kuchli sensorsiz MacBook Pro si: 18 yadroli CPU, 40 yadrogacha GPU va 128 GB gacha xotirali M5 Max chipi. 2 TB xotira va 16.2 dyuymli Liquid Retina XDR displey.",
                "Apple's most powerful non-touch MacBook Pro, with the M5 Max chip, an 18-core CPU, up to a 40-core GPU and up to 128 GB of unified memory. It ships with 2 TB of storage and a 16.2-inch Liquid Retina XDR display."),
            new List<string>
            {
                "/products/macbook-pro-16-m5-max/1.webp",
                "/products/macbook-pro-16-m5-max/2.webp",
                "/products/macbook-pro-16-m5-max/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M5 Max, 18-ядерный CPU", "Apple M5 Max, 18 yadroli CPU", "Apple M5 Max, 18-core CPU")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("32-ядерный GPU с Neural Accelerators", "Neural Accelerators bilan 32 yadroli GPU", "32-core GPU with Neural Accelerators")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("36 ГБ", "36 GB", "36 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("2 ТБ SSD", "2 TB SSD", "2 TB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("16.2 дюйма Liquid Retina XDR, 120 Гц", "16.2 dyuym Liquid Retina XDR, 120 Hz", "16.2 inch Liquid Retina XDR, 120 Hz")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 22 ч", "22 soatgacha", "up to 22 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("2.15 кг", "2.15 kg", "2.15 kg")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный космос, серебристый", "Kosmik qora, kumush rang", "Space Black, Silver")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("macOS Tahoe", "macOS Tahoe", "macOS Tahoe")),
            }),

        new(
            "macbook-pro-14-m6",
            CatLaptops, BrApple, 1999.00m, 18,
            new("MacBook Pro 14 M6", "MacBook Pro 14 M6", "MacBook Pro 14 M6"),
            new(
                "Новый базовый 14-дюймовый MacBook Pro на чипе M6 с 12-ядерными CPU и GPU и накопителем 1 ТБ в базе. Дисплей Liquid Retina XDR и до 24 часов работы.",
                "M6 chipli yangi bazaviy 14 dyuymli MacBook Pro, 12 yadroli CPU va GPU hamda bazada 1 TB xotira bilan. Liquid Retina XDR displey va 24 soatgacha ishlaydi.",
                "The new entry 14-inch MacBook Pro with the M6 chip, a 12-core CPU, 12-core GPU and 1 TB of storage as standard. It keeps the Liquid Retina XDR display and delivers up to 24 hours of battery life."),
            new List<string>
            {
                "/products/macbook-pro-14-m6/1.webp",
                "/products/macbook-pro-14-m6/2.webp",
                "/products/macbook-pro-14-m6/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M6, 12-ядерный CPU", "Apple M6, 12 yadroli CPU", "Apple M6, 12-core CPU")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("12-ядерный GPU", "12 yadroli GPU", "12-core GPU")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("16 ГБ", "16 GB", "16 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("1 ТБ SSD", "1 TB SSD", "1 TB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("14.2 дюйма Liquid Retina XDR, 120 Гц", "14.2 dyuym Liquid Retina XDR, 120 Hz", "14.2 inch Liquid Retina XDR, 120 Hz")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 24 ч", "24 soatgacha", "up to 24 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.55 кг", "1.55 kg", "1.55 kg")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный космос, серебристый", "Kosmik qora, kumush rang", "Space Black, Silver")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("macOS 27", "macOS 27", "macOS 27")),
            }),

        new(
            "macbook-pro-14-proled-m5-pro",
            CatLaptops, BrApple, 2899.00m, 43,
            new("MacBook Pro 14 PROLED XDR M5 Pro", "MacBook Pro 14 PROLED XDR M5 Pro", "MacBook Pro 14 PROLED XDR M5 Pro"),
            new(
                "Первый сенсорный Mac от Apple: 14-дюймовый тандемный OLED-дисплей PROLED XDR с яркостью до 2000 нит и Dynamic Island. Тоньше и легче, вес всего 1.36 кг.",
                "Apple ning birinchi sensorli Mac i: 2000 nitgacha yorqinlikdagi 14 dyuymli tandem OLED PROLED XDR displey va Dynamic Island. Yupqaroq va yengilroq, vazni atigi 1.36 kg.",
                "Apple's first touchscreen Mac, with a 14-inch tandem OLED PROLED XDR display up to 2000 nits and a Dynamic Island. It is thinner and lighter at just 1.36 kg."),
            new List<string>
            {
                "/products/macbook-pro-14-proled-m5-pro/1.webp",
                "/products/macbook-pro-14-proled-m5-pro/2.webp",
                "/products/macbook-pro-14-proled-m5-pro/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M5 Pro, 15-ядерный CPU", "Apple M5 Pro, 15 yadroli CPU", "Apple M5 Pro, 15-core CPU")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("16-ядерный GPU с Neural Accelerators", "Neural Accelerators bilan 16 yadroli GPU", "16-core GPU with Neural Accelerators")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("24 ГБ", "24 GB", "24 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("1 ТБ SSD", "1 TB SSD", "1 TB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("14.2 дюйма PROLED XDR OLED, сенсорный, 120 Гц", "14.2 dyuym PROLED XDR OLED, sensorli, 120 Hz", "14.2 inch PROLED XDR OLED, touchscreen, 120 Hz")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 24 ч", "24 soatgacha", "up to 24 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.36 кг", "1.36 kg", "1.36 kg")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный космос, серебристый", "Kosmik qora, kumush rang", "Space Black, Silver")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("macOS 27", "macOS 27", "macOS 27")),
            }),

        new(
            "macbook-pro-16-proled-m5-max",
            CatLaptops, BrApple, 4799.00m, 9,
            new("MacBook Pro 16 PROLED XDR M5 Max", "MacBook Pro 16 PROLED XDR M5 Max", "MacBook Pro 16 PROLED XDR M5 Max"),
            new(
                "16.3-дюймовый тандемный OLED-сенсорный дисплей PROLED XDR в сочетании с чипом M5 Max и до 128 ГБ памяти. Весит 1.81 кг и поддерживает до четырёх внешних дисплеев.",
                "16.3 dyuymli tandem OLED sensorli PROLED XDR displey M5 Max chipi va 128 GB gacha xotira bilan birga. Vazni 1.81 kg, to'rttagacha tashqi displeyni qo'llab-quvvatlaydi.",
                "A 16.3-inch tandem OLED PROLED XDR touchscreen combined with the M5 Max chip and up to 128 GB of unified memory. It weighs 1.81 kg and supports up to four external displays."),
            new List<string>
            {
                "/products/macbook-pro-16-proled-m5-max/1.webp",
                "/products/macbook-pro-16-proled-m5-max/2.webp",
                "/products/macbook-pro-16-proled-m5-max/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple M5 Max, 18-ядерный CPU", "Apple M5 Max, 18 yadroli CPU", "Apple M5 Max, 18-core CPU")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("32-ядерный GPU с Neural Accelerators", "Neural Accelerators bilan 32 yadroli GPU", "32-core GPU with Neural Accelerators")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("36 ГБ", "36 GB", "36 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("2 ТБ SSD", "2 TB SSD", "2 TB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("16.3 дюйма PROLED XDR OLED, сенсорный, 120 Гц", "16.3 dyuym PROLED XDR OLED, sensorli, 120 Hz", "16.3 inch PROLED XDR OLED, touchscreen, 120 Hz")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 24 ч", "24 soatgacha", "up to 24 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.81 кг", "1.81 kg", "1.81 kg")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный космос, серебристый", "Kosmik qora, kumush rang", "Space Black, Silver")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("macOS 27", "macOS 27", "macOS 27")),
            }),

        new(
            "macbook-neo",
            CatLaptops, BrApple, 699.00m, 31,
            new("MacBook Neo", "MacBook Neo", "MacBook Neo"),
            new(
                "Самый доступный ноутбук Apple на чипе A18 Pro в безвентиляторном алюминиевом корпусе с 13-дюймовым дисплеем Liquid Retina. Четыре цвета и до 16 часов работы.",
                "A18 Pro chipli Apple ning eng arzon noutbuki, ventilyatorsiz alyuminiy korpus va 13 dyuymli Liquid Retina displey bilan. To'rt xil rang va 16 soatgacha ishlaydi.",
                "Apple's most affordable laptop, powered by the A18 Pro chip in a fanless aluminum design with a 13-inch Liquid Retina display. It comes in four colors and offers up to 16 hours of battery life."),
            new List<string>
            {
                "/products/macbook-neo/1.webp",
                "/products/macbook-neo/2.webp",
                "/products/macbook-neo/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A18 Pro, 6-ядерный CPU", "Apple A18 Pro, 6 yadroli CPU", "Apple A18 Pro, 6-core CPU")),
                new("gpu", new("Графика", "Grafika", "GPU"), new("5-ядерный GPU", "5 yadroli GPU", "5-core GPU")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ SSD", "256 GB SSD", "256 GB SSD")),
                new("screen", new("Экран", "Ekran", "Screen"), new("13 дюймов Liquid Retina", "13 dyuym Liquid Retina", "13 inch Liquid Retina")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 16 ч", "16 soatgacha", "up to 16 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("1.23 кг", "1.23 kg", "1.23 kg")),
                new("color", new("Цвет", "Rang", "Color"), new("Нежно-розовый, индиго, серебристый, цитрусовый", "Nozik pushti, indigo, kumush rang, tsitrus", "Blush, Indigo, Silver, Citrus")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("macOS Tahoe", "macOS Tahoe", "macOS Tahoe")),
            }),

        new(
            "galaxy-s26-ultra",
            CatPhones, BrSamsung, 1299.99m, 26,
            new("Samsung Galaxy S26 Ultra", "Samsung Galaxy S26 Ultra", "Samsung Galaxy S26 Ultra"),
            new(
                "Флагман Samsung 2026 года с 6.9-дюймовым дисплеем Dynamic AMOLED 2X 120 Гц, Snapdragon 8 Elite Gen 5 for Galaxy и встроенным S Pen. Четверная камера с основным сенсором 200 Мп и телеобъективами 3x и 5x.",
                "Samsung ning 2026-yilgi flagmani: 6.9 dyuymli Dynamic AMOLED 2X 120 Hz displey, Snapdragon 8 Elite Gen 5 for Galaxy va o'rnatilgan S Pen. 200 MP asosiy sensorli va 3x hamda 5x teleob'ektivli to'rtlik kamera.",
                "Samsung's 2026 flagship with a 6.9-inch 120 Hz Dynamic AMOLED 2X display, Snapdragon 8 Elite Gen 5 for Galaxy and a built-in S Pen. Its quad camera is led by a 200 MP main sensor with 3x and 5x telephotos."),
            new List<string>
            {
                "/products/galaxy-s26-ultra/1.webp",
                "/products/galaxy-s26-ultra/2.webp",
                "/products/galaxy-s26-ultra/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 8 Elite Gen 5 for Galaxy", "Snapdragon 8 Elite Gen 5 for Galaxy", "Snapdragon 8 Elite Gen 5 for Galaxy")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.9 дюйма Dynamic AMOLED 2X, 120 Гц", "6.9 dyuym Dynamic AMOLED 2X, 120 Hz", "6.9 inch Dynamic AMOLED 2X, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("200 Мп + 50 Мп + 10 Мп (3x) + 50 Мп (5x)", "200 MP + 50 MP + 10 MP (3x) + 50 MP (5x)", "200 MP + 50 MP + 10 MP (3x) + 50 MP (5x)")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("5000 мА·ч", "5000 mA·soat", "5000 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("214 г", "214 g", "214 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Кобальтовый фиолетовый, небесно-голубой, чёрный, белый, серебристая тень, розовое золото", "Kobalt binafsha, osmon ko'k, qora, oq, kumush soya, pushti oltin", "Cobalt Violet, Sky Blue, Black, White, Silver Shadow, Pink Gold")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Android 16, обновление до Android 17 (One UI 9)", "Android 16, Android 17 (One UI 9) ga yangilanadi", "Android 16, upgradable to Android 17 (One UI 9)")),
            }),

        new(
            "galaxy-s26-plus",
            CatPhones, BrSamsung, 1099.99m, 55,
            new("Samsung Galaxy S26+", "Samsung Galaxy S26+", "Samsung Galaxy S26+"),
            new(
                "Крупная 6.7-дюймовая модель линейки Galaxy S26 с дисплеем Dynamic AMOLED 2X 120 Гц и аккумулятором 4900 мА·ч. Тройная камера 50 Мп с телеобъективом 3x.",
                "Galaxy S26 qatorining 6.7 dyuymli katta modeli: Dynamic AMOLED 2X 120 Hz displey va 4900 mA·soat batareya. 3x teleob'ektivli 50 MP uchlik kamera.",
                "The larger 6.7-inch model of the Galaxy S26 line with a 120 Hz Dynamic AMOLED 2X display and a 4900 mAh battery. It has a 50 MP triple camera with a 3x telephoto."),
            new List<string>
            {
                "/products/galaxy-s26-plus/1.webp",
                "/products/galaxy-s26-plus/2.webp",
                "/products/galaxy-s26-plus/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 8 Elite Gen 5 for Galaxy (США, Канада, Китай), Exynos 2600 в других регионах", "Snapdragon 8 Elite Gen 5 for Galaxy (AQSH, Kanada, Xitoy), boshqa mintaqalarda Exynos 2600", "Snapdragon 8 Elite Gen 5 for Galaxy (US/Canada/China), Exynos 2600 elsewhere")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.7 дюйма Dynamic AMOLED 2X, 120 Гц", "6.7 dyuym Dynamic AMOLED 2X, 120 Hz", "6.7 inch Dynamic AMOLED 2X, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("50 Мп + 12 Мп + 10 Мп (3x)", "50 MP + 12 MP + 10 MP (3x)", "50 MP + 12 MP + 10 MP (3x)")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("4900 мА·ч", "4900 mA·soat", "4900 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("190 г", "190 g", "190 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Кобальтовый фиолетовый, небесно-голубой, чёрный, белый, серебристая тень, розовое золото", "Kobalt binafsha, osmon ko'k, qora, oq, kumush soya, pushti oltin", "Cobalt Violet, Sky Blue, Black, White, Silver Shadow, Pink Gold")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Android 16, обновление до Android 17 (One UI 9)", "Android 16, Android 17 (One UI 9) ga yangilanadi", "Android 16, upgradable to Android 17 (One UI 9)")),
            }),

        new(
            "galaxy-s26",
            CatPhones, BrSamsung, 899.99m, 14,
            new("Samsung Galaxy S26", "Samsung Galaxy S26", "Samsung Galaxy S26"),
            new(
                "Компактная 6.3-дюймовая модель линейки Galaxy S26 с дисплеем Dynamic AMOLED 2X 120 Гц и 12 ГБ оперативной памяти. Тройная камера 50 Мп с телеобъективом 3x.",
                "Galaxy S26 qatorining ixcham 6.3 dyuymli modeli: Dynamic AMOLED 2X 120 Hz displey va 12 GB operativ xotira. 3x teleob'ektivli 50 MP uchlik kamera.",
                "The compact 6.3-inch model of the Galaxy S26 line with a 120 Hz Dynamic AMOLED 2X display and 12 GB of RAM. It has a 50 MP triple camera with a 3x telephoto."),
            new List<string>
            {
                "/products/galaxy-s26/1.webp",
                "/products/galaxy-s26/2.webp",
                "/products/galaxy-s26/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 8 Elite Gen 5 for Galaxy (США, Канада, Китай), Exynos 2600 в других регионах", "Snapdragon 8 Elite Gen 5 for Galaxy (AQSH, Kanada, Xitoy), boshqa mintaqalarda Exynos 2600", "Snapdragon 8 Elite Gen 5 for Galaxy (US/Canada/China), Exynos 2600 elsewhere")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.3 дюйма Dynamic AMOLED 2X, 120 Гц", "6.3 dyuym Dynamic AMOLED 2X, 120 Hz", "6.3 inch Dynamic AMOLED 2X, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("50 Мп + 12 Мп + 10 Мп (3x)", "50 MP + 12 MP + 10 MP (3x)", "50 MP + 12 MP + 10 MP (3x)")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("4300 мА·ч", "4300 mA·soat", "4300 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("167 г", "167 g", "167 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Кобальтовый фиолетовый, небесно-голубой, чёрный, белый, серебристая тень, розовое золото", "Kobalt binafsha, osmon ko'k, qora, oq, kumush soya, pushti oltin", "Cobalt Violet, Sky Blue, Black, White, Silver Shadow, Pink Gold")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Android 16, обновление до Android 17 (One UI 9)", "Android 16, Android 17 (One UI 9) ga yangilanadi", "Android 16, upgradable to Android 17 (One UI 9)")),
            }),

        new(
            "galaxy-z-fold8",
            CatPhones, BrSamsung, 1899.99m, 37,
            new("Samsung Galaxy Z Fold8", "Samsung Galaxy Z Fold8", "Samsung Galaxy Z Fold8"),
            new(
                "Складной смартфон-книжка Samsung 2026 года с широким форматом и внутренним дисплеем 7.6 дюйма 4:3. Работает на Android 17, весит 201 г и защищён по стандарту IP48.",
                "Samsung ning 2026-yilgi kitob shaklidagi buklanuvchi smartfoni, keng format va 7.6 dyuymli 4:3 ichki displey bilan. Android 17 da ishlaydi, vazni 201 g va IP48 himoyasiga ega.",
                "Samsung's 2026 book-style foldable with a wider form factor and a 7.6-inch 4:3 inner display. It runs Android 17 out of the box, weighs 201 g and is IP48 rated."),
            new List<string>
            {
                "/products/galaxy-z-fold8/1.webp",
                "/products/galaxy-z-fold8/2.webp",
                "/products/galaxy-z-fold8/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 8 Elite Gen 5 for Galaxy", "Snapdragon 8 Elite Gen 5 for Galaxy", "Snapdragon 8 Elite Gen 5 for Galaxy")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("7.6 дюйма Dynamic AMOLED 2X складной, 120 Гц + внешний дисплей", "7.6 dyuym Dynamic AMOLED 2X buklanuvchi, 120 Hz + tashqi displey", "7.6 inch foldable Dynamic AMOLED 2X, 120 Hz + cover display")),
                new("camera", new("Камера", "Kamera", "Camera"), new("50 Мп + 50 Мп", "50 MP + 50 MP", "50 MP + 50 MP")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("4800 мА·ч", "4800 mA·soat", "4800 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("201 г", "201 g", "201 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Лавандовый, графит, кремовый, фисташковый", "Lavanda, grafit, krem, pista", "Lavender, Graphite, Cream, Pistachio")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Android 17 (One UI 9)", "Android 17 (One UI 9)", "Android 17 (One UI 9)")),
            }),

        new(
            "galaxy-z-flip8",
            CatPhones, BrSamsung, 1199.99m, 22,
            new("Samsung Galaxy Z Flip8", "Samsung Galaxy Z Flip8", "Samsung Galaxy Z Flip8"),
            new(
                "Складной смартфон-раскладушка Samsung 2026 года с внутренним дисплеем 6.9 дюйма 120 Гц и внешним экраном. Работает на Android 17 и защищён по стандарту IP48.",
                "Samsung ning 2026-yilgi ochiladigan buklanuvchi smartfoni, 6.9 dyuymli 120 Hz ichki displey va tashqi ekran bilan. Android 17 da ishlaydi va IP48 himoyasiga ega.",
                "Samsung's 2026 clamshell foldable with a 6.9-inch 120 Hz inner display and an outer cover screen. It runs Android 17 and is IP48 rated."),
            new List<string>
            {
                "/products/galaxy-z-flip8/1.webp",
                "/products/galaxy-z-flip8/2.webp",
                "/products/galaxy-z-flip8/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 8 Elite Gen 5 for Galaxy (США, Канада, Китай), Exynos 2600 в других регионах", "Snapdragon 8 Elite Gen 5 for Galaxy (AQSH, Kanada, Xitoy), boshqa mintaqalarda Exynos 2600", "Snapdragon 8 Elite Gen 5 for Galaxy (US/Canada/China), Exynos 2600 elsewhere")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.9 дюйма Dynamic AMOLED 2X складной, 120 Гц + внешний дисплей", "6.9 dyuym Dynamic AMOLED 2X buklanuvchi, 120 Hz + tashqi displey", "6.9 inch foldable Dynamic AMOLED 2X, 120 Hz + cover display")),
                new("camera", new("Камера", "Kamera", "Camera"), new("50 Мп + 12 Мп", "50 MP + 12 MP", "50 MP + 12 MP")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("4300 мА·ч", "4300 mA·soat", "4300 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("180 г", "180 g", "180 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Мятный, графит, кремовый, розовый", "Yalpiz, grafit, krem, pushti", "Mint, Graphite, Cream, Pink")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Android 17 (One UI 9)", "Android 17 (One UI 9)", "Android 17 (One UI 9)")),
            }),

        new(
            "galaxy-a57",
            CatPhones, BrSamsung, 549.99m, 49,
            new("Samsung Galaxy A57 5G", "Samsung Galaxy A57 5G", "Samsung Galaxy A57 5G"),
            new(
                "Смартфон верхнего среднего класса Samsung 2026 года с дисплеем Super AMOLED+ 6.7 дюйма 120 Гц и чипом Exynos 1680. Толщина всего 6.9 мм, вес 179 г.",
                "Samsung ning 2026-yilgi yuqori o'rta sinf smartfoni, 6.7 dyuymli Super AMOLED+ 120 Hz displey va Exynos 1680 chipi bilan. Qalinligi atigi 6.9 mm, vazni 179 g.",
                "Samsung's 2026 upper mid-range Galaxy A phone with a 6.7-inch 120 Hz Super AMOLED+ display and the Exynos 1680 chip. It is 6.9 mm thin and weighs 179 g."),
            new List<string>
            {
                "/products/galaxy-a57/1.webp",
                "/products/galaxy-a57/2.webp",
                "/products/galaxy-a57/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Samsung Exynos 1680", "Samsung Exynos 1680", "Samsung Exynos 1680")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("128 ГБ", "128 GB", "128 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.7 дюйма Super AMOLED+, 120 Гц", "6.7 dyuym Super AMOLED+, 120 Hz", "6.7 inch Super AMOLED+, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("50 Мп (OIS) + 12 Мп + 5 Мп", "50 MP (OIS) + 12 MP + 5 MP", "50 MP (OIS) + 12 MP + 5 MP")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("5000 мА·ч", "5000 mA·soat", "5000 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("179 г", "179 g", "179 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Тёмно-синий, серый, ледяной голубой, сиреневый", "To'q ko'k, kulrang, muzdek ko'k, siren", "Awesome Navy, Awesome Gray, Awesome Icyblue, Awesome Lilac")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Android 16 (One UI 8.5)", "Android 16 (One UI 8.5)", "Android 16 (One UI 8.5)")),
            }),

        new(
            "pixel-11-pro",
            CatPhones, BrGoogle, 1099.00m, 11,
            new("Google Pixel 11 Pro", "Google Pixel 11 Pro", "Google Pixel 11 Pro"),
            new(
                "6.3-дюймовый Pro-смартфон Google 2026 года на чипе Tensor G6 с дисплеем Super Actua и тройной камерой с телеобъективом 5x. Поставляется с Android 17.",
                "Google ning 2026-yilgi 6.3 dyuymli Pro smartfoni: Tensor G6 chipi, Super Actua displey va 5x teleob'ektivli uchlik kamera. Android 17 bilan yetkaziladi.",
                "Google's 2026 6.3-inch Pro Pixel with the Tensor G6 chip, a Super Actua display and a triple camera that includes a 5x telephoto. It ships with Android 17."),
            new List<string>
            {
                "/products/pixel-11-pro/1.webp",
                "/products/pixel-11-pro/2.webp",
                "/products/pixel-11-pro/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Google Tensor G6", "Google Tensor G6", "Google Tensor G6")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.3 дюйма Super Actua LTPO OLED, 1-120 Гц", "6.3 dyuym Super Actua LTPO OLED, 1-120 Hz", "6.3 inch Super Actua LTPO OLED, 1-120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("50 Мп + 48 Мп + 48 Мп (5x)", "50 MP + 48 MP + 48 MP (5x)", "50 MP + 48 MP + 48 MP (5x)")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("4850 мА·ч", "4850 mA·soat", "4850 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("204 г", "204 g", "204 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Каньон, оливковый, туман, обсидиан", "Kanyon, zaytun, tuman, obsidian", "Canyon, Olive, Fog, Obsidian")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Android 17", "Android 17", "Android 17")),
            }),

        new(
            "xiaomi-17-ultra",
            CatPhones, BrXiaomi, 1754.00m, 29,
            new("Xiaomi 17 Ultra", "Xiaomi 17 Ultra", "Xiaomi 17 Ultra"),
            new(
                "Камерофлагман Xiaomi 2026 года, созданный совместно с Leica: основной сенсор 50 Мп 1 дюйм и перископ 200 Мп с зумом 75-100 мм. Snapdragon 8 Elite Gen 5 и OLED-дисплей 6.9 дюйма 120 Гц.",
                "Leica bilan birgalikda yaratilgan Xiaomi ning 2026-yilgi kamera flagmani: 1 dyuymli 50 MP asosiy sensor va 75-100 mm zumli 200 MP periskop. Snapdragon 8 Elite Gen 5 va 6.9 dyuymli 120 Hz OLED displey.",
                "Xiaomi's 2026 camera flagship co-engineered with Leica, pairing a 1-inch-type 50 MP main sensor with a 200 MP 75-100 mm periscope. It uses Snapdragon 8 Elite Gen 5 and a 6.9-inch 120 Hz OLED display."),
            new List<string>
            {
                "/products/xiaomi-17-ultra/1.webp",
                "/products/xiaomi-17-ultra/2.webp",
                "/products/xiaomi-17-ultra/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 8 Elite Gen 5", "Snapdragon 8 Elite Gen 5", "Snapdragon 8 Elite Gen 5")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("16 ГБ", "16 GB", "16 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("512 ГБ", "512 GB", "512 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.9 дюйма HyperRGB LTPO OLED, 1-120 Гц", "6.9 dyuym HyperRGB LTPO OLED, 1-120 Hz", "6.9 inch HyperRGB LTPO OLED, 1-120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("50 Мп Leica + 200 Мп (перископ) + 50 Мп", "50 MP Leica + 200 MP (periskop) + 50 MP", "50 MP Leica + 200 MP (periscope) + 50 MP")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("6000 мА·ч", "6000 mA·soat", "6000 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("218.4 г", "218.4 g", "218.4 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Звёздный зелёный, чёрный, белый", "Yulduzli yashil, qora, oq", "Starlit Green, Black, White")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Xiaomi HyperOS 3 (Android 16)", "Xiaomi HyperOS 3 (Android 16)", "Xiaomi HyperOS 3 (Android 16)")),
            }),

        new(
            "xiaomi-17",
            CatPhones, BrXiaomi, 1169.00m, 44,
            new("Xiaomi 17", "Xiaomi 17", "Xiaomi 17"),
            new(
                "Компактный флагман Xiaomi 2026 года с OLED-дисплеем 6.3 дюйма 120 Гц, Snapdragon 8 Elite Gen 5 и кремний-углеродным аккумулятором 6330 мА·ч. Камера Leica с тремя сенсорами по 50 Мп, включая телеобъектив 60 мм.",
                "Xiaomi ning 2026-yilgi ixcham flagmani: 6.3 dyuymli 120 Hz OLED displey, Snapdragon 8 Elite Gen 5 va 6330 mA·soat kremniy-uglerod batareya. Leica kamerasi 60 mm teleob'ektivni qo'shgan holda uchta 50 MP sensorga ega.",
                "Xiaomi's compact 2026 flagship with a 6.3-inch 120 Hz OLED display, Snapdragon 8 Elite Gen 5 and a 6330 mAh silicon-carbon battery. Its Leica triple camera uses three 50 MP sensors including a 60 mm telephoto."),
            new List<string>
            {
                "/products/xiaomi-17/1.webp",
                "/products/xiaomi-17/2.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 8 Elite Gen 5", "Snapdragon 8 Elite Gen 5", "Snapdragon 8 Elite Gen 5")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.3 дюйма CrystalRes LTPO OLED, 1-120 Гц", "6.3 dyuym CrystalRes LTPO OLED, 1-120 Hz", "6.3 inch CrystalRes LTPO OLED, 1-120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("50 Мп Leica тройная", "50 MP Leica uchlik", "50 MP Leica triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("6330 мА·ч", "6330 mA·soat", "6330 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("191 г", "191 g", "191 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Зелёный, чёрный, ледяной голубой, альпийский розовый", "Yashil, qora, muzdek ko'k, alp pushti", "Venture Green, Black, Ice Blue, Alpine Pink")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Xiaomi HyperOS 3 (Android 16)", "Xiaomi HyperOS 3 (Android 16)", "Xiaomi HyperOS 3 (Android 16)")),
            }),

        new(
            "redmi-note-15-pro-plus",
            CatPhones, BrXiaomi, 449.00m, 17,
            new("Redmi Note 15 Pro+ 5G", "Redmi Note 15 Pro+ 5G", "Redmi Note 15 Pro+ 5G"),
            new(
                "Топовая модель линейки Redmi Note 15 с AMOLED-дисплеем 6.83 дюйма 120 Гц, Snapdragon 7s Gen 4 и основной камерой 200 Мп. Кремний-углеродный аккумулятор 6500 мА·ч.",
                "Redmi Note 15 qatorining eng yuqori modeli: 6.83 dyuymli 120 Hz AMOLED displey, Snapdragon 7s Gen 4 va 200 MP asosiy kamera. 6500 mA·soat kremniy-uglerod batareya.",
                "The top model of the Redmi Note 15 series with a 6.83-inch 120 Hz AMOLED display, Snapdragon 7s Gen 4 and a 200 MP main camera. It packs a 6500 mAh silicon-carbon battery."),
            new List<string>
            {
                "/products/redmi-note-15-pro-plus/1.webp",
                "/products/redmi-note-15-pro-plus/2.webp",
                "/products/redmi-note-15-pro-plus/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 7s Gen 4", "Snapdragon 7s Gen 4", "Snapdragon 7s Gen 4")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.83 дюйма CrystalRes AMOLED, 120 Гц", "6.83 dyuym CrystalRes AMOLED, 120 Hz", "6.83 inch CrystalRes AMOLED, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("200 Мп (OIS) + 8 Мп", "200 MP (OIS) + 8 MP", "200 MP (OIS) + 8 MP")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("6500 мА·ч", "6500 mA·soat", "6500 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("207.1 г", "207.1 g", "207.1 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Мокко, ледниковый синий, чёрный", "Mokko, muzlik ko'k, qora", "Mocha Brown, Glacier Blue, Black")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Xiaomi HyperOS 2 (Android 15)", "Xiaomi HyperOS 2 (Android 15)", "Xiaomi HyperOS 2 (Android 15)")),
            }),

        new(
            "redmi-note-15-pro",
            CatPhones, BrXiaomi, 399.00m, 35,
            new("Redmi Note 15 Pro 5G", "Redmi Note 15 Pro 5G", "Redmi Note 15 Pro 5G"),
            new(
                "Модель среднего класса Redmi Note 15 с AMOLED-дисплеем 6.83 дюйма 120 Гц, MediaTek Dimensity 7400-Ultra и основной камерой 200 Мп. Кремний-углеродный аккумулятор 6580 мА·ч.",
                "Redmi Note 15 ning o'rta sinf modeli: 6.83 dyuymli 120 Hz AMOLED displey, MediaTek Dimensity 7400-Ultra va 200 MP asosiy kamera. 6580 mA·soat kremniy-uglerod batareya.",
                "A mid-range Redmi Note 15 model with a 6.83-inch 120 Hz AMOLED display, MediaTek Dimensity 7400-Ultra and a 200 MP main camera. It has a 6580 mAh silicon-carbon battery."),
            new List<string>
            {
                "/products/redmi-note-15-pro/1.webp",
                "/products/redmi-note-15-pro/2.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("MediaTek Dimensity 7400-Ultra", "MediaTek Dimensity 7400-Ultra", "MediaTek Dimensity 7400-Ultra")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.83 дюйма AMOLED, 120 Гц", "6.83 dyuym AMOLED, 120 Hz", "6.83 inch AMOLED, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("200 Мп (OIS) + 8 Мп", "200 MP (OIS) + 8 MP", "200 MP (OIS) + 8 MP")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("6580 мА·ч", "6580 mA·soat", "6580 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("210 г", "210 g", "210 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Титановый, ледниковый синий, туманно-фиолетовый, чёрный", "Titan, muzlik ko'k, tumanli binafsha, qora", "Titanium, Glacier Blue, Mist Purple, Black")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Xiaomi HyperOS 2 (Android 15)", "Xiaomi HyperOS 2 (Android 15)", "Xiaomi HyperOS 2 (Android 15)")),
            }),

        new(
            "redmi-note-15",
            CatPhones, BrXiaomi, 326.00m, 8,
            new("Redmi Note 15 5G", "Redmi Note 15 5G", "Redmi Note 15 5G"),
            new(
                "Базовая модель линейки Redmi Note 15 5G с AMOLED-дисплеем 120 Гц, Snapdragon 6 Gen 3 и основной камерой 108 Мп. Кремний-углеродный аккумулятор 5520 мА·ч, вес 178 г.",
                "Redmi Note 15 5G qatorining bazaviy modeli: 120 Hz AMOLED displey, Snapdragon 6 Gen 3 va 108 MP asosiy kamera. 5520 mA·soat kremniy-uglerod batareya, vazni 178 g.",
                "The entry model of the Redmi Note 15 5G line with a 120 Hz AMOLED display, Snapdragon 6 Gen 3 and a 108 MP main camera. It has a 5520 mAh silicon-carbon battery and weighs 178 g."),
            new List<string>
            {
                "/products/redmi-note-15/1.webp",
                "/products/redmi-note-15/2.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Snapdragon 6 Gen 3", "Snapdragon 6 Gen 3", "Snapdragon 6 Gen 3")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("6 ГБ", "6 GB", "6 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("128 ГБ", "128 GB", "128 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.67 дюйма AMOLED, 120 Гц", "6.67 dyuym AMOLED, 120 Hz", "6.67 inch AMOLED, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("108 Мп (OIS) + 8 Мп", "108 MP (OIS) + 8 MP", "108 MP (OIS) + 8 MP")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("5520 мА·ч", "5520 mA·soat", "5520 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("178 г", "178 g", "178 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Туманно-фиолетовый, ледниковый синий, чёрный", "Tumanli binafsha, muzlik ko'k, qora", "Mist Purple, Glacier Blue, Black")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("Xiaomi HyperOS 2 (Android 15)", "Xiaomi HyperOS 2 (Android 15)", "Xiaomi HyperOS 2 (Android 15)")),
            }),

        new(
            "iphone-18-pro-black",
            CatPhones, BrApple, 1199.00m, 51,
            new("iPhone 18 Pro, чёрный", "iPhone 18 Pro, qora", "iPhone 18 Pro, Black"),
            new(
                "6.3-дюймовый iPhone 18 Pro 2026 года с чипом A20 Pro и тройной камерой 48 Мп Fusion, у основной камеры переменная диафрагма. Накопитель от 256 ГБ.",
                "2026-yilgi 6.3 dyuymli iPhone 18 Pro, A20 Pro chipi va 48 MP Fusion uchlik kamera bilan, asosiy kameraning diafragmasi o'zgaruvchan. Xotira 256 GB dan boshlanadi.",
                "Apple's 2026 6.3-inch iPhone 18 Pro with the A20 Pro chip and a triple 48 MP Fusion camera system whose Main camera has a variable aperture. It starts at 256 GB of storage."),
            new List<string>
            {
                "/products/iphone-18-pro-black/1.webp",
                "/products/iphone-18-pro-black/2.webp",
                "/products/iphone-18-pro-black/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A20 Pro", "Apple A20 Pro", "Apple A20 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.3 дюйма OLED 2622x1206, ProMotion 120 Гц", "6.3 dyuym OLED 2622x1206, ProMotion 120 Hz", "6.3 inch OLED 2622x1206, ProMotion 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion тройная", "48 MP Fusion uchlik", "48 MP Fusion triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("4056 мА·ч", "4056 mA·soat", "4056 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("211 г", "211 g", "211 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный", "Qora", "Black")),
            }),

        new(
            "iphone-18-pro-silver",
            CatPhones, BrApple, 1199.00m, 20,
            new("iPhone 18 Pro, серебристый", "iPhone 18 Pro, kumush rang", "iPhone 18 Pro, Silver"),
            new(
                "6.3-дюймовый iPhone 18 Pro 2026 года с чипом A20 Pro и тройной камерой 48 Мп Fusion, у основной камеры переменная диафрагма. Накопитель от 256 ГБ.",
                "2026-yilgi 6.3 dyuymli iPhone 18 Pro, A20 Pro chipi va 48 MP Fusion uchlik kamera bilan, asosiy kameraning diafragmasi o'zgaruvchan. Xotira 256 GB dan boshlanadi.",
                "Apple's 2026 6.3-inch iPhone 18 Pro with the A20 Pro chip and a triple 48 MP Fusion camera system whose Main camera has a variable aperture. It starts at 256 GB of storage."),
            new List<string>
            {
                "/products/iphone-18-pro-silver/1.webp",
                "/products/iphone-18-pro-silver/2.webp",
                "/products/iphone-18-pro-silver/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A20 Pro", "Apple A20 Pro", "Apple A20 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.3 дюйма OLED 2622x1206, ProMotion 120 Гц", "6.3 dyuym OLED 2622x1206, ProMotion 120 Hz", "6.3 inch OLED 2622x1206, ProMotion 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion тройная", "48 MP Fusion uchlik", "48 MP Fusion triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("4056 мА·ч", "4056 mA·soat", "4056 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("211 г", "211 g", "211 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Серебристый", "Kumush rang", "Silver")),
            }),

        new(
            "iphone-18-pro-glacier",
            CatPhones, BrApple, 1199.00m, 41,
            new("iPhone 18 Pro, ледниковый", "iPhone 18 Pro, muzlik", "iPhone 18 Pro, Glacier"),
            new(
                "6.3-дюймовый iPhone 18 Pro 2026 года с чипом A20 Pro и тройной камерой 48 Мп Fusion, у основной камеры переменная диафрагма. Накопитель от 256 ГБ.",
                "2026-yilgi 6.3 dyuymli iPhone 18 Pro, A20 Pro chipi va 48 MP Fusion uchlik kamera bilan, asosiy kameraning diafragmasi o'zgaruvchan. Xotira 256 GB dan boshlanadi.",
                "Apple's 2026 6.3-inch iPhone 18 Pro with the A20 Pro chip and a triple 48 MP Fusion camera system whose Main camera has a variable aperture. It starts at 256 GB of storage."),
            new List<string>
            {
                "/products/iphone-18-pro-glacier/1.webp",
                "/products/iphone-18-pro-glacier/2.webp",
                "/products/iphone-18-pro-glacier/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A20 Pro", "Apple A20 Pro", "Apple A20 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.3 дюйма OLED 2622x1206, ProMotion 120 Гц", "6.3 dyuym OLED 2622x1206, ProMotion 120 Hz", "6.3 inch OLED 2622x1206, ProMotion 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion тройная", "48 MP Fusion uchlik", "48 MP Fusion triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("4056 мА·ч", "4056 mA·soat", "4056 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("211 г", "211 g", "211 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Ледниковый", "Muzlik", "Glacier")),
            }),

        new(
            "iphone-18-pro-burgundy",
            CatPhones, BrApple, 1199.00m, 13,
            new("iPhone 18 Pro, бордовый", "iPhone 18 Pro, bordo", "iPhone 18 Pro, Burgundy"),
            new(
                "6.3-дюймовый iPhone 18 Pro 2026 года с чипом A20 Pro и тройной камерой 48 Мп Fusion, у основной камеры переменная диафрагма. Накопитель от 256 ГБ.",
                "2026-yilgi 6.3 dyuymli iPhone 18 Pro, A20 Pro chipi va 48 MP Fusion uchlik kamera bilan, asosiy kameraning diafragmasi o'zgaruvchan. Xotira 256 GB dan boshlanadi.",
                "Apple's 2026 6.3-inch iPhone 18 Pro with the A20 Pro chip and a triple 48 MP Fusion camera system whose Main camera has a variable aperture. It starts at 256 GB of storage."),
            new List<string>
            {
                "/products/iphone-18-pro-burgundy/1.webp",
                "/products/iphone-18-pro-burgundy/2.webp",
                "/products/iphone-18-pro-burgundy/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A20 Pro", "Apple A20 Pro", "Apple A20 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.3 дюйма OLED 2622x1206, ProMotion 120 Гц", "6.3 dyuym OLED 2622x1206, ProMotion 120 Hz", "6.3 inch OLED 2622x1206, ProMotion 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion тройная", "48 MP Fusion uchlik", "48 MP Fusion triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("4056 мА·ч", "4056 mA·soat", "4056 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("211 г", "211 g", "211 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Бордовый", "Bordo", "Burgundy")),
            }),

        new(
            "iphone-18-pro-max-black",
            CatPhones, BrApple, 1299.00m, 34,
            new("iPhone 18 Pro Max, чёрный", "iPhone 18 Pro Max, qora", "iPhone 18 Pro Max, Black"),
            new(
                "6.9-дюймовый iPhone 18 Pro Max 2026 года с чипом A20 Pro и тройной камерой 48 Мп Fusion; Apple заявляет о крупнейшем приросте времени работы за всю историю iPhone. Накопитель от 256 ГБ.",
                "2026-yilgi 6.9 dyuymli iPhone 18 Pro Max, A20 Pro chipi va 48 MP Fusion uchlik kamera bilan; Apple iPhone tarixidagi eng katta batareya ishlash vaqti o'sishini e'lon qildi. Xotira 256 GB dan boshlanadi.",
                "Apple's 2026 6.9-inch iPhone 18 Pro Max with the A20 Pro chip and a triple 48 MP Fusion camera system; Apple says it has the largest battery-life increase ever on iPhone. It starts at 256 GB of storage."),
            new List<string>
            {
                "/products/iphone-18-pro-max-black/1.webp",
                "/products/iphone-18-pro-max-black/2.webp",
                "/products/iphone-18-pro-max-black/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A20 Pro", "Apple A20 Pro", "Apple A20 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.9 дюйма OLED 2868x1320, ProMotion 120 Гц", "6.9 dyuym OLED 2868x1320, ProMotion 120 Hz", "6.9 inch OLED 2868x1320, ProMotion 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion тройная", "48 MP Fusion uchlik", "48 MP Fusion triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("5391 мА·ч", "5391 mA·soat", "5391 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("249 г", "249 g", "249 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный", "Qora", "Black")),
            }),

        new(
            "iphone-18-pro-max-silver",
            CatPhones, BrApple, 1299.00m, 21,
            new("iPhone 18 Pro Max, серебристый", "iPhone 18 Pro Max, kumush rang", "iPhone 18 Pro Max, Silver"),
            new(
                "6.9-дюймовый iPhone 18 Pro Max 2026 года с чипом A20 Pro и тройной камерой 48 Мп Fusion; Apple заявляет о крупнейшем приросте времени работы за всю историю iPhone. Накопитель от 256 ГБ.",
                "2026-yilgi 6.9 dyuymli iPhone 18 Pro Max, A20 Pro chipi va 48 MP Fusion uchlik kamera bilan; Apple iPhone tarixidagi eng katta batareya ishlash vaqti o'sishini e'lon qildi. Xotira 256 GB dan boshlanadi.",
                "Apple's 2026 6.9-inch iPhone 18 Pro Max with the A20 Pro chip and a triple 48 MP Fusion camera system; Apple says it has the largest battery-life increase ever on iPhone. It starts at 256 GB of storage."),
            new List<string>
            {
                "/products/iphone-18-pro-max-silver/1.webp",
                "/products/iphone-18-pro-max-silver/2.webp",
                "/products/iphone-18-pro-max-silver/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A20 Pro", "Apple A20 Pro", "Apple A20 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.9 дюйма OLED 2868x1320, ProMotion 120 Гц", "6.9 dyuym OLED 2868x1320, ProMotion 120 Hz", "6.9 inch OLED 2868x1320, ProMotion 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion тройная", "48 MP Fusion uchlik", "48 MP Fusion triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("5391 мА·ч", "5391 mA·soat", "5391 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("249 г", "249 g", "249 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Серебристый", "Kumush rang", "Silver")),
            }),

        new(
            "iphone-18-pro-max-glacier",
            CatPhones, BrApple, 1299.00m, 47,
            new("iPhone 18 Pro Max, ледниковый", "iPhone 18 Pro Max, muzlik", "iPhone 18 Pro Max, Glacier"),
            new(
                "6.9-дюймовый iPhone 18 Pro Max 2026 года с чипом A20 Pro и тройной камерой 48 Мп Fusion; Apple заявляет о крупнейшем приросте времени работы за всю историю iPhone. Накопитель от 256 ГБ.",
                "2026-yilgi 6.9 dyuymli iPhone 18 Pro Max, A20 Pro chipi va 48 MP Fusion uchlik kamera bilan; Apple iPhone tarixidagi eng katta batareya ishlash vaqti o'sishini e'lon qildi. Xotira 256 GB dan boshlanadi.",
                "Apple's 2026 6.9-inch iPhone 18 Pro Max with the A20 Pro chip and a triple 48 MP Fusion camera system; Apple says it has the largest battery-life increase ever on iPhone. It starts at 256 GB of storage."),
            new List<string>
            {
                "/products/iphone-18-pro-max-glacier/1.webp",
                "/products/iphone-18-pro-max-glacier/2.webp",
                "/products/iphone-18-pro-max-glacier/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A20 Pro", "Apple A20 Pro", "Apple A20 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.9 дюйма OLED 2868x1320, ProMotion 120 Гц", "6.9 dyuym OLED 2868x1320, ProMotion 120 Hz", "6.9 inch OLED 2868x1320, ProMotion 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion тройная", "48 MP Fusion uchlik", "48 MP Fusion triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("5391 мА·ч", "5391 mA·soat", "5391 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("249 г", "249 g", "249 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Ледниковый", "Muzlik", "Glacier")),
            }),

        new(
            "iphone-18-pro-max-burgundy",
            CatPhones, BrApple, 1299.00m, 15,
            new("iPhone 18 Pro Max, бордовый", "iPhone 18 Pro Max, bordo", "iPhone 18 Pro Max, Burgundy"),
            new(
                "6.9-дюймовый iPhone 18 Pro Max 2026 года с чипом A20 Pro и тройной камерой 48 Мп Fusion; Apple заявляет о крупнейшем приросте времени работы за всю историю iPhone. Накопитель от 256 ГБ.",
                "2026-yilgi 6.9 dyuymli iPhone 18 Pro Max, A20 Pro chipi va 48 MP Fusion uchlik kamera bilan; Apple iPhone tarixidagi eng katta batareya ishlash vaqti o'sishini e'lon qildi. Xotira 256 GB dan boshlanadi.",
                "Apple's 2026 6.9-inch iPhone 18 Pro Max with the A20 Pro chip and a triple 48 MP Fusion camera system; Apple says it has the largest battery-life increase ever on iPhone. It starts at 256 GB of storage."),
            new List<string>
            {
                "/products/iphone-18-pro-max-burgundy/1.webp",
                "/products/iphone-18-pro-max-burgundy/2.webp",
                "/products/iphone-18-pro-max-burgundy/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A20 Pro", "Apple A20 Pro", "Apple A20 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.9 дюйма OLED 2868x1320, ProMotion 120 Гц", "6.9 dyuym OLED 2868x1320, ProMotion 120 Hz", "6.9 inch OLED 2868x1320, ProMotion 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion тройная", "48 MP Fusion uchlik", "48 MP Fusion triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("5391 мА·ч", "5391 mA·soat", "5391 mAh")),
                new("weight", new("Вес", "Vazn", "Weight"), new("249 г", "249 g", "249 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Бордовый", "Bordo", "Burgundy")),
            }),

        new(
            "iphone-duo-star-white",
            CatPhones, BrApple, 1999.00m, 28,
            new("iPhone Duo, звёздный белый", "iPhone Duo, yulduzli oq", "iPhone Duo, Star White"),
            new(
                "Первый складной iPhone от Apple с внутренним дисплеем 7.6 дюйма, внешним 5.4 дюйма, чипом A20 Pro и корпусом из титана 5 класса. Apple называет его самым тонким iPhone в раскрытом виде.",
                "Apple ning birinchi buklanuvchi iPhone i: 7.6 dyuymli ichki va 5.4 dyuymli tashqi displey, A20 Pro chipi va 5-sinf titan korpus bilan. Apple uni ochiq holatda eng yupqa iPhone deb ataydi.",
                "Apple's first foldable iPhone, with a 7.6-inch inner display, a 5.4-inch outer display, the A20 Pro chip and a grade 5 titanium design. Apple calls it the thinnest iPhone ever when opened."),
            new List<string>
            {
                "/products/iphone-duo-star-white/1.webp",
                "/products/iphone-duo-star-white/2.webp",
                "/products/iphone-duo-star-white/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A20 Pro", "Apple A20 Pro", "Apple A20 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("7.6 дюйма складной OLED + внешний 5.4 дюйма OLED, ProMotion 120 Гц", "7.6 dyuym buklanuvchi OLED + tashqi 5.4 dyuym OLED, ProMotion 120 Hz", "7.6 inch foldable OLED + 5.4 inch outer OLED, ProMotion 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion двойная", "48 MP Fusion ikkilik", "48 MP Fusion dual")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 31 ч (внутренний экран), до 44 ч (внешний)", "31 soatgacha (ichki ekran), 44 soatgacha (tashqi)", "up to 31 h (inner display), up to 44 h (outer)")),
                new("weight", new("Вес", "Vazn", "Weight"), new("254 г", "254 g", "254 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Звёздный белый", "Yulduzli oq", "Star White")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("iOS 27.1", "iOS 27.1", "iOS 27.1")),
            }),

        new(
            "iphone-duo-night-sky",
            CatPhones, BrApple, 1999.00m, 52,
            new("iPhone Duo, ночное небо", "iPhone Duo, tungi osmon", "iPhone Duo, Night Sky"),
            new(
                "Первый складной iPhone от Apple с внутренним дисплеем 7.6 дюйма, внешним 5.4 дюйма, чипом A20 Pro и корпусом из титана 5 класса. Apple называет его самым тонким iPhone в раскрытом виде.",
                "Apple ning birinchi buklanuvchi iPhone i: 7.6 dyuymli ichki va 5.4 dyuymli tashqi displey, A20 Pro chipi va 5-sinf titan korpus bilan. Apple uni ochiq holatda eng yupqa iPhone deb ataydi.",
                "Apple's first foldable iPhone, with a 7.6-inch inner display, a 5.4-inch outer display, the A20 Pro chip and a grade 5 titanium design. Apple calls it the thinnest iPhone ever when opened."),
            new List<string>
            {
                "/products/iphone-duo-night-sky/1.webp",
                "/products/iphone-duo-night-sky/2.webp",
                "/products/iphone-duo-night-sky/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A20 Pro", "Apple A20 Pro", "Apple A20 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("7.6 дюйма складной OLED + внешний 5.4 дюйма OLED, ProMotion 120 Гц", "7.6 dyuym buklanuvchi OLED + tashqi 5.4 dyuym OLED, ProMotion 120 Hz", "7.6 inch foldable OLED + 5.4 inch outer OLED, ProMotion 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion двойная", "48 MP Fusion ikkilik", "48 MP Fusion dual")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 31 ч (внутренний экран), до 44 ч (внешний)", "31 soatgacha (ichki ekran), 44 soatgacha (tashqi)", "up to 31 h (inner display), up to 44 h (outer)")),
                new("weight", new("Вес", "Vazn", "Weight"), new("254 г", "254 g", "254 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Ночное небо", "Tungi osmon", "Night Sky")),
                new("os", new("Операционная система", "Operatsion tizim", "OS"), new("iOS 27.1", "iOS 27.1", "iOS 27.1")),
            }),

        new(
            "iphone-17-black",
            CatPhones, BrApple, 899.00m, 12,
            new("iPhone 17, чёрный", "iPhone 17, qora", "iPhone 17, Black"),
            new(
                "iPhone 17 с дисплеем Super Retina XDR 6.3 дюйма с ProMotion, чипом A19 и двойной камерой 48 Мп Fusion. Накопитель от 256 ГБ.",
                "iPhone 17: ProMotion bilan 6.3 dyuymli Super Retina XDR displey, A19 chipi va 48 MP Fusion ikkilik kamera. Xotira 256 GB dan boshlanadi.",
                "iPhone 17 has a 6.3-inch Super Retina XDR display with ProMotion, the A19 chip and a dual 48 MP Fusion camera system. It starts at 256 GB of storage."),
            new List<string>
            {
                "/products/iphone-17-black/1.webp",
                "/products/iphone-17-black/2.webp",
                "/products/iphone-17-black/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19", "Apple A19", "Apple A19")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.3 дюйма Super Retina XDR 2622x1206, 120 Гц", "6.3 dyuym Super Retina XDR 2622x1206, 120 Hz", "6.3 inch Super Retina XDR 2622x1206, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion двойная", "48 MP Fusion ikkilik", "48 MP Fusion dual")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 30 ч", "30 soatgacha", "up to 30 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("177 г", "177 g", "177 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный", "Qora", "Black")),
            }),

        new(
            "iphone-17-white",
            CatPhones, BrApple, 899.00m, 39,
            new("iPhone 17, белый", "iPhone 17, oq", "iPhone 17, White"),
            new(
                "iPhone 17 с дисплеем Super Retina XDR 6.3 дюйма с ProMotion, чипом A19 и двойной камерой 48 Мп Fusion. Накопитель от 256 ГБ.",
                "iPhone 17: ProMotion bilan 6.3 dyuymli Super Retina XDR displey, A19 chipi va 48 MP Fusion ikkilik kamera. Xotira 256 GB dan boshlanadi.",
                "iPhone 17 has a 6.3-inch Super Retina XDR display with ProMotion, the A19 chip and a dual 48 MP Fusion camera system. It starts at 256 GB of storage."),
            new List<string>
            {
                "/products/iphone-17-white/1.webp",
                "/products/iphone-17-white/2.webp",
                "/products/iphone-17-white/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19", "Apple A19", "Apple A19")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.3 дюйма Super Retina XDR 2622x1206, 120 Гц", "6.3 dyuym Super Retina XDR 2622x1206, 120 Hz", "6.3 inch Super Retina XDR 2622x1206, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion двойная", "48 MP Fusion ikkilik", "48 MP Fusion dual")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 30 ч", "30 soatgacha", "up to 30 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("177 г", "177 g", "177 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Белый", "Oq", "White")),
            }),

        new(
            "iphone-17-mist-blue",
            CatPhones, BrApple, 899.00m, 24,
            new("iPhone 17, туманно-голубой", "iPhone 17, tumanli ko'k", "iPhone 17, Mist Blue"),
            new(
                "iPhone 17 с дисплеем Super Retina XDR 6.3 дюйма с ProMotion, чипом A19 и двойной камерой 48 Мп Fusion. Накопитель от 256 ГБ.",
                "iPhone 17: ProMotion bilan 6.3 dyuymli Super Retina XDR displey, A19 chipi va 48 MP Fusion ikkilik kamera. Xotira 256 GB dan boshlanadi.",
                "iPhone 17 has a 6.3-inch Super Retina XDR display with ProMotion, the A19 chip and a dual 48 MP Fusion camera system. It starts at 256 GB of storage."),
            new List<string>
            {
                "/products/iphone-17-mist-blue/1.webp",
                "/products/iphone-17-mist-blue/2.webp",
                "/products/iphone-17-mist-blue/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19", "Apple A19", "Apple A19")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.3 дюйма Super Retina XDR 2622x1206, 120 Гц", "6.3 dyuym Super Retina XDR 2622x1206, 120 Hz", "6.3 inch Super Retina XDR 2622x1206, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion двойная", "48 MP Fusion ikkilik", "48 MP Fusion dual")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 30 ч", "30 soatgacha", "up to 30 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("177 г", "177 g", "177 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Туманно-голубой", "Tumanli ko'k", "Mist Blue")),
            }),

        new(
            "iphone-17-sage",
            CatPhones, BrApple, 899.00m, 58,
            new("iPhone 17, шалфей", "iPhone 17, shalfey", "iPhone 17, Sage"),
            new(
                "iPhone 17 с дисплеем Super Retina XDR 6.3 дюйма с ProMotion, чипом A19 и двойной камерой 48 Мп Fusion. Накопитель от 256 ГБ.",
                "iPhone 17: ProMotion bilan 6.3 dyuymli Super Retina XDR displey, A19 chipi va 48 MP Fusion ikkilik kamera. Xotira 256 GB dan boshlanadi.",
                "iPhone 17 has a 6.3-inch Super Retina XDR display with ProMotion, the A19 chip and a dual 48 MP Fusion camera system. It starts at 256 GB of storage."),
            new List<string>
            {
                "/products/iphone-17-sage/1.webp",
                "/products/iphone-17-sage/2.webp",
                "/products/iphone-17-sage/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19", "Apple A19", "Apple A19")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.3 дюйма Super Retina XDR 2622x1206, 120 Гц", "6.3 dyuym Super Retina XDR 2622x1206, 120 Hz", "6.3 inch Super Retina XDR 2622x1206, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion двойная", "48 MP Fusion ikkilik", "48 MP Fusion dual")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 30 ч", "30 soatgacha", "up to 30 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("177 г", "177 g", "177 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Шалфей", "Shalfey", "Sage")),
            }),

        new(
            "iphone-17-lavender",
            CatPhones, BrApple, 899.00m, 18,
            new("iPhone 17, лавандовый", "iPhone 17, lavanda", "iPhone 17, Lavender"),
            new(
                "iPhone 17 с дисплеем Super Retina XDR 6.3 дюйма с ProMotion, чипом A19 и двойной камерой 48 Мп Fusion. Накопитель от 256 ГБ.",
                "iPhone 17: ProMotion bilan 6.3 dyuymli Super Retina XDR displey, A19 chipi va 48 MP Fusion ikkilik kamera. Xotira 256 GB dan boshlanadi.",
                "iPhone 17 has a 6.3-inch Super Retina XDR display with ProMotion, the A19 chip and a dual 48 MP Fusion camera system. It starts at 256 GB of storage."),
            new List<string>
            {
                "/products/iphone-17-lavender/1.webp",
                "/products/iphone-17-lavender/2.webp",
                "/products/iphone-17-lavender/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19", "Apple A19", "Apple A19")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.3 дюйма Super Retina XDR 2622x1206, 120 Гц", "6.3 dyuym Super Retina XDR 2622x1206, 120 Hz", "6.3 inch Super Retina XDR 2622x1206, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion двойная", "48 MP Fusion ikkilik", "48 MP Fusion dual")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 30 ч", "30 soatgacha", "up to 30 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("177 г", "177 g", "177 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Лавандовый", "Lavanda", "Lavender")),
            }),

        new(
            "iphone-air-space-black",
            CatPhones, BrApple, 1099.00m, 43,
            new("iPhone Air, чёрный космос", "iPhone Air, kosmik qora", "iPhone Air, Space Black"),
            new(
                "Самый тонкий iPhone Apple с 6.5-дюймовым дисплеем, титановой рамой, чипом A19 Pro и одной камерой 48 Мп Fusion. Вес всего 165 г.",
                "Apple ning eng yupqa iPhone i: 6.5 dyuymli displey, titan ramka, A19 Pro chipi va bitta 48 MP Fusion kamera bilan. Vazni atigi 165 g.",
                "Apple's thinnest iPhone with a 6.5-inch display, a titanium frame, the A19 Pro chip and a single 48 MP Fusion camera. It weighs just 165 g."),
            new List<string>
            {
                "/products/iphone-air-space-black/1.webp",
                "/products/iphone-air-space-black/2.webp",
                "/products/iphone-air-space-black/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19 Pro", "Apple A19 Pro", "Apple A19 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.5 дюйма Super Retina XDR 2736x1260, 120 Гц", "6.5 dyuym Super Retina XDR 2736x1260, 120 Hz", "6.5 inch Super Retina XDR 2736x1260, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion одинарная", "48 MP Fusion yakka", "48 MP Fusion single")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 27 ч", "27 soatgacha", "up to 27 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("165 г", "165 g", "165 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный космос", "Kosmik qora", "Space Black")),
            }),

        new(
            "iphone-air-cloud-white",
            CatPhones, BrApple, 1099.00m, 9,
            new("iPhone Air, облачно-белый", "iPhone Air, bulutdek oq", "iPhone Air, Cloud White"),
            new(
                "Самый тонкий iPhone Apple с 6.5-дюймовым дисплеем, титановой рамой, чипом A19 Pro и одной камерой 48 Мп Fusion. Вес всего 165 г.",
                "Apple ning eng yupqa iPhone i: 6.5 dyuymli displey, titan ramka, A19 Pro chipi va bitta 48 MP Fusion kamera bilan. Vazni atigi 165 g.",
                "Apple's thinnest iPhone with a 6.5-inch display, a titanium frame, the A19 Pro chip and a single 48 MP Fusion camera. It weighs just 165 g."),
            new List<string>
            {
                "/products/iphone-air-cloud-white/1.webp",
                "/products/iphone-air-cloud-white/2.webp",
                "/products/iphone-air-cloud-white/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19 Pro", "Apple A19 Pro", "Apple A19 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.5 дюйма Super Retina XDR 2736x1260, 120 Гц", "6.5 dyuym Super Retina XDR 2736x1260, 120 Hz", "6.5 inch Super Retina XDR 2736x1260, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion одинарная", "48 MP Fusion yakka", "48 MP Fusion single")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 27 ч", "27 soatgacha", "up to 27 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("165 г", "165 g", "165 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Облачно-белый", "Bulutdek oq", "Cloud White")),
            }),

        new(
            "iphone-air-light-gold",
            CatPhones, BrApple, 1099.00m, 31,
            new("iPhone Air, светлое золото", "iPhone Air, och oltin", "iPhone Air, Light Gold"),
            new(
                "Самый тонкий iPhone Apple с 6.5-дюймовым дисплеем, титановой рамой, чипом A19 Pro и одной камерой 48 Мп Fusion. Вес всего 165 г.",
                "Apple ning eng yupqa iPhone i: 6.5 dyuymli displey, titan ramka, A19 Pro chipi va bitta 48 MP Fusion kamera bilan. Vazni atigi 165 g.",
                "Apple's thinnest iPhone with a 6.5-inch display, a titanium frame, the A19 Pro chip and a single 48 MP Fusion camera. It weighs just 165 g."),
            new List<string>
            {
                "/products/iphone-air-light-gold/1.webp",
                "/products/iphone-air-light-gold/2.webp",
                "/products/iphone-air-light-gold/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19 Pro", "Apple A19 Pro", "Apple A19 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.5 дюйма Super Retina XDR 2736x1260, 120 Гц", "6.5 dyuym Super Retina XDR 2736x1260, 120 Hz", "6.5 inch Super Retina XDR 2736x1260, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion одинарная", "48 MP Fusion yakka", "48 MP Fusion single")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 27 ч", "27 soatgacha", "up to 27 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("165 г", "165 g", "165 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Светлое золото", "Och oltin", "Light Gold")),
            }),

        new(
            "iphone-air-sky-blue",
            CatPhones, BrApple, 1099.00m, 26,
            new("iPhone Air, небесно-голубой", "iPhone Air, osmon ko'k", "iPhone Air, Sky Blue"),
            new(
                "Самый тонкий iPhone Apple с 6.5-дюймовым дисплеем, титановой рамой, чипом A19 Pro и одной камерой 48 Мп Fusion. Вес всего 165 г.",
                "Apple ning eng yupqa iPhone i: 6.5 dyuymli displey, titan ramka, A19 Pro chipi va bitta 48 MP Fusion kamera bilan. Vazni atigi 165 g.",
                "Apple's thinnest iPhone with a 6.5-inch display, a titanium frame, the A19 Pro chip and a single 48 MP Fusion camera. It weighs just 165 g."),
            new List<string>
            {
                "/products/iphone-air-sky-blue/1.webp",
                "/products/iphone-air-sky-blue/2.webp",
                "/products/iphone-air-sky-blue/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19 Pro", "Apple A19 Pro", "Apple A19 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.5 дюйма Super Retina XDR 2736x1260, 120 Гц", "6.5 dyuym Super Retina XDR 2736x1260, 120 Hz", "6.5 inch Super Retina XDR 2736x1260, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion одинарная", "48 MP Fusion yakka", "48 MP Fusion single")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 27 ч", "27 soatgacha", "up to 27 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("165 г", "165 g", "165 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Небесно-голубой", "Osmon ko'k", "Sky Blue")),
            }),

        new(
            "iphone-17-pro-silver",
            CatPhones, BrApple, 1099.00m, 55,
            new("iPhone 17 Pro, серебристый", "iPhone 17 Pro, kumush rang", "iPhone 17 Pro, Silver"),
            new(
                "6.3-дюймовый iPhone 17 Pro 2025 года с чипом A19 Pro и тройной камерой 48 Мп Pro Fusion с телеобъективом 4x.",
                "2025-yilgi 6.3 dyuymli iPhone 17 Pro, A19 Pro chipi va 4x teleob'ektivli 48 MP Pro Fusion uchlik kamera bilan.",
                "Apple's 2025 6.3-inch iPhone 17 Pro with the A19 Pro chip and a triple 48 MP Pro Fusion camera system with a 4x telephoto."),
            new List<string>
            {
                "/products/iphone-17-pro-silver/1.webp",
                "/products/iphone-17-pro-silver/2.webp",
                "/products/iphone-17-pro-silver/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19 Pro", "Apple A19 Pro", "Apple A19 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.3 дюйма Super Retina XDR 2622x1206, 120 Гц", "6.3 dyuym Super Retina XDR 2622x1206, 120 Hz", "6.3 inch Super Retina XDR 2622x1206, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion тройная", "48 MP Fusion uchlik", "48 MP Fusion triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 33 ч", "33 soatgacha", "up to 33 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("206 г", "206 g", "206 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Серебристый", "Kumush rang", "Silver")),
            }),

        new(
            "iphone-17-pro-cosmic-orange",
            CatPhones, BrApple, 1099.00m, 14,
            new("iPhone 17 Pro, космический оранжевый", "iPhone 17 Pro, kosmik to'q sariq", "iPhone 17 Pro, Cosmic Orange"),
            new(
                "6.3-дюймовый iPhone 17 Pro 2025 года с чипом A19 Pro и тройной камерой 48 Мп Pro Fusion с телеобъективом 4x.",
                "2025-yilgi 6.3 dyuymli iPhone 17 Pro, A19 Pro chipi va 4x teleob'ektivli 48 MP Pro Fusion uchlik kamera bilan.",
                "Apple's 2025 6.3-inch iPhone 17 Pro with the A19 Pro chip and a triple 48 MP Pro Fusion camera system with a 4x telephoto."),
            new List<string>
            {
                "/products/iphone-17-pro-cosmic-orange/1.webp",
                "/products/iphone-17-pro-cosmic-orange/2.webp",
                "/products/iphone-17-pro-cosmic-orange/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19 Pro", "Apple A19 Pro", "Apple A19 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.3 дюйма Super Retina XDR 2622x1206, 120 Гц", "6.3 dyuym Super Retina XDR 2622x1206, 120 Hz", "6.3 inch Super Retina XDR 2622x1206, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion тройная", "48 MP Fusion uchlik", "48 MP Fusion triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 33 ч", "33 soatgacha", "up to 33 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("206 г", "206 g", "206 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Космический оранжевый", "Kosmik to'q sariq", "Cosmic Orange")),
            }),

        new(
            "iphone-17-pro-deep-blue",
            CatPhones, BrApple, 1099.00m, 37,
            new("iPhone 17 Pro, насыщенный синий", "iPhone 17 Pro, to'q ko'k", "iPhone 17 Pro, Deep Blue"),
            new(
                "6.3-дюймовый iPhone 17 Pro 2025 года с чипом A19 Pro и тройной камерой 48 Мп Pro Fusion с телеобъективом 4x.",
                "2025-yilgi 6.3 dyuymli iPhone 17 Pro, A19 Pro chipi va 4x teleob'ektivli 48 MP Pro Fusion uchlik kamera bilan.",
                "Apple's 2025 6.3-inch iPhone 17 Pro with the A19 Pro chip and a triple 48 MP Pro Fusion camera system with a 4x telephoto."),
            new List<string>
            {
                "/products/iphone-17-pro-deep-blue/1.webp",
                "/products/iphone-17-pro-deep-blue/2.webp",
                "/products/iphone-17-pro-deep-blue/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19 Pro", "Apple A19 Pro", "Apple A19 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.3 дюйма Super Retina XDR 2622x1206, 120 Гц", "6.3 dyuym Super Retina XDR 2622x1206, 120 Hz", "6.3 inch Super Retina XDR 2622x1206, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion тройная", "48 MP Fusion uchlik", "48 MP Fusion triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 33 ч", "33 soatgacha", "up to 33 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("206 г", "206 g", "206 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Насыщенный синий", "To'q ko'k", "Deep Blue")),
            }),

        new(
            "iphone-17-pro-max-silver",
            CatPhones, BrApple, 1199.00m, 22,
            new("iPhone 17 Pro Max, серебристый", "iPhone 17 Pro Max, kumush rang", "iPhone 17 Pro Max, Silver"),
            new(
                "6.9-дюймовый iPhone 17 Pro Max 2025 года с чипом A19 Pro, тройной камерой 48 Мп Pro Fusion и до 39 часов воспроизведения видео.",
                "2025-yilgi 6.9 dyuymli iPhone 17 Pro Max, A19 Pro chipi, 48 MP Pro Fusion uchlik kamera va 39 soatgacha video ijro etish bilan.",
                "Apple's 2025 6.9-inch iPhone 17 Pro Max with the A19 Pro chip, a triple 48 MP Pro Fusion camera system and up to 39 hours of video playback."),
            new List<string>
            {
                "/products/iphone-17-pro-max-silver/1.webp",
                "/products/iphone-17-pro-max-silver/2.webp",
                "/products/iphone-17-pro-max-silver/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19 Pro", "Apple A19 Pro", "Apple A19 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.9 дюйма Super Retina XDR 2868x1320, 120 Гц", "6.9 dyuym Super Retina XDR 2868x1320, 120 Hz", "6.9 inch Super Retina XDR 2868x1320, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion тройная", "48 MP Fusion uchlik", "48 MP Fusion triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 39 ч", "39 soatgacha", "up to 39 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("233 г", "233 g", "233 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Серебристый", "Kumush rang", "Silver")),
            }),

        new(
            "iphone-17-pro-max-cosmic-orange",
            CatPhones, BrApple, 1199.00m, 49,
            new("iPhone 17 Pro Max, космический оранжевый", "iPhone 17 Pro Max, kosmik to'q sariq", "iPhone 17 Pro Max, Cosmic Orange"),
            new(
                "6.9-дюймовый iPhone 17 Pro Max 2025 года с чипом A19 Pro, тройной камерой 48 Мп Pro Fusion и до 39 часов воспроизведения видео.",
                "2025-yilgi 6.9 dyuymli iPhone 17 Pro Max, A19 Pro chipi, 48 MP Pro Fusion uchlik kamera va 39 soatgacha video ijro etish bilan.",
                "Apple's 2025 6.9-inch iPhone 17 Pro Max with the A19 Pro chip, a triple 48 MP Pro Fusion camera system and up to 39 hours of video playback."),
            new List<string>
            {
                "/products/iphone-17-pro-max-cosmic-orange/1.webp",
                "/products/iphone-17-pro-max-cosmic-orange/2.webp",
                "/products/iphone-17-pro-max-cosmic-orange/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19 Pro", "Apple A19 Pro", "Apple A19 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.9 дюйма Super Retina XDR 2868x1320, 120 Гц", "6.9 dyuym Super Retina XDR 2868x1320, 120 Hz", "6.9 inch Super Retina XDR 2868x1320, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion тройная", "48 MP Fusion uchlik", "48 MP Fusion triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 39 ч", "39 soatgacha", "up to 39 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("233 г", "233 g", "233 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Космический оранжевый", "Kosmik to'q sariq", "Cosmic Orange")),
            }),

        new(
            "iphone-17-pro-max-deep-blue",
            CatPhones, BrApple, 1199.00m, 11,
            new("iPhone 17 Pro Max, насыщенный синий", "iPhone 17 Pro Max, to'q ko'k", "iPhone 17 Pro Max, Deep Blue"),
            new(
                "6.9-дюймовый iPhone 17 Pro Max 2025 года с чипом A19 Pro, тройной камерой 48 Мп Pro Fusion и до 39 часов воспроизведения видео.",
                "2025-yilgi 6.9 dyuymli iPhone 17 Pro Max, A19 Pro chipi, 48 MP Pro Fusion uchlik kamera va 39 soatgacha video ijro etish bilan.",
                "Apple's 2025 6.9-inch iPhone 17 Pro Max with the A19 Pro chip, a triple 48 MP Pro Fusion camera system and up to 39 hours of video playback."),
            new List<string>
            {
                "/products/iphone-17-pro-max-deep-blue/1.webp",
                "/products/iphone-17-pro-max-deep-blue/2.webp",
                "/products/iphone-17-pro-max-deep-blue/3.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19 Pro", "Apple A19 Pro", "Apple A19 Pro")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("12 ГБ", "12 GB", "12 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.9 дюйма Super Retina XDR 2868x1320, 120 Гц", "6.9 dyuym Super Retina XDR 2868x1320, 120 Hz", "6.9 inch Super Retina XDR 2868x1320, 120 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion тройная", "48 MP Fusion uchlik", "48 MP Fusion triple")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 39 ч", "39 soatgacha", "up to 39 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("233 г", "233 g", "233 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Насыщенный синий", "To'q ko'k", "Deep Blue")),
            }),

        new(
            "iphone-17e-black",
            CatPhones, BrApple, 699.00m, 29,
            new("iPhone 17e, чёрный", "iPhone 17e, qora", "iPhone 17e, Black"),
            new(
                "Базовый iPhone с дисплеем Super Retina XDR 6.1 дюйма, чипом A19, модемом Apple C1X и камерой 48 Мп Fusion. Поддерживает MagSafe, накопитель от 256 ГБ.",
                "Bazaviy iPhone: 6.1 dyuymli Super Retina XDR displey, A19 chipi, Apple C1X modemi va 48 MP Fusion kamera bilan. MagSafe ni qo'llab-quvvatlaydi, xotira 256 GB dan boshlanadi.",
                "Apple's entry iPhone with a 6.1-inch Super Retina XDR display, the A19 chip, the Apple-designed C1X modem and a 48 MP Fusion camera. It adds MagSafe and starts at 256 GB."),
            new List<string>
            {
                "/products/iphone-17e-black/1.webp",
                "/products/iphone-17e-black/2.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19", "Apple A19", "Apple A19")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.1 дюйма Super Retina XDR OLED 2532x1170, 60 Гц", "6.1 dyuym Super Retina XDR OLED 2532x1170, 60 Hz", "6.1 inch Super Retina XDR OLED 2532x1170, 60 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion одинарная", "48 MP Fusion yakka", "48 MP Fusion single")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 26 ч", "26 soatgacha", "up to 26 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("169 г", "169 g", "169 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Чёрный", "Qora", "Black")),
            }),

        new(
            "iphone-17e-white",
            CatPhones, BrApple, 699.00m, 44,
            new("iPhone 17e, белый", "iPhone 17e, oq", "iPhone 17e, White"),
            new(
                "Базовый iPhone с дисплеем Super Retina XDR 6.1 дюйма, чипом A19, модемом Apple C1X и камерой 48 Мп Fusion. Поддерживает MagSafe, накопитель от 256 ГБ.",
                "Bazaviy iPhone: 6.1 dyuymli Super Retina XDR displey, A19 chipi, Apple C1X modemi va 48 MP Fusion kamera bilan. MagSafe ni qo'llab-quvvatlaydi, xotira 256 GB dan boshlanadi.",
                "Apple's entry iPhone with a 6.1-inch Super Retina XDR display, the A19 chip, the Apple-designed C1X modem and a 48 MP Fusion camera. It adds MagSafe and starts at 256 GB."),
            new List<string>
            {
                "/products/iphone-17e-white/1.webp",
                "/products/iphone-17e-white/2.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19", "Apple A19", "Apple A19")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.1 дюйма Super Retina XDR OLED 2532x1170, 60 Гц", "6.1 dyuym Super Retina XDR OLED 2532x1170, 60 Hz", "6.1 inch Super Retina XDR OLED 2532x1170, 60 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion одинарная", "48 MP Fusion yakka", "48 MP Fusion single")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 26 ч", "26 soatgacha", "up to 26 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("169 г", "169 g", "169 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Белый", "Oq", "White")),
            }),

        new(
            "iphone-17e-soft-pink",
            CatPhones, BrApple, 699.00m, 17,
            new("iPhone 17e, нежно-розовый", "iPhone 17e, nozik pushti", "iPhone 17e, Soft Pink"),
            new(
                "Базовый iPhone с дисплеем Super Retina XDR 6.1 дюйма, чипом A19, модемом Apple C1X и камерой 48 Мп Fusion. Поддерживает MagSafe, накопитель от 256 ГБ.",
                "Bazaviy iPhone: 6.1 dyuymli Super Retina XDR displey, A19 chipi, Apple C1X modemi va 48 MP Fusion kamera bilan. MagSafe ni qo'llab-quvvatlaydi, xotira 256 GB dan boshlanadi.",
                "Apple's entry iPhone with a 6.1-inch Super Retina XDR display, the A19 chip, the Apple-designed C1X modem and a 48 MP Fusion camera. It adds MagSafe and starts at 256 GB."),
            new List<string>
            {
                "/products/iphone-17e-soft-pink/1.webp",
                "/products/iphone-17e-soft-pink/2.webp",
            },
            new List<AttributeSeed>
            {
                new("cpu", new("Процессор", "Protsessor", "CPU"), new("Apple A19", "Apple A19", "Apple A19")),
                new("ram", new("Оперативная память", "Operativ xotira", "RAM"), new("8 ГБ", "8 GB", "8 GB")),
                new("storage", new("Накопитель", "Xotira", "Storage"), new("256 ГБ", "256 GB", "256 GB")),
                new("screen", new("Экран", "Ekran", "Screen"), new("6.1 дюйма Super Retina XDR OLED 2532x1170, 60 Гц", "6.1 dyuym Super Retina XDR OLED 2532x1170, 60 Hz", "6.1 inch Super Retina XDR OLED 2532x1170, 60 Hz")),
                new("camera", new("Камера", "Kamera", "Camera"), new("48 Мп Fusion одинарная", "48 MP Fusion yakka", "48 MP Fusion single")),
                new("battery", new("Батарея", "Batareya", "Battery"), new("до 26 ч", "26 soatgacha", "up to 26 h")),
                new("weight", new("Вес", "Vazn", "Weight"), new("169 г", "169 g", "169 g")),
                new("color", new("Цвет", "Rang", "Color"), new("Нежно-розовый", "Nozik pushti", "Soft Pink")),
            }),
    };
}
