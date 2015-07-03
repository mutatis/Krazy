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
    public AudioClip spawnPrimeiraWave;

    int pode = -1;

    public int gridRandom;
    public int minX, maxX;

    int createdRandom;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("Delay");
        grid = GameObject.FindGameObjectsWithTag("Grid");
        posCreated = GameObject.FindGameObjectsWithTag("Spawn");
        StartCoroutine("LaunchWave");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
        AudioSource.PlayClipAtPoint(spawnPrimeiraWave, transform.position, 0.5f);
    }

    public void StopWave()
    {
        StopCoroutine("LaunchWave");
    }

    public IEnumerator LaunchWave()
    {
        pode = 0;
        var rdm = new System.Random();
        var qtdWave = wave++ == 0 ? startingWave : rdm.Next(minWave, maxWave); //range não inclui o maior extremo

        for (int i = 0; i < qtdWave; i++)
        {

            createdRandom = Random.Range(0, created.Length);
            GameObject obj = Instantiate(created[createdRandom], posCreated[Random.Range(0, posCreated.Length)].transform.position, transform.rotation) as GameObject;

            gridRandom = rdm.Next(0, grid.Length);
            var target = grid[gridRandom];

            do
            {
                var blockSquare = grid[gridRandom].GetComponent<BlockSquare>();
                if (blockSquare.blockStack == 0 && blockSquare.LockBlock(obj))
                {
                    target = grid[gridRandom];
                    pode = 1;
                }
                else
                {
                    gridRandom = rdm.Next(0, grid.Length);
                    pode = -1;   
                }
                yield return new WaitForEndOfFrame();
            } while (pode < 0);

            target.SendMessage("OnHover");
            obj.transform.parent = this.gameObject.transform;
            obj.GetComponent<Block>().SetTarget(target, true);
            
        }
        pode = 0;
        yield return new WaitForSeconds(tempoWave);
        StartCoroutine("LaunchWave");
    }
}