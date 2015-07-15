using UnityEngine;

[AddComponentMenu(D2D_Helper.ComponentMenuPrefix + "Click To Spawn")]
public class D2D_ClickToSpawn : MonoBehaviour
{
	public GameObject Prefab;
	
	//public KeyCode Requires = KeyCode.Mouse0;
	
	public void Atira(Vector2 pos)
	{
		var point = pos;
		
		D2D_Helper.CloneGameObject(Prefab, null).transform.position = point;
	}
}