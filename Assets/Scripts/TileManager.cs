using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefab;

    public GameObject currentTile;

    public int amountOfTile;



    private static TileManager instance;

    private Stack<GameObject> LeftTile = new Stack<GameObject>();
    private Stack<GameObject> TopTile = new Stack<GameObject>();

    public static TileManager Instance
    {

        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileManager>();
            }
            return instance;
        }
    }

    public Stack<GameObject> LeftTile1 { get => LeftTile; set => LeftTile = value; }
    public Stack<GameObject> TopTile1 { get => TopTile; set => TopTile = value; }

    // Start is called before the first frame update
    void Start()
    {
        CreateTiles(amountOfTile);

        for (int i = 0; i < 10; i++)
        {
            SpawnTile();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreateTiles(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            LeftTile1.Push(Instantiate(tilePrefab[0]));
            TopTile1.Push(Instantiate(tilePrefab[1]));
            LeftTile1.Peek().name = "LeftTile";
            LeftTile1.Peek().SetActive(false);
            TopTile1.Peek().name = "TopTile";
            TopTile1.Peek().SetActive(false);
        }
    }
    public void SpawnTile()
    {
        if (LeftTile1.Count == 0 || TopTile1.Count == 0)
        {
            CreateTiles(amountOfTile);
        }

        int randomIndex = Random.Range(0, 2);

        if (randomIndex == 0)
        {
            GameObject tmp = LeftTile1.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = tmp;
        }
        else if (randomIndex == 1)
        {
            GameObject tmp = TopTile1.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = tmp;
        }

        int spawnCrystall = Random.Range(0, 5);
        if (spawnCrystall == 0)
        {
            currentTile.transform.GetChild(1).gameObject.SetActive(true);
        }


        //currentTile = (GameObject) Instantiate(tilePrefab[randomIndex], currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position,Quaternion.identity);
    }
    public void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
