using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public int minimumPopStack;
	//[HideInInspector]
    public int x, y;
    public int type;
    public BlockInternal blockInternal;
	Vector2 target;

    // Use this for initialization
    void Start()
    {
		x = (int)transform.position.x;
		y = (int)transform.position.y;
		blockInternal = new BlockInternal(x, y, 0, minimumPopStack, Grid.gridS);
		Grid.gridS.InsertBlock (blockInternal);
		blockInternal.blockExternal = this;
    }

	void OnMouseUp()
	{
		target = new Vector2((int)transform.position.x, (int)transform.position.y);
		Grid.gridS.MoveBlock (blockInternal, new Vector2 (x, y), target);
	}

	public void Pop()
	{
		Destroy (gameObject);
	}

    // Update is called once per frame
    void Update()
    {		
	
    }
}
