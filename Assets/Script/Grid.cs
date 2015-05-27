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
                grid[x, y] = null;
            }
        }
    }

    public void InsertBlock(Block block)
    {
        grid[block.x, block.y] = block;
    }

    public void MoveBlock(BlockInternal block, Vector2 origin, Vector2 target)
    {
        int type = block.type;
        block.type = 0;
        var movedBlock = GetBlockByPosition((int)target.x, (int)target.y);
        movedBlock.type = type;
        movedBlock.CheckSurroundings();
    }

    public Block GetBlockByPosition(int x, int y) 
    {
        return grid[x,y];
    }

    public void PopEvent(BlockInternal origin, int negativos, int positivos, bool vertical = false) 
    {
        for (int i = positivos; i >= -negativos; i--)
        {
            if (vertical)
            {
                var block = GetBlockByPosition(origin.x, origin.y + i);
                //block.blockExternal.Pop(positivos + negativos + 1);
            }
            else
            {
                var block = GetBlockByPosition(origin.x + i, origin.y);
                //block.blockExternal.Pop(positivos + negativos + 1);
            }
        }
    }
}
