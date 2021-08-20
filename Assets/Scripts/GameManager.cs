using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text score1, score2, score3, score4, score5, score6, score7, score8, score9, score10, score11, score12, totalScore, playerName;
    BowlingGame bowlingGame = new BowlingGame();
    // Start is called before the first frame update
    void Start()
    {
        playerName.text = "Jugador 1";
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void NewGame()
    {
        int[] resultados = bowlingGame.Game();
        
       foreach(int i in resultados)
        {
         //   Debug.Log("Total de los tiros" + i.ToString());
        }

        Debug.Log("UBICACION 11:  " + resultados[10]);
        Debug.Log("UBICACION 10:  " + resultados[9]);
        int finalScore = bowlingGame.EndGame(resultados);

        score1.text = resultados[0].ToString();
        score2.text = resultados[1].ToString();
        score3.text = resultados[2].ToString();
        score4.text = resultados[3].ToString();
        score5.text = resultados[4].ToString();
        score6.text = resultados[5].ToString();
        score7.text = resultados[6].ToString();
        score8.text = resultados[7].ToString();
        score9.text = resultados[8].ToString();
        score10.text = resultados[9].ToString();
        if(resultados.Length <= 9)
        {
            score11.text = "-";
            score12.text = "-";
        }
        else if (resultados.Length == 11)
        {
            score11.text = resultados[10].ToString();
            score12.text = "-";
        }
        else
        {
            score11.text = resultados[10].ToString();
            score12.text = resultados[11].ToString();

        }

        totalScore.text = finalScore.ToString();
    }

    

}
