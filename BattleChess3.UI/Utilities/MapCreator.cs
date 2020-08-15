using System;
using System.IO;
using BattleChess3.ChessFigures;
using BattleChess3.Core.Models;
using BattleChess3.Core.Utilities;
using BattleChess3.DefaultFigures;
using BattleChess3.HobbitFigures;
using BattleChess3.LordOfTheRingsFigures;
using BattleChess3.SilmarillionFigures;
using Newtonsoft.Json;

namespace BattleChess3.UI.Utilities
{
    public static class MapCreator
    {
        public static void CreateAndSaveMaps()
        {
            MapBlueprint[] maps = CreateDefaultMaps();
            foreach (var map in maps)
            {
                string text = JsonConvert.SerializeObject(map);
                text = CompressionHelper.Compress(text);
                File.WriteAllText(map.Path, text);
            }
        }

        private static  MapBlueprint[] CreateDefaultMaps() 
            => new[]
            {
                new MapBlueprint
                {
                    Blueprint = new FigureBlueprint[]
                    {
                        (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), 
                        (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Palm.Instance), 
                        (0, Empty.Instance), (0, Palm.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), 
                        (0, Empty.Instance), (2, Ninja.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                        (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance),
                        (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance),
                    },
                    Name = "NinjaMap",
                    Path = $"Resources/Maps/Ninja_{new Random().Next()}.map",
                    PreviewPath = $"/Resources/MapsPreviews/Ninja_{new Random().Next()}.png",
                    StartingPlayer = 1,
                    PlayersCount = 2
                }, 
                new MapBlueprint
                {
                    Blueprint = new FigureBlueprint[]
                    {
                        (2, Rook.Instance), (2, Knight.Instance), (2, Bishop.Instance), (2, Queen.Instance), (2, King.Instance), (2, Bishop.Instance), (2, Knight.Instance), (2, Rook.Instance), 
                        (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                        (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance),
                        (1, Rook.Instance), (1, Knight.Instance), (1, Bishop.Instance), (1, Queen.Instance), (1, King.Instance), (1, Bishop.Instance), (1, Knight.Instance), (1, Rook.Instance),
                    },
                    Name = "ChessMap",
                    Path = $"Resources/Maps/Chess_{new Random().Next()}.map",
                    PreviewPath = $"/Resources/MapsPreviews/Chess_{new Random().Next()}.png",
                    StartingPlayer = 1,
                    PlayersCount = 2
                }, 
                new MapBlueprint
                {
                    Blueprint = new FigureBlueprint[]
                    {
                        (2, LegolasNazgul.Instance), (2, SamSaruman.Instance), (2, PipinTroll.Instance), (2, GandalfWitchKing.Instance), (2, AragornSauron.Instance), (2, MerryTroll.Instance), (2, FrodoGollum.Instance), (2, GimliNazgul.Instance), 
                        (2, SoldierOrc.Instance), (2, SoldierOrc.Instance), (2, SoldierOrc.Instance), (2, SoldierOrc.Instance), (2, SoldierOrc.Instance), (2, SoldierOrc.Instance), (2, SoldierOrc.Instance), (2, SoldierOrc.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                        (1, SoldierOrc.Instance), (1, SoldierOrc.Instance), (1, SoldierOrc.Instance), (1, SoldierOrc.Instance), (1, SoldierOrc.Instance), (1, SoldierOrc.Instance), (1, SoldierOrc.Instance), (1, SoldierOrc.Instance),
                        (1, LegolasNazgul.Instance), (1, SamSaruman.Instance), (1, PipinTroll.Instance), (1, GandalfWitchKing.Instance), (1, AragornSauron.Instance), (1, MerryTroll.Instance), (1, FrodoGollum.Instance), (1, GimliNazgul.Instance),
                    },
                    Name = "LOTRMap",
                    Path = $"Resources/Maps/LOTR_{new Random().Next()}.map",
                    PreviewPath = $"/Resources/MapsPreviews/LOTR_{new Random().Next()}.png",
                    StartingPlayer = 1,
                    PlayersCount = 2
                }, 
                new MapBlueprint
                {
                    Blueprint = new FigureBlueprint[]
                    {
                        (2, MinorWizard.Instance), (2, Warrior.Instance), (2, Helper.Instance), (2, RingBearer.Instance), (2, Leader.Instance), (2, Helper.Instance), (2, Warrior.Instance), (2, MinorWizard.Instance), 
                        (2, Soldier.Instance), (2, Soldier.Instance), (2, Soldier.Instance), (2, Soldier.Instance), (2, Soldier.Instance), (2, Soldier.Instance), (2, Soldier.Instance), (2, Soldier.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                        (1, Soldier.Instance), (1, Soldier.Instance), (1, Soldier.Instance), (1, Soldier.Instance), (1, Soldier.Instance), (1, Soldier.Instance), (1, Soldier.Instance), (1, Soldier.Instance),
                        (1, MinorWizard.Instance), (1, Warrior.Instance), (1, Helper.Instance), (1, RingBearer.Instance), (1, Leader.Instance), (1, Helper.Instance), (1, Warrior.Instance), (1, MinorWizard.Instance),
                    },
                    Name = "HobbitMap",
                    Path = $"Resources/Maps/Hobbit_{new Random().Next()}.map",
                    PreviewPath = $"/Resources/MapsPreviews/Hobbit_{new Random().Next()}.png",
                    StartingPlayer = 1,
                    PlayersCount = 2
                }, 
                new MapBlueprint
                {
                    Blueprint = new FigureBlueprint[]
                    {
                        (2, AuleGothmog.Instance), (2, IrmoUngoliant.Instance), (2, NiennaBalrog.Instance), (2, YavannaGlaurung.Instance), (2, ManweMelkor.Instance), (2, UlmoAncalagon.Instance), (2, OromeCarcharoth.Instance), (2, OromeCarcharoth.Instance), 
                        (2, ElfOrc.Instance), (2, ElfOrc.Instance), (2, ElfOrc.Instance), (2, ElfOrc.Instance), (2, ElfOrc.Instance), (2, ElfOrc.Instance), (2, ElfOrc.Instance), (2, ElfOrc.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), 
                        (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                        (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance),
                        (1, AuleGothmog.Instance), (1, IrmoUngoliant.Instance), (1, NiennaBalrog.Instance), (1, YavannaGlaurung.Instance), (1, ManweMelkor.Instance), (1, UlmoAncalagon.Instance), (1, OromeCarcharoth.Instance), (1, OromeCarcharoth.Instance),
                    },
                    Name = "SilmarillionMap",
                    Path = $"Resources/Maps/Silmarillion_{new Random().Next()}.map",
                    PreviewPath = $"/Resources/MapsPreviews/Silmarillion_{new Random().Next()}.png",
                    StartingPlayer = 1,
                    PlayersCount = 2
                }, 
            };
    }
}