using UnityEngine;
using System.Collections;

public class Grid {
    
    public Block[][] grid;


    public void MoveBlock(Block block, Vector2 origin, Vector2 target)
    {
        int type = block.type;
        block.type = 0;
        GetBlockByPosition((int)target.x, (int)target.y).type = type;   
    }

    public Block GetBlockByPosition(int x, int y) 
    {
        return grid[x][y];
    }

    public void PopEvent()
    {

    }
}

class Block
{
    int minimumPopStack;
    int x, y;
    public int type;
    public void Block(int x, int y, Grid parent, int minimumPopStack)
    {
        this.x = x;
        this.y = y;
        parentGrid = parent;
        this.minimumPopStack = minimumPopStack;
    }
    Grid parentGrid;

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
