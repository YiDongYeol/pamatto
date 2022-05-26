﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp1
{
    public class Deck : GameTable
    {
        public List<Card> HandDeck;
        public List<Card> DrawDeck;
        public List<Card> GraveDeck;
        //private List<Card> MerketDeck;

        private Random random = new Random();

        public Deck(List<Card> estatelist, List<Card> moneylist, Game_Screen g)
        {
            HandDeck = new List<Card>();
            DrawDeck = new List<Card>();
            GraveDeck = new List<Card>();

            Card copper = null;
            int i;
            for (i = 0; i < 3; i++)
            {
                if (moneylist[i].Name.Equals("copper"))
                {
                    copper = moneylist[i];
                    break;
                }
            }
            Card estate = null;
            int j;
            for (j = 0; j < 4; j++)
            {
                if (estatelist[j].Name.Equals("estate"))
                {
                    estate = estatelist[j];
                    break;
                }
            }

            for (int k = 0; k < 7; k++)
            {
                DrawDeck.Add(copper);
                moneylist[i].amount -= 1;
            }

            for (int k = 0; k < 3; k++)
            {
                DrawDeck.Add(estate);
                estatelist[j].amount -= 1;
            }

            Shuffle(DrawDeck);
            DrawToHand(5, g);
        }

        public Deck(List<Card> estatelist, List<Card> moneylist, List<Card> actionlist)     //지워야됨
        {
            HandDeck = new List<Card>();
            DrawDeck = new List<Card>();
            GraveDeck = new List<Card>();

            Card copper = null;
            int i;
            for (i = 0; i < 3; i++)
            {
                if (moneylist[i].Name.Equals("copper"))
                {
                    copper = moneylist[i];
                    break;
                }
            }
            Card estate = null;
            int j;
            for (j = 0; j < 4; j++)
            {
                if (estatelist[j].Name.Equals("estate"))
                {
                    estate = estatelist[j];
                    break;
                }
            }

            for (int k = 0; k < 7; k++)
            {
                DrawDeck.Add(copper);
                moneylist[i].amount -= 1;
            }

            for (int k = 0; k < 3; k++)
            {
                DrawDeck.Add(estate);
                estatelist[j].amount -= 1;
            }

            Shuffle(DrawDeck);
            DrawToHand(5,actionlist);
        }       //지워야됨

        public void Shuffle(List<Card> Obj)
        {
            List<Card> NewCards = new List<Card>();
            while (Obj.Count > 0)
            {
                int CardToMove = random.Next(Obj.Count);
                NewCards.Add(Obj[CardToMove]);
                Obj.RemoveAt(CardToMove);
            }
            DrawDeck = NewCards;
        }

        /*public void DrawToHand()
        {
            while (HandDeck.Count < 6)
            {
                HandDeck.Add(DrawDeck[0]);
                DrawDeck.RemoveAt(0); //0번이 채ㅣ워지나?
                if (DrawDeck.Count == 0)
                    Shuffle(DrawDeck);
            }
        }*/

        public void DrawToHand(int i, Game_Screen g)
        {
            while (0 < i)
            {
                HandDeck.Add(DrawDeck[0]);
                DrawDeck.RemoveAt(0);
                if (DrawDeck.Count == 0)
                    Shuffle(DrawDeck);
                i--;
            }
            g.setHandDeckImg(this);
        }
        public void DrawToHand(int i, List<Card> actionlist)        //지워야됨
        {
            while (0 < i)
            {
                HandDeck.Add(DrawDeck[0]);
                DrawDeck.RemoveAt(0);
                if (DrawDeck.Count == 0)
                    Shuffle(DrawDeck);
                i--;
            }
            Card tmp = null;
            for (int j = 0; j < 10; j++) {
                if (actionlist[j].Name.Equals("mine"))
                {
                    tmp = actionlist[j];
                    break;
                }
            }
            HandDeck.Add(tmp);
        }           //지워야됨
            public void Clear()
        {
            //HandToGrave
            for (int i = 0; i < HandDeck.Count; i++)
            {
                GraveDeck.Add(HandDeck[i]);
                HandDeck.RemoveAt(i);
            }
        }
        public void GoToGrave(int number, string mode)
        {
            GraveDeck.Add(HandDeck[number]);
            //HandDeck[number] = null;
            HandDeck.RemoveAt(number);
        }
        public void BuyCard(Card card)
        {
            GraveDeck.Add(card);
        }

        public void gainCardToHand(Card card)
        {
            HandDeck.Add(card);
        }
    }
}
