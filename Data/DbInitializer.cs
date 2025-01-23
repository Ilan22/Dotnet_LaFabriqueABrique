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
               Email = "admin@admin.com",
               Password = BCrypt.Net.BCrypt.HashPassword("admin"),
               Role = 1,
               UserLegos = new List<UserLego>()
           },
           new User {
               Name = "test",
               Email = "test@test.com",
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
                ImageUrls = new List<string> { "millennium-falcon-1.jpg", "millennium-falcon-2.jpg" }
            },
            new Lego {
                Name = "Titanic",
                Description = "Une reproduction détaillée du RMS Titanic avec intérieur visible et mécanismes fonctionnels",
                Price = 679.99M,
                Age = 18,
                NbPiece = 9090,
                ImageUrls = new List<string> { "titanic-1.jpg", "titanic-2.jpg" }
            },
            new Lego {
                Name = "Tour Eiffel",
                Description = "La plus haute construction LEGO à ce jour, reproduction fidèle du monument parisien",
                Price = 629.99M,
                Age = 18,
                NbPiece = 10001,
                ImageUrls = new List<string> { "eiffel-tower-1.jpg", "eiffel-tower-2.jpg" }
            },
            new Lego {
                Name = "Colisée",
                Description = "Le plus grand set LEGO jamais créé, reproduction de l'amphithéâtre romain",
                Price = 549.99M,
                Age = 18,
                NbPiece = 9036,
                ImageUrls = new List<string> { "colosseum-1.jpg", "colosseum-2.jpg" }
            },
            new Lego {
                Name = "Hogwarts Castle",
                Description = "Le château de Poudlard dans ses moindres détails, avec ses tours et ses salles emblématiques",
                Price = 469.99M,
                Age = 16,
                NbPiece = 6020,
                ImageUrls = new List<string> { "hogwarts-1.jpg", "hogwarts-2.jpg" }
            },
            new Lego {
                Name = "AT-AT",
                Description = "Le marcheur impérial emblématique de Star Wars, à l'échelle UCS",
                Price = 849.99M,
                Age = 18,
                NbPiece = 6785,
                ImageUrls = new List<string> { "at-at-1.jpg", "at-at-2.jpg" }
            },
            new Lego {
                Name = "Bugatti Bolide",
                Description = "Supercar Bugatti Bolide avec fonctions techniques authentiques",
                Price = 399.99M,
                Age = 18,
                NbPiece = 3599,
                ImageUrls = new List<string> { "bugatti-1.jpg", "bugatti-2.jpg" }
            },
            new Lego {
                Name = "Nintendo Entertainment System",
                Description = "Console NES rétro avec TV et Super Mario Bros",
                Price = 269.99M,
                Age = 18,
                NbPiece = 2646,
                ImageUrls = new List<string> { "nes-1.jpg", "nes-2.jpg" }
            },
            new Lego {
                Name = "Boutique de fleurs",
                Description = "Un magnifique bouquet de fleurs LEGO qui ne fane jamais",
                Price = 59.99M,
                Age = 18,
                NbPiece = 756,
                ImageUrls = new List<string> { "flower-shop-1.jpg", "flower-shop-2.jpg" }
            },
            new Lego {
                Name = "Land Rover Defender",
                Description = "4x4 emblématique avec fonctions techniques authentiques",
                Price = 239.99M,
                Age = 11,
                NbPiece = 2573,
                ImageUrls = new List<string> { "defender-1.jpg", "defender-2.jpg" }
            },
            new Lego {
                Name = "Diagon Alley",
                Description = "L'allée emblématique du monde d'Harry Potter avec ses boutiques détaillées",
                Price = 399.99M,
                Age = 16,
                NbPiece = 5544,
                ImageUrls = new List<string> { "diagon-1.jpg", "diagon-2.jpg" }
            },
                        new Lego {
                Name = "Porsche 911 RSR",
                Description = "Voiture de course Porsche avec détails aérodynamiques authentiques",
                Price = 149.99M,
                Age = 16,
                NbPiece = 1580,
                ImageUrls = new List<string> { "porsche-rsr-1.jpg", "porsche-rsr-2.jpg" }
            },
            new Lego {
                Name = "McLaren Solus GT",
                Description = "Hypercar McLaren exclusive avec aérodynamique avancée",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1,
                ImageUrls = new List<string> { "mclaren-solus-1.jpg", "mclaren-solus-2.jpg" }
            },
            new Lego {
                Name = "BMW M 1000 RR",
                Description = "Moto de course BMW avec suspension fonctionnelle",
                Price = 229.99M,
                Age = 18,
                NbPiece = 1920,
                ImageUrls = new List<string> { "bmw-m1000rr-1.jpg", "bmw-m1000rr-2.jpg" }
            },
            new Lego {
                Name = "Ferrari 812 Competizione",
                Description = "Supercar Ferrari avec V12 atmosphérique",
                Price = 239.99M,
                Age = 18,
                NbPiece = 1677,
                ImageUrls = new List<string> { "ferrari-812-1.jpg", "ferrari-812-2.jpg" }
            },
            new Lego {
                Name = "Pagani Utopia",
                Description = "Hypercar Pagani avec intérieur détaillé",
                Price = 249.99M,
                Age = 18,
                NbPiece = 1815,
                ImageUrls = new List<string> { "pagani-1.jpg", "pagani-2.jpg" }
            },
            new Lego {
                Name = "Koenigsegg Jesko",
                Description = "Hypercar suédoise avec aérodynamique active",
                Price = 179.99M,
                Age = 16,
                NbPiece = 1280,
                ImageUrls = new List<string> { "jesko-1.jpg", "jesko-2.jpg" }
            },
            new Lego {
                Name = "Ducati Panigale V4 R",
                Description = "Moto sportive Ducati avec transmission à chaîne",
                Price = 69.99M,
                Age = 18,
                NbPiece = 646,
                ImageUrls = new List<string> { "ducati-1.jpg", "ducati-2.jpg" }
            },
            new Lego {
                Name = "Peugeot 9X8 Hybrid Hypercar",
                Description = "Voiture de course d'endurance hybride",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1775,
                ImageUrls = new List<string> { "peugeot-9x8-1.jpg", "peugeot-9x8-2.jpg" }
            },
            new Lego {
                Name = "Ford GT Heritage Edition",
                Description = "Version spéciale de la Ford GT avec livrée Gulf",
                Price = 119.99M,
                Age = 18,
                NbPiece = 1466,
                ImageUrls = new List<string> { "ford-gt-1.jpg", "ford-gt-2.jpg" }
            },
            new Lego {
                Name = "Alpine A110",
                Description = "Voiture de sport française légendaire",
                Price = 89.99M,
                Age = 16,
                NbPiece = 1119,
                ImageUrls = new List<string> { "alpine-1.jpg", "alpine-2.jpg" }
            },
            new Lego {
                Name = "Lotus Evija",
                Description = "Hypercar électrique britannique",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1789,
                ImageUrls = new List<string> { "lotus-1.jpg", "lotus-2.jpg" }
            },
            new Lego {
                Name = "Porsche 963 LMDh",
                Description = "Prototype d'endurance Porsche",
                Price = 229.99M,
                Age = 18,
                NbPiece = 1876,
                ImageUrls = new List<string> { "porsche-963-1.jpg", "porsche-963-2.jpg" }
            },
            new Lego {
                Name = "Audi RS Q e-tron",
                Description = "Voiture de rallye électrique du Dakar",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1686,
                ImageUrls = new List<string> { "audi-etron-1.jpg", "audi-etron-2.jpg" }
            },
            new Lego {
                Name = "Yamaha MT-10 SP",
                Description = "Moto sportive japonaise avec détails réalistes",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1478,
                ImageUrls = new List<string> { "yamaha-mt10-1.jpg", "yamaha-mt10-2.jpg" }
            },
            new Lego {
                Name = "Batmobile Tumbler",
                Description = "La légendaire Batmobile de la trilogie Dark Knight",
                Price = 229.99M,
                Age = 18,
                NbPiece = 2049,
                ImageUrls = new List<string> { "batmobile-1.jpg", "batmobile-2.jpg" }
            },
            new Lego {
                Name = "DeLorean Time Machine",
                Description = "La voiture iconique de Retour vers le Futur",
                Price = 169.99M,
                Age = 18,
                NbPiece = 1872,
                ImageUrls = new List<string> { "delorean-1.jpg", "delorean-2.jpg" }
            },
            new Lego {
                Name = "Chevrolet Corvette C8.R",
                Description = "Voiture de course américaine légendaire",
                Price = 179.99M,
                Age = 18,
                NbPiece = 1687,
                ImageUrls = new List<string> { "corvette-1.jpg", "corvette-2.jpg" }
            },
            new Lego {
                Name = "Nissan GT-R Nismo",
                Description = "Supercar japonaise avec détails moteur",
                Price = 199.99M,
                Age = 16,
                NbPiece = 1590,
                ImageUrls = new List<string> { "gtr-1.jpg", "gtr-2.jpg" }
            },
            new Lego {
                Name = "Aprilia RSV4 Factory",
                Description = "Superbike italienne de compétition",
                Price = 189.99M,
                Age = 18,
                NbPiece = 1456,
                ImageUrls = new List<string> { "aprilia-1.jpg", "aprilia-2.jpg" }
            },
            new Lego {
                Name = "Mercedes-AMG Project ONE",
                Description = "Hypercar hybride avec technologie F1",
                Price = 399.99M,
                Age = 18,
                NbPiece = 3124,
                ImageUrls = new List<string> { "project-one-1.jpg", "project-one-2.jpg" }
            },
            new Lego {
                Name = "Aston Martin Valkyrie",
                Description = "Hypercar développée avec Red Bull Racing",
                Price = 349.99M,
                Age = 18,
                NbPiece = 2678,
                ImageUrls = new List<string> { "valkyrie-1.jpg", "valkyrie-2.jpg" }
            },
            new Lego {
                Name = "Maserati MC20",
                Description = "Supercar italienne avec moteur Nettuno",
                Price = 219.99M,
                Age = 18,
                NbPiece = 1789,
                ImageUrls = new List<string> { "mc20-1.jpg", "mc20-2.jpg" }
            },
                        new Lego {
                Name = "Château de Poudlard",
                Description = "Le château emblématique de Harry Potter avec ses tours et ses salles magiques",
                Price = 469.99M,
                Age = 16,
                NbPiece = 6020,
                ImageUrls = new List<string> { "hogwarts-castle-1.jpg", "hogwarts-castle-2.jpg" }
            },
            new Lego {
                Name = "Destroyer Stellaire Impérial",
                Description = "L'imposant vaisseau de l'Empire en version UCS",
                Price = 699.99M,
                Age = 18,
                NbPiece = 4784,
                ImageUrls = new List<string> { "star-destroyer-1.jpg", "star-destroyer-2.jpg" }
            },
            new Lego {
                Name = "Daily Bugle",
                Description = "Le building emblématique de Spider-Man avec 25 minifigurines",
                Price = 349.99M,
                Age = 18,
                NbPiece = 3772,
                ImageUrls = new List<string> { "daily-bugle-1.jpg", "daily-bugle-2.jpg" }
            },
            new Lego {
                Name = "Sanctum Sanctorum",
                Description = "Le sanctuaire du Dr Strange avec détails magiques",
                Price = 249.99M,
                Age = 18,
                NbPiece = 2708,
                ImageUrls = new List<string> { "sanctum-1.jpg", "sanctum-2.jpg" }
            },
            new Lego {
                Name = "Rivendell",
                Description = "La cité elfique du Seigneur des Anneaux",
                Price = 499.99M,
                Age = 18,
                NbPiece = 6167,
                ImageUrls = new List<string> { "rivendell-1.jpg", "rivendell-2.jpg" }
            },
            new Lego {
                Name = "Orchidée",
                Description = "Une orchidée élégante qui ne fane jamais",
                Price = 49.99M,
                Age = 18,
                NbPiece = 608,
                ImageUrls = new List<string> { "orchid-1.jpg", "orchid-2.jpg" }
            },
            new Lego {
                Name = "Maison Victorienne",
                Description = "Maison victorienne détaillée avec intérieur complet",
                Price = 199.99M,
                Age = 18,
                NbPiece = 2923,
                ImageUrls = new List<string> { "victorian-1.jpg", "victorian-2.jpg" }
            },
            new Lego {
                Name = "Station Spatiale ISS",
                Description = "Réplique détaillée de la Station Spatiale Internationale",
                Price = 69.99M,
                Age = 16,
                NbPiece = 864,
                ImageUrls = new List<string> { "iss-1.jpg", "iss-2.jpg" }
            },
            new Lego {
                Name = "Taj Mahal",
                Description = "Le monument indien emblématique en version LEGO",
                Price = 119.99M,
                Age = 18,
                NbPiece = 2022,
                ImageUrls = new List<string> { "taj-mahal-1.jpg", "taj-mahal-2.jpg" }
            },
            new Lego {
                Name = "Navire Viking",
                Description = "Drakkar viking avec voiles et boucliers détaillés",
                Price = 199.99M,
                Age = 18,
                NbPiece = 1891,
                ImageUrls = new List<string> { "viking-ship-1.jpg", "viking-ship-2.jpg" }
            },
            new Lego {
                Name = "Jurassic Park T-Rex",
                Description = "Le T-Rex et la porte iconique du film original",
                Price = 99.99M,
                Age = 14,
                NbPiece = 1212,
                ImageUrls = new List<string> { "trex-1.jpg", "trex-2.jpg" }
            },
            new Lego {
                Name = "Télescope Spatial Hubble",
                Description = "Réplique du célèbre télescope spatial",
                Price = 199.99M,
                Age = 18,
                NbPiece = 2354,
                ImageUrls = new List<string> { "hubble-1.jpg", "hubble-2.jpg" }
            },
                        new Lego {
                Name = "Boutique de Jazz",
                Description = "Club de jazz des années 30 avec détails d'époque",
                Price = 229.99M,
                Age = 18,
                NbPiece = 2899,
                ImageUrls = new List<string> { "jazz-club-1.jpg", "jazz-club-2.jpg" }
            },
            new Lego {
                Name = "Pyramides de Gizeh",
                Description = "Reproduction détaillée des pyramides égyptiennes",
                Price = 129.99M,
                Age = 18,
                NbPiece = 1476,
                ImageUrls = new List<string> { "pyramids-1.jpg", "pyramids-2.jpg" }
            },
            new Lego {
                Name = "Faucon de Combat Clone",
                Description = "Vaisseau emblématique des Guerres des Clones",
                Price = 139.99M,
                Age = 14,
                NbPiece = 1374,
                ImageUrls = new List<string> { "republic-gunship-1.jpg", "republic-gunship-2.jpg" }
            },
            new Lego {
                Name = "Groot",
                Description = "Figure articulée de Groot des Gardiens de la Galaxie",
                Price = 49.99M,
                Age = 10,
                NbPiece = 476,
                ImageUrls = new List<string> { "groot-1.jpg", "groot-2.jpg" }
            },
            new Lego {
                Name = "Bouquet de Roses",
                Description = "Bouquet de roses LEGO éternel",
                Price = 59.99M,
                Age = 18,
                NbPiece = 822,
                ImageUrls = new List<string> { "roses-1.jpg", "roses-2.jpg" }
            },
            new Lego {
                Name = "Atari 2600",
                Description = "Console de jeu rétro avec cartouche et TV",
                Price = 239.99M,
                Age = 18,
                NbPiece = 2532,
                ImageUrls = new List<string> { "atari-1.jpg", "atari-2.jpg" }
            },
            new Lego {
                Name = "Panthéon de Rome",
                Description = "Monument historique romain avec dôme détaillé",
                Price = 149.99M,
                Age = 18,
                NbPiece = 1932,
                ImageUrls = new List<string> { "pantheon-1.jpg", "pantheon-2.jpg" }
            },
            new Lego {
                Name = "Transformers Optimus Prime",
                Description = "Robot transformable en camion",
                Price = 179.99M,
                Age = 18,
                NbPiece = 1508,
                ImageUrls = new List<string> { "optimus-1.jpg", "optimus-2.jpg" }
            }
        };

        context.Legos.AddRange(legos);
        context.SaveChanges();
    }
}

