using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
    
    private BlockInternal[,] grid;

	public static Grid gridS;
	public int xSize, ySize;

	void Awake()
	{
		gridS = this;
		grid = new BlockInternal[xSize,ySize];
		for (int x = 0; x < xSize; x++)
		{
			for (int y = 0; y < ySize; y++)
			{
				grid[x, y] = new BlockInternal(x,y, -1, 0, this);
			}
		}
	}

   /* public Grid(int xSize, int ySize)
    {
       // grid = new BlockInternal[xSize,ySize];
    }
*/
    public void InsertBlock(BlockInternal block)
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

    public BlockInternal GetBlockByPosition(int x, int y) 
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
				block.blockExternal.Pop();
//                block.blockExternal.Pop(positivos + negativos + 1);
            }
            else
            {
				var block = GetBlockByPosition(origin.x + i, origin.y);
				block.blockExternal.Pop();
               // block.blockExternal.Pop(positivos + negativos + 1);
            }
        }
		origin.blockExternal.Pop ();
    }
}