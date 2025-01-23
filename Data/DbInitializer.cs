using LaFabriqueaBriques.Models;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Users.Any()) return;

        var users = new List<User>
       {
           new User {
               Name = "Admin",
               Email = "admin@admin.fr",
               Password = BCrypt.Net.BCrypt.HashPassword("admin"),
               Role = 1,
               UserLegos = new List<UserLego>()
           },
           new User {
               Name = "test",
               Email = "test@test.fr",
               Password = BCrypt.Net.BCrypt.HashPassword("test"),
               Role = 0,
               UserLegos = new List<UserLego>()
           }
       };

        context.Users.AddRange(users);
        context.SaveChanges();

        if (context.Legos.Any()) return;

        var legos = new List<Lego>
        {
            new Lego {
                Name = "Millennium Falcon",
                Description = "Le Faucon Millenium iconique de Star Wars, avec ses détails incroyables et son intérieur accessible",
                Price = 849.99M,
                Age = 16,
                NbPiece = 7541,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt3349f56c6f192e18/75192_Prod.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blte22f1f8d1cacfb3c/75192_alt1.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltecd03cc9fb82fd56/75192_alt2.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1" }
            },
            new Lego {
                Name = "Titanic",
                Description = "Une reproduction détaillée du RMS Titanic avec intérieur visible et mécanismes fonctionnels",
                Price = 679.99M,
                Age = 18,
                NbPiece = 9090,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt6cdf0b53146b5519/10294_Prod.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt4970f39471f38330/10294_alt1.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt106cc94abfc29747/10294_alt2.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1" }
            },
            new Lego {
                Name = "Tour Eiffel",
                Description = "Célèbre monument parisien",
                Price = 629.99M,
                Age = 18,
                NbPiece = 10001,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt0e2b04c977a2dc2a/10307.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt95b2930fbcf9ea6b/10307_alt1.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt1e7cec4d1ff93e05/10307_alt2.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1" }
            },
            new Lego {
                Name = "Colisée",
                Description = "Amphithéâtre antique de Rome",
                Price = 549.99M,
                Age = 18,
                NbPiece = 9036,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt7c4044f7aa529af3/10276_alt2.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt26cc4dd7f5cf656e/10276_alt1.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt5040546f8d1c4614/10276_alt3.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1" }
            },
            new Lego {
                Name = "Hogwarts Castle",
                Description = "Le château de Poudlard dans ses moindres détails, avec ses tours et ses salles emblématiques",
                Price = 469.99M,
                Age = 16,
                NbPiece = 6020,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt51ff6bf5627b4161/71043_Prod.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt08668e770aaef16e/71043_alt1.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltc7cfefbb0fb5d187/71043_alt2.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1" }
            },
            new Lego {
                Name = "AT-AT",
                Description = "Le marcheur impérial emblématique de Star Wars, à l'échelle UCS",
                Price = 849.99M,
                Age = 18,
                NbPiece = 6785,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blta7b7b825b6d4fc0a/75313_Prod.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt2c75f7c81f1e3871/75313_Box1_v29.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt780cb78aa3a31878/75313_Front_01.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1" }
            },
            new Lego {
                Name = "Bugatti Chiron",
                Description = "Supercar Bugatti Chiron avec fonctions techniques authentiques",
                Price = 399.99M,
                Age = 18,
                NbPiece = 3599,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/bltd13aa93d1b640045/42083.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt6040a37536fc0fb0/42083_alt1.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt7fa3b10249c0c359/42083_alt3.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1" }
            },
            new Lego {
                Name = "Nintendo Entertainment System",
                Description = "Console NES rétro avec TV et Super Mario Bros",
                Price = 269.99M,
                Age = 18,
                NbPiece = 2646,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/bltb832528f1086d663/71374_Prod.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt04d5ccb47fe9d344/71374_alt1.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt9e95d152331bbdb0/71374_alt2.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1" }
            },
            new Lego {
                Name = "Boutique de fleurs",
                Description = "Un magnifique bouquet de fleurs LEGO qui ne fane jamais",
                Price = 59.99M,
                Age = 18,
                NbPiece = 756,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt1fcd33bf2c57d3af/40680_Prod.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt21ad7998c54c4d52/40680_Box1_v39.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt17fc894923e857f5/40680_Lifestyle_envr.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1" }
            },
            new Lego {
                Name = "Land Rover Defender",
                Description = "4x4 emblématique avec fonctions techniques authentiques",
                Price = 239.99M,
                Age = 11,
                NbPiece = 2573,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt543edb31db6e8889/42110.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt20d8302a2a25ce81/42110_alt1.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltddafff2717e85efc/42110_alt3.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1" }
            },
            new Lego {
                Name = "Diagon Alley",
                Description = "L'allée emblématique du monde d'Harry Potter avec ses boutiques détaillées",
                Price = 399.99M,
                Age = 16,
                NbPiece = 5544,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt29665a16eab960f8/75978_Prod_01.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt1b28dfd6986bd810/75978_alt1.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt7f0efe2ca85f3e30/75978_alt2.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1" }
            },
            new Lego {
                Name = "Porsche 911 RSR",
                Description = "Voiture de course Porsche avec détails aérodynamiques authentiques",
                Price = 149.99M,
                Age = 16,
                NbPiece = 1580,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/bltbad5cceab306b542/42096_Prod.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt4b29872a79de8bf6/42096_alt1.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt276fd994a44edd09/42096_alt2.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1" }
            },
            new Lego {
                Name = "McLaren P1",
                Description = "Hypercar McLaren exclusive avec aérodynamique avancée",
                Price = 499.99M,
                Age = 18,
                NbPiece = 3893,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt519dac201a3dd4c1/42172.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltaf11a3ec76040cc5/42172_boxprod_v39_sha.jpg?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt47d395554821fc00/42172_Back_01.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1" }
            },
            new Lego {
                Name = "BMW M 1000 RR",
                Description = "Moto de course BMW avec suspension fonctionnelle",
                Price = 229.99M,
                Age = 18,
                NbPiece = 1920,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Ferrari 812 Competizione",
                Description = "Supercar Ferrari avec V12 atmosphérique",
                Price = 239.99M,
                Age = 18,
                NbPiece = 1677,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Pagani Utopia",
                Description = "Hypercar Pagani avec intérieur détaillé",
                Price = 249.99M,
                Age = 18,
                NbPiece = 1815,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Koenigsegg Jesko",
                Description = "Hypercar suédoise avec aérodynamique active",
                Price = 179.99M,
                Age = 16,
                NbPiece = 1280,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Ducati Panigale V4 R",
                Description = "Moto sportive Ducati avec transmission à chaîne",
                Price = 69.99M,
                Age = 18,
                NbPiece = 646,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Peugeot 9X8 Hybrid Hypercar",
                Description = "Voiture de course d'endurance hybride",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1775,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Ford GT Heritage Edition",
                Description = "Version spéciale de la Ford GT avec livrée Gulf",
                Price = 119.99M,
                Age = 18,
                NbPiece = 1466,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Alpine A110",
                Description = "Voiture de sport française légendaire",
                Price = 89.99M,
                Age = 16,
                NbPiece = 1119,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Lotus Evija",
                Description = "Hypercar électrique britannique",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1789,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Porsche 963 LMDh",
                Description = "Prototype d'endurance Porsche",
                Price = 229.99M,
                Age = 18,
                NbPiece = 1876,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Audi RS Q e-tron",
                Description = "Voiture de rallye électrique du Dakar",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1686,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Yamaha MT-10 SP",
                Description = "Moto sportive japonaise avec détails réalistes",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1478,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Batmobile Tumbler",
                Description = "La légendaire Batmobile de la trilogie Dark Knight",
                Price = 229.99M,
                Age = 18,
                NbPiece = 2049,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "DeLorean Time Machine",
                Description = "La voiture iconique de Retour vers le Futur",
                Price = 169.99M,
                Age = 18,
                NbPiece = 1872,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Chevrolet Corvette C8.R",
                Description = "Voiture de course américaine légendaire",
                Price = 179.99M,
                Age = 18,
                NbPiece = 1687,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Nissan GT-R Nismo",
                Description = "Supercar japonaise avec détails moteur",
                Price = 199.99M,
                Age = 16,
                NbPiece = 1590,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Aprilia RSV4 Factory",
                Description = "Superbike italienne de compétition",
                Price = 189.99M,
                Age = 18,
                NbPiece = 1456,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Mercedes-AMG Project ONE",
                Description = "Hypercar hybride avec technologie F1",
                Price = 399.99M,
                Age = 18,
                NbPiece = 3124,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Aston Martin Valkyrie",
                Description = "Hypercar développée avec Red Bull Racing",
                Price = 349.99M,
                Age = 18,
                NbPiece = 2678,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Maserati MC20",
                Description = "Supercar italienne avec moteur Nettuno",
                Price = 219.99M,
                Age = 18,
                NbPiece = 1789,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Château de Poudlard",
                Description = "Le château emblématique de Harry Potter avec ses tours et ses salles magiques",
                Price = 469.99M,
                Age = 16,
                NbPiece = 6020,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Destroyer Stellaire Impérial",
                Description = "L'imposant vaisseau de l'Empire en version UCS",
                Price = 699.99M,
                Age = 18,
                NbPiece = 4784,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Daily Bugle",
                Description = "Le building emblématique de Spider-Man avec 25 minifigurines",
                Price = 349.99M,
                Age = 18,
                NbPiece = 3772,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Sanctum Sanctorum",
                Description = "Le sanctuaire du Dr Strange avec détails magiques",
                Price = 249.99M,
                Age = 18,
                NbPiece = 2708,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Rivendell",
                Description = "La cité elfique du Seigneur des Anneaux",
                Price = 499.99M,
                Age = 18,
                NbPiece = 6167,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Orchidée",
                Description = "Une orchidée élégante qui ne fane jamais",
                Price = 49.99M,
                Age = 18,
                NbPiece = 608,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Maison Victorienne",
                Description = "Maison victorienne détaillée avec intérieur complet",
                Price = 199.99M,
                Age = 18,
                NbPiece = 2923,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Station Spatiale ISS",
                Description = "Réplique détaillée de la Station Spatiale Internationale",
                Price = 69.99M,
                Age = 16,
                NbPiece = 864,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Taj Mahal",
                Description = "Le monument indien emblématique en version LEGO",
                Price = 119.99M,
                Age = 18,
                NbPiece = 2022,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Navire Viking",
                Description = "Drakkar viking avec voiles et boucliers détaillés",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1891,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Jurassic Park T-Rex",
                Description = "Le T-Rex et la porte iconique du film original",
                Price = 99.99M,
                Age = 14,
                NbPiece = 1212,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Télescope Spatial Hubble",
                Description = "Réplique du célèbre télescope spatial",
                Price = 199.99M,
                Age = 18,
                NbPiece = 2354,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Boutique de Jazz",
                Description = "Club de jazz des années 30 avec détails d'époque",
                Price = 229.99M,
                Age = 18,
                NbPiece = 2899,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Pyramides de Gizeh",
                Description = "Reproduction détaillée des pyramides égyptiennes",
                Price = 129.99M,
                Age = 18,
                NbPiece = 1476,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Faucon de Combat Clone",
                Description = "Vaisseau emblématique des Guerres des Clones",
                Price = 139.99M,
                Age = 14,
                NbPiece = 1374,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Groot",
                Description = "Figure articulée de Groot des Gardiens de la Galaxie",
                Price = 49.99M,
                Age = 10,
                NbPiece = 476,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Bouquet de Roses",
                Description = "Bouquet de roses LEGO éternel",
                Price = 59.99M,
                Age = 18,
                NbPiece = 822,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Atari 2600",
                Description = "Console de jeu rétro avec cartouche et TV",
                Price = 239.99M,
                Age = 18,
                NbPiece = 2532,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Panthéon de Rome",
                Description = "Monument historique romain avec dôme détaillé",
                Price = 149.99M,
                Age = 18,
                NbPiece = 1932,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            },
            new Lego {
                Name = "Transformers Optimus Prime",
                Description = "Robot transformable en camion",
                Price = 179.99M,
                Age = 18,
                NbPiece = 1508,
                ImageUrls = new List<string> { "https://thumbs.dreamstime.com/b/timbre-de-travail-en-cours-dans-le-style-caoutchouc-102071784.jpg" }
            }
        };

        context.Legos.AddRange(legos);
        context.SaveChanges();
    }
}

