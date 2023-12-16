using System.Collections.Generic;
using System.Diagnostics;

namespace RepartitionTournoi.Domain.Unit.Tests
{
    public class TournamentDomain
    {
        private const int NumberOfPlayersByMatch = 3;
        public List<TournamentMatch> Create(List<Player> players, List<Game> games)
        {
            List<TournamentMatch> result = new List<TournamentMatch>();
            foreach (var game in games)
            {
                int index = 0;
                int numberOfMatches = 0;
                do
                {
                    List<MatchScore> scores = new List<MatchScore>();
                    do
                    {
                        scores.Add(new MatchScore() { Player = players[index] });
                        index++;
                    }
                    while (index < NumberOfPlayersByMatch + numberOfMatches);

                    result.Add(new TournamentMatch() { Game = game, Scores = scores });
                    numberOfMatches += NumberOfPlayersByMatch;
                }
                while (index < players.Count);
            }

            return result;
        }

    }
}