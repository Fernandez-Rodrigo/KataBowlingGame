using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    /*
     
     - Son 10 turnos por jugador a menos que haga ---SPARE O STRIKE en el turno 10, en ese caso hay 1 o 2 tiradas extra respectivamente---
     - 10 bolos por turno
     - 2 tiros por tunos
     - Si en el turno no tira el total la puntuación es el total de los bolos tirados
     - Si en un turno el jugador tira los 10 en el segundo tiro se considera SPARE (10 + bolos tirados en siguiente primer tirada) 
     - Si en un turno el jugador tira los 10 en el primer tiro el turno acaba y es STRIKE (10 + puntuación de 2 tiradas siguientes)
     
     */


    public class TestKataBowling
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestKataBowlingSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestKataBowlingShouldFinishAtFrame10()
        {
            
            BowlingGame bowlingGame = new BowlingGame();

            int result = bowlingGame.turns;

            Assert.AreEqual(10, result);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }

        [UnityTest]
        public IEnumerator EveryTurnShouldHaveTwoRolls()
        {

            BowlingGame bowlingGame = new BowlingGame();

            int result = bowlingGame.rolls;

            Assert.AreEqual(2, result);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }

        [UnityTest]
        public IEnumerator EveryTurnShouldHaveTenPins()
        {

            BowlingGame bowlingGame = new BowlingGame();

            int result = bowlingGame.pins;

            Assert.AreEqual(10, result);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }


        [UnityTest]
        public IEnumerator TheTotalPointslOfTheTurnAreValid()
        {

            BowlingGame bowlingGame = new BowlingGame();

            int result = bowlingGame.NewTurn(1).Total;

            Assert.LessOrEqual(result, bowlingGame.pins);

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }


        [UnityTest]
        public IEnumerator IfIsSpare()
        {

            BowlingGame bowlingGame = new BowlingGame();
            int roll = 5;
            int total = 10;

            bool result = bowlingGame.IsSpare(roll, total);

            Assert.IsTrue(result);

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }


        [UnityTest]
        public IEnumerator IfIsStrike()
        {

            BowlingGame bowlingGame = new BowlingGame();

            int roll = 10;
            
            bool result = bowlingGame.IsStrike(roll);

            Assert.IsTrue(result);

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }

        

    }
}
