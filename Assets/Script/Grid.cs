using UnityEngine;
using System.Collections;

public class Grid {
    
    private BlockInternal[,] grid;

    public Grid(int xSize, int ySize)
    {
        grid = new BlockInternal[xSize,ySize];
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                grid[x, y] = new BlockInternal(x,y, -1, 0, this);
            }
        }
    }

    public void InsertBlock(BlockInternal block)
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

    public BlockInternal GetBlockByPosition(int x, int y) 
    {
        return grid[x,y];
    }

    public void PopEvent(int negativos, int positivos, bool vertical = false) 
    {

    }
}
