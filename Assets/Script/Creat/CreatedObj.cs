using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreatedObj : MonoBehaviour 
{

	public static CreatedObj creat;

	public GameObject[] grid;
	public GameObject[] created;

	public Transform canvas;

	int pode;

	public int gridRandom;
	int createdRandom;

	void Awake()
	{
		creat = this;
	}

	// Use this for initialization
	void Start () 
	{
		grid = GameObject.FindGameObjectsWithTag("Grid");
		StartCoroutine("GO");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	IEnumerator GO()
	{
		pode = 0;
		yield return new WaitForSeconds (2);
		gridRandom = Random.Range (0, grid.Length);
		while(pode < 0)
		{
			if(grid[gridRandom].GetComponent<CorCol>().ok == false)
			{
				gridRandom = Random.Range (0, grid.Length);
				pode = 0;
			}
			else if(grid[gridRandom].GetComponent<CorCol>().ok == true)
			{
				pode = 1;
			}
		}
		createdRandom = Random.Range (0, created.Length);
		GameObject obj = Instantiate (created [createdRandom], new Vector2(0, -10), transform.rotation) as GameObject;
		obj.transform.localScale = new Vector3 (0.01f, 0.01f, 0.01f);
		obj.transform.parent = this.gameObject.transform;
		pode = 0;
		StartCoroutine("GO");
	}
}