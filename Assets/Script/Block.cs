using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public int minimumPopStack;
    public int x, y;
    public int type;
    public Grid parentGrid;   

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    } 

    public void CheckSurroundings()
    {
        var cima = parentGrid.GetBlockByPosition(x, y + 1);
        var baixo = parentGrid.GetBlockByPosition(x, y - 1);
        var esquerda = parentGrid.GetBlockByPosition(x - 1, y);
        var direita = parentGrid.GetBlockByPosition(x + 1, y);

        int stackCima = 0, stackBaixo = 0, stackEsquerda = 0, stackDireita = 0;

        if (cima.type == type)
            stackCima = cima.CheckSurroundings(1, true);
        if (baixo.type == type)
            stackBaixo = baixo.CheckSurroundings(1, true, -1);
        if (esquerda.type == type)
            stackEsquerda = esquerda.CheckSurroundings(1);
        if (direita.type == type)
            stackDireita = direita.CheckSurroundings(1, sinal: -1);

        if (stackCima + stackBaixo >= minimumPopStack)
        {
            //evento de pop
        }
        else if (stackDireita + stackEsquerda >= minimumPopStack)
        {
            //evento de pop
        }
    }

    public int CheckSurroundings(int stack, bool vertical = false, int sinal = 1)
    {
        if (vertical)
            return parentGrid.GetBlockByPosition(x, y + sinal).CheckSurroundings(stack + 1, vertical, sinal);
        else
            return parentGrid.GetBlockByPosition(x + sinal, y).CheckSurroundings(stack + 1, vertical, sinal);
    }
}
