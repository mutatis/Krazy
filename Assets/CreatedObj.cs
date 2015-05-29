using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreatedObj : MonoBehaviour 
{

	public GameObject[] grid;
	public GameObject[] created;

	public Transform canvas;

	int gridRandom;
	int createdRandom;

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
		yield return new WaitForSeconds (2);
		gridRandom = Random.Range (0, grid.Length);
		createdRandom = Random.Range (0, created.Length);
		GameObject obj = Instantiate (created [createdRandom], grid [gridRandom].transform.position, transform.rotation) as GameObject;
		obj.transform.localScale = new Vector3 (0.01f, 0.01f, 0.01f);
		obj.transform.parent = this.gameObject.transform;
		StartCoroutine("GO");
	}
}
