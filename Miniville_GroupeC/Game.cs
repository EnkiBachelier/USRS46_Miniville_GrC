﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    public class Game
    {
        public List<Player> players = new List<Player>();
        public Player currentPlayers;
        public Dice playDice;
        public int nbPieceVictory;
        public List<string> namePlayers = new List<string>();
        private List<MasterCard> initialCards = new List<MasterCard>();
        private bool expertMode;
        public Pile pile;

        public Game(Dice playDice, int nbPieceVictory, List<string> namePlayers, bool expertMode = false)
        {
            this.playDice = playDice;
            this.nbPieceVictory = nbPieceVictory;
            this.expertMode = expertMode;
            this.namePlayers = namePlayers;

            pile = new Pile();

            foreach (string thatName in namePlayers)
            {
                MasterCard cardCham = new WheatFieldCard();
                MasterCard cardBak = new BakeryCard();
                this.initialCards = new List<MasterCard>()
                {
                    cardCham,
                    cardBak
                };
                Player thatPlayer = new Player(3, this.initialCards, this, thatName);
                cardCham.SetPlayerOwner(thatPlayer);
                cardBak.SetPlayerOwner(thatPlayer);
                players.Add(thatPlayer);
            }
        }

        private int CheckWinner(List<int> piecesPlayers)
        {
            int gagnant = -1;
            for (int i = 0; i < namePlayers.Count; i++)
            {
                if (piecesPlayers[i] == this.nbPieceVictory)
                    gagnant = i;
            }
            return gagnant;
        }

        public void GameLoop()
        {
            List<int> piecesPlayers = new List<int>();

            foreach (Player thatPlayer in players)
            {
                piecesPlayers.Add(thatPlayer.nbPiece);
            }

            bool isInLoop = true;
            string winningPlayer = "";
            while (isInLoop)
            {
                for (int i = 0; i < players.Count; i++)
                {

                    currentPlayers = players[i];
                    int valueDice = this.playDice.De;
                    
                    Console.Write("\n\nC'est au tour de " + currentPlayers.name + " qui a un total de ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(currentPlayers.nbPiece);
                    Console.ResetColor();
                    Console.WriteLine(" pièces !");

                    Console.Write("Le dé affiche une valeur de ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(valueDice);
                    Console.ResetColor();
                    Console.WriteLine();

                    Console.WriteLine("Nous regardons si les joueurs ont des cartes qui doivent être activées\n");
                    currentPlayers.CheckCardToActivate(valueDice);
                    Console.WriteLine("Quel carte souhaitez-vous acheter ? \n");
                    currentPlayers.BuyCard();

                    piecesPlayers[i] = currentPlayers.nbPiece;
                    if (currentPlayers.nbPiece >= this.nbPieceVictory)
                    {
                        winningPlayer = currentPlayers.name;
                        isInLoop = false;
                        break;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Bravo au joueur " + winningPlayer + " qui a gagné !!");
            Console.ResetColor();
        }


    }
}
