using System;
using System.IO;
using BattleChess3.ChessFigures;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.Core.Utilities;
using BattleChess3.DefaultFigures;
using BattleChess3.HobbitFigures;
using BattleChess3.LordOfTheRingsFigures;
using BattleChess3.SilmarillionFigures;
using Newtonsoft.Json;

namespace BattleChess3.UI.Utilities;

public static class MapCreator
{
    public static void CreateAndSaveMaps()
    {
        Directory.CreateDirectory("Resources/Maps");
        MapBlueprint[] maps = CreateDefaultMaps();
        foreach (var map in maps)
        {
            string text = JsonConvert.SerializeObject(map);
            text = CompressionHelper.Compress(text);
            File.WriteAllText(map.Path, text);
        }
    }

    private static MapBlueprint[] CreateDefaultMaps() 
        => new[]
        {
            new MapBlueprint
            {
                Figures = new FigureBlueprint[]
                {
                    (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), 
                    (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Palm.Instance), 
                    (-1, Empty.Instance), (-1, Palm.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), 
                    (-1, Empty.Instance), (1, Ninja.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance),
                    (0, Ninja.Instance), (0, Ninja.Instance), (0, Ninja.Instance), (0, Ninja.Instance), (0, Ninja.Instance), (0, Ninja.Instance), (0, Ninja.Instance), (0, Ninja.Instance),
                    (0, Ninja.Instance), (0, Ninja.Instance), (0, Ninja.Instance), (0, Ninja.Instance), (0, Ninja.Instance), (0, Ninja.Instance), (0, Ninja.Instance), (0, Ninja.Instance),
                },
                Name = "NinjaMap",
                Path = $"Resources/Maps/Ninja_{new Random().Next()}.map",
                PreviewPath = $"/Resources/MapsPreviews/Ninja_{new Random().Next()}.png",
                StartingPlayer = 0,
                PlayersCount = 2
            }, 
            new MapBlueprint
            {
                Figures = new FigureBlueprint[]
                {
                    (1, Rook.Instance), (1, Knight.Instance), (1, Bishop.Instance), (1, Queen.Instance), (1, King.Instance), (1, Bishop.Instance), (1, Knight.Instance), (1, Rook.Instance), 
                    (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance),
                    (0, Pawn.Instance), (0, Pawn.Instance), (0, Pawn.Instance), (0, Pawn.Instance), (0, Pawn.Instance), (0, Pawn.Instance), (0, Pawn.Instance), (0, Pawn.Instance),
                    (0, Rook.Instance), (0, Knight.Instance), (0, Bishop.Instance), (0, Queen.Instance), (0, King.Instance), (0, Bishop.Instance), (0, Knight.Instance), (0, Rook.Instance),
                },
                Name = "ChessMap",
                Path = $"Resources/Maps/Chess_{new Random().Next()}.map",
                PreviewPath = $"/Resources/MapsPreviews/Chess_{new Random().Next()}.png",
                StartingPlayer = 0,
                PlayersCount = 2
            }, 
            new MapBlueprint
            {
                Figures = new FigureBlueprint[]
                {
                    (1, LegolasNazgul.Instance), (1, SamSaruman.Instance), (1, PipinTroll.Instance), (1, GandalfWitchKing.Instance), (1, AragornSauron.Instance), (1, MerryTroll.Instance), (1, FrodoGollum.Instance), (1, GimliNazgul.Instance), 
                    (1, SoldierOrc.Instance), (1, SoldierOrc.Instance), (1, SoldierOrc.Instance), (1, SoldierOrc.Instance), (1, SoldierOrc.Instance), (1, SoldierOrc.Instance), (1, SoldierOrc.Instance), (1, SoldierOrc.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance),
                    (0, SoldierOrc.Instance), (0, SoldierOrc.Instance), (0, SoldierOrc.Instance), (0, SoldierOrc.Instance), (0, SoldierOrc.Instance), (0, SoldierOrc.Instance), (0, SoldierOrc.Instance), (0, SoldierOrc.Instance),
                    (0, LegolasNazgul.Instance), (0, SamSaruman.Instance), (0, PipinTroll.Instance), (0, GandalfWitchKing.Instance), (0, AragornSauron.Instance), (0, MerryTroll.Instance), (0, FrodoGollum.Instance), (0, GimliNazgul.Instance),
                },
                Name = "LOTRMap",
                Path = $"Resources/Maps/LOTR_{new Random().Next()}.map",
                PreviewPath = $"/Resources/MapsPreviews/LOTR_{new Random().Next()}.png",
                StartingPlayer = 0,
                PlayersCount = 2
            }, 
            new MapBlueprint
            {
                Figures = new FigureBlueprint[]
                {
                    (1, MinorWizard.Instance), (1, Warrior.Instance), (1, Helper.Instance), (1, RingBearer.Instance), (1, Leader.Instance), (1, Helper.Instance), (1, Warrior.Instance), (1, MinorWizard.Instance), 
                    (1, Soldier.Instance), (1, Soldier.Instance), (1, Soldier.Instance), (1, Soldier.Instance), (1, Soldier.Instance), (1, Soldier.Instance), (1, Soldier.Instance), (1, Soldier.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance),
                    (0, Soldier.Instance), (0, Soldier.Instance), (0, Soldier.Instance), (0, Soldier.Instance), (0, Soldier.Instance), (0, Soldier.Instance), (0, Soldier.Instance), (0, Soldier.Instance),
                    (0, MinorWizard.Instance), (0, Warrior.Instance), (0, Helper.Instance), (0, RingBearer.Instance), (0, Leader.Instance), (0, Helper.Instance), (0, Warrior.Instance), (0, MinorWizard.Instance),
                },
                Name = "HobbitMap",
                Path = $"Resources/Maps/Hobbit_{new Random().Next()}.map",
                PreviewPath = $"/Resources/MapsPreviews/Hobbit_{new Random().Next()}.png",
                StartingPlayer = 0,
                PlayersCount = 2
            }, 
            new MapBlueprint
            {
                Figures = new FigureBlueprint[]
                {
                    (1, UlmoAncalagon.Instance), (1, IrmoUngoliant.Instance), (1, NiennaBalrog.Instance), (1, YavannaGlaurung.Instance), (1, ManweMelkor.Instance), (1, AuleGothmog.Instance), (1, VardaSauron.Instance), (1, OromeCarcharoth.Instance), 
                    (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), 
                    (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance), (-1, Empty.Instance),
                    (0, ElfOrc.Instance), (0, ElfOrc.Instance), (0, ElfOrc.Instance), (0, ElfOrc.Instance), (0, ElfOrc.Instance), (0, ElfOrc.Instance), (0, ElfOrc.Instance), (0, ElfOrc.Instance),
                    (0, UlmoAncalagon.Instance), (0, IrmoUngoliant.Instance), (0, NiennaBalrog.Instance), (0, YavannaGlaurung.Instance), (0, ManweMelkor.Instance), (0, AuleGothmog.Instance), (0, VardaSauron.Instance), (0, OromeCarcharoth.Instance),
                },
                Name = "SilmarillionMap",
                Path = $"Resources/Maps/Silmarillion_{new Random().Next()}.map",
                PreviewPath = $"/Resources/MapsPreviews/Silmarillion_{new Random().Next()}.png",
                StartingPlayer = 0,
                PlayersCount = 2
            }, 
        };
}
