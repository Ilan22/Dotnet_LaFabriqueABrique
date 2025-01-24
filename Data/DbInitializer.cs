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
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt1cedf079c8ffbe5e/42130_Prod.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt9d0e3378606e65e9/42130_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1","https://www.lego.com/cdn/cs/set/assets/bltd700d1de3f0e0ceb/42130_alt3.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Ferrari 812 Competizione",
                Description = "Supercar Ferrari avec V12 atmosphérique",
                Price = 29.99M,
                Age = 8,
                NbPiece = 261,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt4d8e5ab570296ac1/76914.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt06b91cf49ce34198/76914_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt3bd8eecbc03bbe0f/76914_alt2.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Pagani Utopia",
                Description = "Hypercar Pagani avec intérieur détaillé",
                Price = 249.99M,
                Age = 18,
                NbPiece = 1815,
                ImageUrls = new List<string> { "https://m.media-amazon.com/images/I/71Q3PkE0GWL._AC_SY355_.jpg", "https://m.media-amazon.com/images/I/913W+XzAX4L._AC_SY355_.jpg", "https://m.media-amazon.com/images/I/81kb9JDC41L._AC_SY355_.jpg" }
            },
            new Lego {
                Name = "Koenigsegg Jesko",
                Description = "Hypercar suédoise avec aérodynamique active",
                Price = 179.99M,
                Age = 16,
                NbPiece = 1280,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/bltc4ee2c0da944140f/42173.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt08a1312044632d19/42173_boxprod_v39_sha.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltcac1079cf10a1df0/42173_WEB_SEC03_NOBG.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Ducati Panigale V4 R",
                Description = "Moto sportive Ducati avec transmission à chaîne",
                Price = 69.99M,
                Age = 18,
                NbPiece = 646,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt37acd33d80d33837/42107.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt1304449e6366b5fb/42107_alt11.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt61ed62ce0e0f3eeb/42107_alt12.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Peugeot 9X8 Hybrid Hypercar",
                Description = "Voiture de course d'endurance hybride",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1775,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt51a62f6f7514d31e/42156.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltee733e15dbb5a62f/42156_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt6ae88a9a016a8326/42156_alt10.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Ford GT Heritage Edition et Bronco R",
                Description = "Version spéciale de la Ford GT avec livrée Gulf",
                Price = 59.99M,
                Age = 12,
                NbPiece = 660,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt28b1ed7beb2e5d7f/76905.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt15a612363696eab0/76905_alt1.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt08ca49fe33a1c4a8/76905_alt2.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Lotus Evija",
                Description = "Hypercar électrique britannique",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1789,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/bltc5ffb30fa56b54ad/76907.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blta92dfacca54b0ab4/76907_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt3651408da1aadb05/76907_alt4.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Porsche 963 LMDh",
                Description = "Prototype d'endurance Porsche",
                Price = 229.99M,
                Age = 18,
                NbPiece = 1876,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt6cc4b8e0f29a4e0f/76916.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltab311109b1024f5c/76916_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltd5505d937f06f244/76916_alt4.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Audi RS Q e-tron",
                Description = "Voiture de rallye électrique du Dakar",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1686,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt0307b21e401a1e7b/42160.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blte03638f5afbc9c03/42160_boxprod_v39.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1","https://www.lego.com/cdn/cs/set/assets/bltecc311e028085371/42160_alt2.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Yamaha MT-10 SP",
                Description = "Moto sportive japonaise avec détails réalistes",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1478,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt5f2988ecb99157e2/42159.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt4a2856a67732f146/42159_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt844b0720877c5fc2/42159_alt2.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Batmobile Tumbler",
                Description = "La légendaire Batmobile de la trilogie Dark Knight",
                Price = 229.99M,
                Age = 18,
                NbPiece = 2049,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt755a6d05eac6630d/76240.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt1c14142c56a279d8/76240_alt1.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt1b2bb3f437596271/76240_alt2.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "DeLorean Time Machine",
                Description = "La voiture iconique de Retour vers le Futur",
                Price = 169.99M,
                Age = 18,
                NbPiece = 1872,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt55fbccadb7d66885/10300.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltbe274579b9f81410/10300_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltbaff735c2e263c6f/10300_alt2.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Chevrolet Corvette C8.R",
                Description = "Voiture de course américaine légendaire",
                Price = 179.99M,
                Age = 18,
                NbPiece = 1687,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/bltdf920b143d712ebc/76903.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltbb0d03467eaa0d6f/76903_box1_v39.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt22dbdad48869a538/76903_alt4.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Nissan GT-R Nismo",
                Description = "Supercar japonaise avec détails moteur",
                Price = 24.99M,
                Age = 7,
                NbPiece = 298,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt866c27d9dee0d44b/76896.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt0c7c9f0f79d836cf/76896_alt1.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltd71a8031f3e0befa/76896_alt3.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Mercedes-AMG F1 W14 E Performance",
                Description = "Hypercar hybride avec technologie F1",
                Price = 219.99M,
                Age = 18,
                NbPiece = 1643,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt2d0b04908f20c4fb/42171.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltde770d06234b6a19/42171_boxprod_v39.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltfa4fa57d225a624f/42171_alt2.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Destroyer Stellaire Impérial",
                Description = "L'imposant vaisseau de l'Empire en version UCS",
                Price = 699.99M,
                Age = 18,
                NbPiece = 4784,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt934044fa508776e2/75252.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt40f9e43bbfb9020b/75252_alt1.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt2b29c0aba14e5cf8/75252_alt4.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Daily Bugle",
                Description = "Le building emblématique de Spider-Man avec 25 minifigurines",
                Price = 349.99M,
                Age = 18,
                NbPiece = 3772,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/bltacb0c952668f6829/76178_Prod.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blteeb08eb498e43313/76178_alt1.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt9f305f3eecb794dc/76178_alt3.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Sanctum Sanctorum",
                Description = "Le sanctuaire du Dr Strange avec détails magiques",
                Price = 249.99M,
                Age = 18,
                NbPiece = 2708,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt5157080434f0c032/76218.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltd64880f2b886663a/76218_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blta20afa4f14db9f6b/76218_alt6.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Rivendell",
                Description = "La cité elfique du Seigneur des Anneaux",
                Price = 499.99M,
                Age = 18,
                NbPiece = 6167,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/bltec012c948c003fba/10316_alt16.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt33d693d46b4b5858/10316_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltf60debbc5b62ec15/10316_alt2.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Orchidée",
                Description = "Une orchidée élégante qui ne fane jamais",
                Price = 49.99M,
                Age = 18,
                NbPiece = 608,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt08ea230311e717b8/10311.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltcff040178ae498a2/10311_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltf6ac21734e2ecee2/10311_alt3.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Station Spatiale ISS",
                Description = "Réplique détaillée de la Station Spatiale Internationale",
                Price = 69.99M,
                Age = 16,
                NbPiece = 864,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt3777f348d7f98b8d/21321.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltbb6e3c005a0e09e3/21321_alt1.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blte6df7d0cf25fcd79/21321_alt2.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Taj Mahal",
                Description = "Le monument indien emblématique en version LEGO",
                Price = 119.99M,
                Age = 18,
                NbPiece = 2022,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt10cbc9ffc0459599/21056.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt7b728478abc1b1d9/21056_alt1.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltda58fab195872c05/21056_alt6.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Navire Viking",
                Description = "Drakkar viking avec voiles et boucliers détaillés",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1891,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt2ff2bbf69d86da41/31132.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt3dd16add35fa40d3/31132_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltb3ac7f3ef951694e/31132_alt3.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Jurassic Park T-Rex",
                Description = "Le T-Rex et la porte iconique du film original",
                Price = 99.99M,
                Age = 14,
                NbPiece = 1212,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt11c914dd132fd9a8/76956.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt9ade5d146a40986a/76956_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blted2784640cc6f84b/76956_alt2.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "La navette spatiale Discovery de la NASA",
                Description = "Réplique de la célèbre navette spatiale Discovery",
                Price = 199.99M,
                Age = 18,
                NbPiece = 2354,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/bltb4bcf59c441f048c/10283_Prod.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt9a603d53c81ac36a/10283_alt1.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltcca67c1f8dc499ab/10283_alt2.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Boutique de Jazz",
                Description = "Club de jazz des années 30 avec détails d'époque",
                Price = 229.99M,
                Age = 18,
                NbPiece = 2899,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt354cdb9826736318/10312.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt5f0c85240fd502ed/10312_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltb687f42c1882cfd9/10312_alt2.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Pyramides de Gizeh",
                Description = "Reproduction détaillée des pyramides égyptiennes",
                Price = 129.99M,
                Age = 18,
                NbPiece = 1476,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt29a9be6d41806916/21058.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt5669621edd1b1595/21058_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltb5bf906fd70da364/21058_alt3.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Groot",
                Description = "Figure articulée de Groot des Gardiens de la Galaxie",
                Price = 49.99M,
                Age = 10,
                NbPiece = 476,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt786d9a5e1bafd414/76217.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blt62056d2392a0ab87/76217_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltf66da9c039b84033/76217_alt3.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Bouquet de Roses",
                Description = "Bouquet de roses LEGO éternel",
                Price = 59.99M,
                Age = 18,
                NbPiece = 822,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt08f4d88d801a4cf8/10328.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltfb61c1b2fca8aa4d/10328_alt1.jpg?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/blte7ed75db19d3a25c/10328_alt2.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Atari 2600",
                Description = "Console de jeu rétro avec cartouche et TV",
                Price = 239.99M,
                Age = 18,
                NbPiece = 2532,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt10c72e2ab2785ea4/10306.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltfe23f93b1245c20f/10306_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltd2f05a06e76ab754/10306_alt2.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            },
            new Lego {
                Name = "Transformers Optimus Prime",
                Description = "Robot transformable en camion",
                Price = 179.99M,
                Age = 18,
                NbPiece = 1508,
                ImageUrls = new List<string> { "https://www.lego.com/cdn/cs/set/assets/blt36fb03cdeb25ad1a/10302.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltd20fea4f0d6663c4/10302_alt1.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1", "https://www.lego.com/cdn/cs/set/assets/bltc5122f530cff0cd7/10302_alt4.png?format=webply&fit=bounds&quality=75&width=640&height=640&dpr=1" }
            }
        };

        context.Legos.AddRange(legos);
        context.SaveChanges();
    }
}

