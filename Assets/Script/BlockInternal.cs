using UnityEngine;
using System.Collections;

public class BlockInternal {
    public Block blockExternal;

    public int minimumPopStack;
    public int x, y;
    public int type;
    public Grid parentGrid;

    public BlockInternal(int x, int y, int type, int minimumPopStack, Grid parentGrid)
    {
        this.x = x;
        this.y = y;
        this.type = type;
        this.minimumPopStack = minimumPopStack;
        this.parentGrid = parentGrid;
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
            parentGrid.PopEvent(this, stackBaixo, stackCima, true);
        }
        else if (stackDireita + stackEsquerda >= minimumPopStack)
        {
            //evento de pop
            parentGrid.PopEvent(this, stackEsquerda, stackDireita, false);
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
