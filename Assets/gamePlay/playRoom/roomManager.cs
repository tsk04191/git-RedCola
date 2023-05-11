using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roomManager : MonoBehaviour
{
    private GameObject GM;
    private gameManager gM() { return GM.GetComponent<gameManager>(); }
    private sysAStar Grid;

    private int roomMaxX = 16;
    private int roomMaxY = 16;

    private int barricadeMax = 4;

    private Canvas cavRoom;
    private GameObject objTileGroup;
    private GameObject objBarricadeGroup;

    [SerializeField] private Image imgTile;
    [SerializeField] private List<GameObject> objTileGrass;
    [SerializeField] private List<GameObject> objBarricade;

    private void Awake()
    {
        GM = GameObject.Find("gameManager");
        Grid = new sysAStar();
    }

    private void Start()
    {
        cavRoom = gameObject.transform.GetChild(0).GetComponent<Canvas>();
        objTileGroup = gameObject.transform.GetChild(2).gameObject;
        objBarricadeGroup = gameObject.transform.GetChild(3).gameObject;

        cavRoom.worldCamera = Camera.main;

        Grid.Set(roomMaxX, roomMaxY);
        DoPlaceBarricade();
        DoPlaceTile();
    }

    private void DoPlaceTile()
    {
        for (int i = 0; i < roomMaxX; i++)
        {
            for (int j = 0; j < roomMaxY; j++)
            {
                GameObject g = Instantiate(objTileGrass[0]);
                g.name = SetObjName(i, j, "objTile");
                g.transform.position = new Vector3(i, 0, -15 + j);
                g.transform.SetParent(objTileGroup.transform, false);

                if (!Grid.GetBarricade(i, j))
                {
                    GameObject t = Instantiate(imgTile.gameObject);
                    t.name = SetObjName(i, j, "imgTile");
                    t.transform.position = new Vector3(-7.5f + i, -7.5f + j, 0);
                    t.transform.SetParent(cavRoom.transform, false);
                }
            }
        }
    }

    private void DoPlaceBarricade()
    {
        for (int i = 0; i < roomMaxX; i++)
        {
            int n = Random.Range(0, barricadeMax);
            for (int j = 0; j < n; j++)
            {
                int m = Random.Range(0, roomMaxY);
                GameObject g = Instantiate(objBarricade[0]);
                g.name = SetObjName(i, m, "objBarricade");
                g.transform.position = new Vector3(i, 0, -15 + m);
                g.transform.SetParent(objBarricadeGroup.transform, false);

                Grid.AddBarricade(i, m);
            }
        }
    }

    private void DoPlaceStartPoint()
    {
        int i = Random.Range(0, roomMaxY);
    }

    private string SetObjName(int i, int j, string n)
    {
        string x = i.ToString();
        string y = j.ToString();

        if (i < 10)
        {
            x = "0" + i;
        }
        if (j < 10)
        {
            y = "0" + j;
        }

        return n + x + y;
    }
}
