using System;
using System.IO;
using BattleChess3.DisneyFigures;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.Core.Utilities;
using BattleChess3.CrossFireFigures;
using BattleChess3.DefaultFigures;
using BattleChess3.HobbitFigures;
using BattleChess3.LordOfTheRingsFigures;
using BattleChess3.SilmarillionFigures;
using Newtonsoft.Json;

namespace BattleChess3.UI.Utilities;

public static class MapCreator
{
    public static void CreateCrossfireMap()
    {
        CreateMap(new MapBlueprint
        {
            Figures = new FigureBlueprint[]
                {
                    (2, Builder.Instance), (2, CrossFireFigures.Knight.Instance), (2, Archer.Instance), (2, Bomber.Instance), (2, Spy.Instance), (2, Archer.Instance), (2, CrossFireFigures.Knight.Instance), (2, Builder.Instance),
                    (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance), (2, Ninja.Instance),
                    (2, Wall.Instance), (2, Wall.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (2, Wall.Instance), (2, Wall.Instance),
                    (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                    (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                    (1, Wall.Instance), (1, Wall.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (1, Wall.Instance), (1, Wall.Instance),
                    (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance), (1, Ninja.Instance),
                    (1, Builder.Instance), (1, CrossFireFigures.Knight.Instance), (1, Archer.Instance), (1, Bomber.Instance), (1, Spy.Instance), (1, Archer.Instance), (1, CrossFireFigures.Knight.Instance), (1, Builder.Instance),
                },
            MapPath = $"Resources/Maps/Ninja_{new Random().Next()}.map",
            PreviewPath = $"/Resources/Maps/Ninja_{new Random().Next()}.png",
            StartingPlayer = 1,
        });
    }

    public static void CreateLOTRMap()
    {
        CreateMap(new MapBlueprint
        {
            Figures = new FigureBlueprint[]
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
            MapPath = $"Resources/Maps/LOTR_{new Random().Next()}.map",
            PreviewPath = $"/Resources/Maps/LOTR_{new Random().Next()}.png",
            StartingPlayer = 1,
        });
    }

    public static void CreateHobbitMap()
    {
        CreateMap(new MapBlueprint
        {
            Figures = new FigureBlueprint[]
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
            MapPath = $"Resources/Maps/Hobbit_{new Random().Next()}.map",
            PreviewPath = $"/Resources/Maps/Hobbit_{new Random().Next()}.png",
            StartingPlayer = 1,
        });
    }

    public static void CreateSilmarillionMap()
    {
        CreateMap(new MapBlueprint
        {
            Figures = new FigureBlueprint[]
                {
                    (2, UlmoAncalagon.Instance), (2, IrmoUngoliant.Instance), (2, NiennaBalrog.Instance), (2, YavannaGlaurung.Instance), (2, ManweMelkor.Instance), (2, AuleGothmog.Instance), (2, VardaSauron.Instance), (2, OromeCarcharoth.Instance),
                    (2, ElfOrc.Instance), (2, ElfOrc.Instance), (2, ElfOrc.Instance), (2, ElfOrc.Instance), (2, ElfOrc.Instance), (2, ElfOrc.Instance), (2, ElfOrc.Instance), (2, ElfOrc.Instance),
                    (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                    (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                    (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                    (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                    (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance), (1, ElfOrc.Instance),
                    (1, UlmoAncalagon.Instance), (1, IrmoUngoliant.Instance), (1, NiennaBalrog.Instance), (1, YavannaGlaurung.Instance), (1, ManweMelkor.Instance), (1, AuleGothmog.Instance), (1, VardaSauron.Instance), (1, OromeCarcharoth.Instance),
                },
            MapPath = $"Resources/Maps/Silmarillion_{new Random().Next()}.map",
            PreviewPath = $"/Resources/Maps/Silmarillion_{new Random().Next()}.png",
            StartingPlayer = 1,
        });
    }

    public static void CreateChessMap()
    {
        CreateMap(new MapBlueprint
        {
            Figures = new FigureBlueprint[]
                {
                    (2, Rook.Instance), (2, DisneyFigures.Knight.Instance), (2, Bishop.Instance), (2, Queen.Instance), (2, King.Instance), (2, Bishop.Instance), (2, DisneyFigures.Knight.Instance), (2, Rook.Instance),
                    (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance),
                    (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                    (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                    (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                    (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                    (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance),
                    (1, Rook.Instance), (1, DisneyFigures.Knight.Instance), (1, Bishop.Instance), (1, Queen.Instance), (1, King.Instance), (1, Bishop.Instance), (1, DisneyFigures.Knight.Instance), (1, Rook.Instance),
                },
            MapPath = $"Resources/Maps/Chess_{new Random().Next()}.map",
            PreviewPath = $"/Resources/Maps/Chess_{new Random().Next()}.png",
            StartingPlayer = 1,
        });
    }

    public static void CreateChess2Map()
    {
        CreateMap(new MapBlueprint
        {
            Figures = new FigureBlueprint[]
                {
                    (2, Rook.Instance), (2, DisneyFigures.Knight.Instance), (2, Bishop.Instance), (2, Queen.Instance), (2, King.Instance), (2, Bishop.Instance), (2, DisneyFigures.Knight.Instance), (2, Rook.Instance),
                    (2, Spy.Instance), (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance), (2, Pawn.Instance),
                    (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                    (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                    (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                    (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance), (0, Empty.Instance),
                    (1, Spy.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance), (1, Pawn.Instance),
                    (1, Rook.Instance), (1, DisneyFigures.Knight.Instance), (1, Bishop.Instance), (1, Queen.Instance), (1, King.Instance), (1, Bishop.Instance), (1, DisneyFigures.Knight.Instance), (1, Rook.Instance),
                },
            MapPath = $"Resources/Maps/Chess_{new Random().Next()}.map",
            PreviewPath = $"/Resources/Maps/Chess_{new Random().Next()}.png",
            StartingPlayer = 1,
        });
    }

    private static void CreateMap(MapBlueprint map)
    {
        Directory.CreateDirectory("Resources/Maps");
        string text = JsonConvert.SerializeObject(map);
        text = CompressionHelper.Compress(text);
        File.WriteAllText(map.MapPath, text);
    }
}
