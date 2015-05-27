using UnityEngine;
using System.Collections;

public class Grid {
    
    private Block[,] grid;

    public Grid(int xSize, int ySize)
    {
        grid = new Block[xSize,ySize];
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                grid[x, y] = new Block(x,y, this, -1, 0);
            }
        }
    }

    public void InsertBlock(Block block)
    {
        grid[block.x, block.y] = block;
    }

    public void MoveBlock(Block block, Vector2 origin, Vector2 target)
    {
        int type = block.type;
        block.type = 0;
        var bloco = GetBlockByPosition((int)target.x, (int)target.y);
        bloco.type = type;
        bloco.CheckSurroundings();
    }

    public Block GetBlockByPosition(int x, int y) 
    {
        return grid[x,y];
    }

    public void PopEvent(int negativos, int positivos, bool vertical = false) 
    {

    }
}

public class Block
{
    int minimumPopStack;
    public int x, y;
    public int type;
    public Block(int x, int y, Grid parent, int type, int minimumPopStack)
    {
        this.x = x;
        this.y = y;
        parentGrid = parent;
        this.minimumPopStack = minimumPopStack;
        this.type = type;
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
