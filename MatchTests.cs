using Moq;
using RepartitionTournoi.DAL.Entities;
using RepartitionTournoi.DAL.Interfaces;
using RepartitionTournoi.Domain.Interfaces;
using RepartitionTournoi.Models;
using Match = RepartitionTournoi.DAL.Entities.Match;

namespace RepartitionTournoi.Domain.Unit.Tests
{
    public class MatchTests
    {
        [Fact]
        public void InitializeBurndownChartLines_Should_Return_11BurndownChartLines()
        {
            //Arrange
            int tournoiId = 1;
            var matchDAL = new Mock<IMatchDAL>();
            var tournoiDAL = new Mock<ITournoiDAL>();
            tournoiDAL.Setup(x => x.GetById(tournoiId)).Returns(GetFakeTournoi());
            IMatchDomain domain = new MatchDomain(matchDAL.Object, tournoiDAL.Object);
            var expectedBurndownChartLines = GetExpectedBurndownChartLines();
            //Act
            var actualBurndownChartLines = domain.InitializeBurndownChartLines(tournoiId);
            //Assert
            Assert.Equivalent(expectedBurndownChartLines, actualBurndownChartLines);
        }
        [Fact]
        public void GetBurndownChartLineDTOs_Should_Return_11BurndownChartLines()
        {
            //Arrange
            int tournoiId = 1;
            var matchDAL = new Mock<IMatchDAL>();
            matchDAL.Setup(x => x.GetAll()).Returns(GetFakeMatchs());
            var tournoiDAL = new Mock<ITournoiDAL>();
            tournoiDAL.Setup(x => x.GetById(tournoiId)).Returns(GetFakeTournoi());
            IMatchDomain domain = new MatchDomain(matchDAL.Object, tournoiDAL.Object);
            var expectedBurndownChartLines = GetExpectedBurndownChartLinesWithActual();

            //Act
            var actualBurndownChartLines = domain.GetBurndownChartLineDTOs(tournoiId);

            //Assert
            Assert.Equivalent(expectedBurndownChartLines, actualBurndownChartLines);
        }
        private List<BurndownChartLineDTO> GetExpectedBurndownChartLines()
        {
            return new List<BurndownChartLineDTO>()
            {
                new BurndownChartLineDTO("2022 W40",40,40),
                new BurndownChartLineDTO("2022 W41",36,41),
                new BurndownChartLineDTO("2022 W42",32,42),
                new BurndownChartLineDTO("2022 W43",28,43),
                new BurndownChartLineDTO("2022 W44",24,44),
                new BurndownChartLineDTO("2022 W45",20,45),
                new BurndownChartLineDTO("2022 W46",16,46),
                new BurndownChartLineDTO("2022 W47",12,47),
                new BurndownChartLineDTO("2022 W48",8,48),
                new BurndownChartLineDTO("2022 W49",4,49),
                new BurndownChartLineDTO("2022 W50",0,50)
            };
        }
        private List<BurndownChartLineDTO> GetExpectedBurndownChartLinesWithActual()
        {
            return new List<BurndownChartLineDTO>()
            {
                new BurndownChartLineDTO("2022 W40",40,40){actual = 3},
                new BurndownChartLineDTO("2022 W41",36,41){actual = 6},
                new BurndownChartLineDTO("2022 W42",32,42){actual = 8},
                new BurndownChartLineDTO("2022 W43",28,43){actual = 12},
                new BurndownChartLineDTO("2022 W44",24,44),
                new BurndownChartLineDTO("2022 W45",20,45),
                new BurndownChartLineDTO("2022 W46",16,46),
                new BurndownChartLineDTO("2022 W47",12,47),
                new BurndownChartLineDTO("2022 W48",8,48),
                new BurndownChartLineDTO("2022 W49",4,49),
                new BurndownChartLineDTO("2022 W50",0,50)
            };
        }
        private Tournoi GetFakeTournoi()
        {
            Tournoi tournoi = new Tournoi()
            {
                DateDebut = new DateTime(2022, 10, 3),
                DateFin = new DateTime(2022, 12, 18),
                Compositions = new List<Composition>()
                {
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="1"},Match = new Match(){ Id=81 , Nom="Match 1"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="1"},Match = new Match(){ Id=82 , Nom="Match 2",DateFin= new DateTime(2022,10,26)} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="1"},Match = new Match(){ Id=83 , Nom="Match 3" } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="1"},Match = new Match(){ Id=84 , Nom="Match 4",DateFin=new DateTime(2022,10,15) } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="2"},Match = new Match(){ Id=85 , Nom="Match 1",DateFin=new DateTime(2022,10,7) } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="2"},Match = new Match(){ Id=86 , Nom="Match 2" } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="2"},Match = new Match(){ Id=87 , Nom="Match 3"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="2"},Match = new Match(){ Id=88 , Nom="Match 4",DateFin=new DateTime(2022,10,14) } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="3"},Match = new Match(){ Id=89 , Nom="Match 1", DateFin = new DateTime(2022,10,21) } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="3"},Match = new Match(){ Id=90 , Nom="Match 2" } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="3"},Match = new Match(){ Id=91 , Nom="Match 3", DateFin = new DateTime(2022,10,14) } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="3"},Match = new Match(){ Id=92 , Nom="Match 4" } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="4"},Match = new Match(){ Id=93 , Nom="Match 1", DateFin = new DateTime(2022,10,07) } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="4"},Match = new Match(){ Id=94 , Nom="Match 2" } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="4"},Match = new Match(){ Id=95 , Nom="Match 3", DateFin = new DateTime(2022,10,07) } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="4"},Match = new Match(){ Id=96 , Nom="Match 4" } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="5"},Match = new Match(){ Id=97 , Nom="Match 1"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="5"},Match = new Match(){ Id=98 , Nom="Match 2"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="5"},Match = new Match(){ Id=99 , Nom="Match 3"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="5"},Match = new Match(){ Id=100, Nom="Match 4", DateFin = new DateTime(2022,10 , 28) } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="6"},Match = new Match(){ Id=101, Nom="Match 1" } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="6"},Match = new Match(){ Id=102, Nom="Match 2"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="6"},Match = new Match(){ Id=103, Nom="Match 3"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="6"},Match = new Match(){ Id=104, Nom="Match 4"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="7"},Match = new Match(){ Id=105, Nom="Match 1"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="7"},Match = new Match(){ Id=106, Nom="Match 2"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="7"},Match = new Match(){ Id=107, Nom="Match 3"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="7"},Match = new Match(){ Id=108, Nom="Match 4", DateFin = new DateTime(2022, 10 , 28) } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="8"},Match = new Match(){ Id=109, Nom="Match 1" } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="8"},Match = new Match(){ Id=110, Nom="Match 2"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="8"},Match = new Match(){ Id=111, Nom="Match 3"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="8"},Match = new Match(){ Id=112, Nom="Match 4"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="9"},Match = new Match(){ Id=113, Nom="Match 1", DateFin = new DateTime(2022 , 10 , 23) } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="9"},Match = new Match(){ Id=114, Nom="Match 2" } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="9"},Match = new Match(){ Id=115, Nom="Match 3", DateFin = new DateTime(2022 , 10, 28) } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="9"},Match = new Match(){ Id=116, Nom="Match 4" } },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="10"},Match = new Match(){ Id=117, Nom="Match 1"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="10"},Match = new Match(){ Id=118, Nom="Match 2"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="10"},Match = new Match(){ Id=119, Nom="Match 3"} },
                    new Composition(){TournoiId = 1,Jeu = new Jeu(){Nom ="10" } , Match = new Match(){ Id=120, Nom="Match 4"} } }
            };
            return tournoi;
        }
        private List<Match> GetFakeMatchs()
        {
            return new List<Match>() {
                new Match() { Id = 81, Nom = "Match 1", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 82, Nom = "Match 2", DateFin = new DateTime(2022, 10, 26), Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 83, Nom = "Match 3", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 84, Nom = "Match 4", DateFin = new DateTime(2022, 10, 15), Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 85, Nom = "Match 1", DateFin = new DateTime(2022, 10, 7), Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 86, Nom = "Match 2", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 87, Nom = "Match 3", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 88, Nom = "Match 4", DateFin = new DateTime(2022, 10, 14), Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 89, Nom = "Match 1", DateFin = new DateTime(2022, 10, 21), Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 90, Nom = "Match 2", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 91, Nom = "Match 3", DateFin = new DateTime(2022, 10, 14), Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 92, Nom = "Match 4", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 93, Nom = "Match 1", DateFin = new DateTime(2022, 10, 07), Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 94, Nom = "Match 2", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 95, Nom = "Match 3", DateFin = new DateTime(2022, 10, 07), Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 96, Nom = "Match 4", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }} ,
                new Match() { Id = 97, Nom = "Match 1", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }} ,
                new Match() { Id = 98, Nom = "Match 2", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }} ,
                new Match() { Id = 99, Nom = "Match 3", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }} ,
                new Match() { Id = 100, Nom = "Match 4", DateFin = new DateTime(2022, 10, 28), Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 101, Nom = "Match 1", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }} ,
                new Match() { Id = 102, Nom = "Match 2", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }} ,
                new Match() { Id = 103, Nom = "Match 3", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }} ,
                new Match() { Id = 104, Nom = "Match 4", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }} ,
                new Match() { Id = 105, Nom = "Match 1", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }} ,
                new Match() { Id = 106, Nom = "Match 2", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }} ,
                new Match() { Id = 107, Nom = "Match 3", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }} ,
                new Match() { Id = 108, Nom = "Match 4", DateFin = new DateTime(2022, 10, 28), Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 109, Nom = "Match 1", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }},
                new Match() { Id = 110, Nom = "Match 2", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }},
                new Match() { Id = 111, Nom = "Match 3", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }},
                new Match() { Id = 112, Nom = "Match 4", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }},
                new Match() { Id = 113, Nom = "Match 1", DateFin = new DateTime(2022, 10, 23), Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 114, Nom = "Match 2", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 115, Nom = "Match 3", DateFin = new DateTime(2022, 10, 28), Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} } } ,
                new Match() { Id = 116, Nom = "Match 4", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }},
                new Match() { Id = 117, Nom = "Match 1", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }},
                new Match() { Id = 118, Nom = "Match 2", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }},
                new Match() { Id = 119, Nom = "Match 3", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }},
                new Match() { Id = 120, Nom = "Match 4", Compositions = new List<Composition>(){ new Composition() { TournoiId = 1} }}
            };
        }
    }
}