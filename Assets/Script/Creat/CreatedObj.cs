using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreatedObj : MonoBehaviour 
{
	public GameObject[] grid;
	public GameObject[] created;
	public Transform canvas;
    public float tempoWave;
    public int startingWave;
    public int minWave;
    public int maxWave;
    public int wave = 0;
	public GameObject[] posCreated;

	int pode = -1;

	public int gridRandom;
	public int minX, maxX;

	int createdRandom;

	// Use this for initialization
	void Start () 
	{
		grid = GameObject.FindGameObjectsWithTag("Grid");
		posCreated = GameObject.FindGameObjectsWithTag("Spawn");
		StartCoroutine("GO");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	IEnumerator GO()
	{
		pode = 0;
        var rdm = new System.Random();
        var qtdWave = wave++ == 0 ? startingWave : rdm.Next(minWave, maxWave);//range não inclui o maior extremo
        print(qtdWave);
        for (int i = 0; i < qtdWave; i++)
        {
            gridRandom = rdm.Next(0, grid.Length);
            var target = grid[gridRandom];
            do
            {
                if (grid[gridRandom].GetComponent<BlockSquare>().ok == false)
                {
                    gridRandom = rdm.Next(0, grid.Length);
                    pode = -1;
                }
                else if (grid[gridRandom].GetComponent<BlockSquare>().ok == true)
                {
                    target = grid[gridRandom];
                    pode = 1;
                }
                yield return new WaitForEndOfFrame();
            } while (pode < 0);
            createdRandom = Random.Range(0, created.Length);
			GameObject obj = Instantiate(created[createdRandom], posCreated[Random.Range(0, posCreated.Length)].transform.position, transform.rotation) as GameObject;
            obj.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            obj.transform.parent = this.gameObject.transform;
            obj.SendMessage("SetTarget", target);
            obj.GetComponent<SelectPOsition>().StartCoroutine("GoToTarget");
        }
		pode = 0;
        yield return new WaitForSeconds(tempoWave);
		StartCoroutine("GO");
	}
}