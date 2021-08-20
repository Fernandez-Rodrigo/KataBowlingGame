using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlingGame : MonoBehaviour
{
    public int turns = 10;
    public int rolls = 2;
    public int pins = 10;
  
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Resultado NewTurn(int turn)
    {
        int total = 0;
        bool isSpare = false;
        bool isStrike = false;
        //int roll1 = 0;
      //  int roll2 = 0;

       // for (int i= 1; i < rolls; i++) 
      //  {
          int  roll1 = Random.Range(0, 11);
          int  roll2 = Random.Range(0, 11 - roll1);
        Debug.Log(roll1);
        Debug.Log(roll2);
            total = roll1 + roll2;
       // }
        
        if (IsStrike(roll1)) { isStrike = true; }

        if (IsSpare(roll1, total)) { isSpare = true; }

        // devuelve el roll y el total
        // roll1 = 5 Y rol2 = 2 -> total = 7;
        // roll1 = 5 Y rol2 = 5 -> total = 10; -> spare
        Resultado resultado = new Resultado {
            Roll1 = roll1,
            Roll2 = roll2,
            Total = total, 
            IsSpare = isSpare, 
            IsStrike = isStrike
        };

       return resultado;
    }

    public bool IsSpare(int roll1, int total) 
    {
        if (roll1 < 10 && total == 10) return true;

        return false;
    }


    public bool IsStrike(int roll1)
    {
        if (roll1 == 10) return true;

        return false;
    }

    public int[] Game()
    {
        turns = 10;
        int total = 0;
        int[] totals = new int[12];
        Resultado turnAnt = null;
        Resultado turnAct = null;
        int countStrike = 0;
        for (int i = 0; i < turns; i++) 
        {
            if( i == 0)
            {
                turnAnt = turnAct = NewTurn(i);
                totals[i] = turnAnt.Total;
            } else {
                turnAnt = turnAct; // turnAnt = turn(i-1)
                turnAct = NewTurn(i);

                if (i >= 9 && turnAct.IsStrike && turns <= 12) 
                {
                    turns++;
                  
                    
                } else if (i == 9 && turnAct.IsSpare && turns <= 11) 
                {
                     turns++;
                }
                // 5-/   5-0   2-3  X  X  X 2-/  X  4-2  0-0

                // turno 2-3-4-5-6-7-8-9
             
                
                    totals[i] = turnAct.Total;  // turno2 = 5 // turno3 = 5 // turno4 = 10 // turno8 = 10 // turno9 = 6 // turno10 = 0
                    
              

                if(turnAnt.IsSpare) 
                {
                    countStrike = 0;
                    total = turnAnt.Total + turnAct.Roll1; 
                    totals[i-1] = total; // turno1 = 10 + 5 // turno7 = 20
                } else if (turnAnt.IsStrike && !turnAct.IsStrike && countStrike < 2) 
                {
                    countStrike = 0;
                    total = turnAnt.Total + turnAct.Roll1 + turnAct.Roll2; // turn
                    totals[i-1] = total; // turno5 = 20 // turno8 = 16
                } else if (turnAnt.IsStrike && !turnAct.IsStrike && countStrike >= 2) 
                {
                    countStrike = 0;
                    total = turnAnt.Total = 20 + turnAct.Roll1; 
                    totals[i-1] = 10 + turnAct.Roll1 + turnAct.Roll2; // turno5 = 20 // turno6 = 20
                    totals[i-2] = total; // turno4 = 25 // turno5 = 22
                } else if (turnAnt.IsStrike && turnAct.IsStrike && countStrike < 2) 
                {
                    countStrike = 2;
                    total = turnAnt.Total = 20; 
                    totals[i] = 10; // turno5 = 10
                    totals[i-1] = total; // turno4 = 20
                } else if (turnAnt.IsStrike && turnAct.IsStrike && countStrike >=2) 
                {
                    countStrike++; // count = 3
                    total = 30; //
                    totals[i] = 10; // turno6 = 10
                    totals[i-1] = 20; // turno5 = 20
                    totals[i-2] = total; // turno4 = 30
                }
            }
            
        }

        return totals;
    }

    public int EndGame(int[] totals)
    {
        int finalScore = 0 ;

       for(int i =0; i <= 9; i++)
       {
            finalScore = finalScore + totals[i];
     
       }

        return finalScore;
    }
  
}


public class Resultado {
    public int Roll1 {get; set;} 
    public int Roll2 {get; set;} 
    public int Total {get; set;} 
    public bool IsSpare {get; set;} 
    public bool IsStrike { get; set;}
}
