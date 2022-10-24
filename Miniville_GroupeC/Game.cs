﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    public class Game
    {
        public List<Player> players;
        public Player currentPlayers;
        public Dice playDice;
        public int nbPieceVictory;
        public List<string> namePlayers;
        private List<MasterCard> initialCards;
        private bool expertMode;
        public Pile pile;

        public Game(Dice playDice, int nbPieceVictory, List<string> namePlayers, bool expertMode = false)
        {
            this.playDice = playDice;
            this.nbPieceVictory = nbPieceVictory;
            this.expertMode = expertMode;
            pile = new Pile();
            this.initialCards = new List<MasterCard>()
            {
                new WheatFieldCard(),                          //name, activation value, costvalue, CardColor. Action
                new BakeryCard()
            };

            foreach (string thatName in namePlayers)
            {
                players.Add(new Player(3, this.initialCards,this,thatName));              //(
            }
        }

        private int CheckWinner(List<int> piecesPlayers)
        {
            int gagnant = 0;
            for (int i = 0; i < piecesPlayers.Count; i++)
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

            while (CheckWinner(piecesPlayers) != 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    //int valueDice = this.playDice.value;
                    Console.WriteLine("Nous regardons si les joueurs ont des cartes qui doivent être activées");
                    //players[i].CheckCardToActivate(valueDice);
                    Console.WriteLine("Quel carte souhaitez-vous acheete");
                    //players[i].BuyCards();


                    //piecesPlayers[i] = players[i].nbPiece;
                }
            }
        }


    }
}
