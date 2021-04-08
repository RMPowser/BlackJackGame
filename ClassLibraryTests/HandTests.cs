using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Tests
{
    [TestClass()]
    public class HandTests
    {
        [TestMethod()]
        public void ScoreTest()
        {
            Actor player = new Actor();
            player._hand._cards.Add(new Card(Card.ValueName.Ace, Card.SuitName.Spades));
            player._hand._cards.Add(new Card(Card.ValueName.Eight, Card.SuitName.Diamonds));
            Assert.AreEqual(19, player._hand.GetScore());
            player._hand._cards.Add(new Card(Card.ValueName.Ten, Card.SuitName.Hearts));
            Assert.AreEqual(19, player._hand.GetScore());
        }
    }
}