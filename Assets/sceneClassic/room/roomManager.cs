using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.UI;

public class roomManager : MonoBehaviour
{
    [Header("Room Info")]
    [SerializeField] private int roomX;
    [SerializeField] private int roomY;

    [Header("Object Groups")]
    [SerializeField] private GameObject objTileGroup;
    [SerializeField] private Canvas cavTileGroup;

    [Header("Sprite Groups")]
    [SerializeField] private Sprite spt;

    [Header("Material Groups")]
    [SerializeField] private Material matBlock;
    [SerializeField] private List<Material> matGrass = new List<Material>();

    private void Start()
    {
        cavTileGroup.worldCamera = Camera.main;

        DoGenerateRoom();
        DoGenerateTile();
    }

    public void DoSetRoom(int roomX, int roomY)
    {
        this.roomX = roomX;
        this.roomY = roomY;
    }

    private void DoGenerateRoom()
    {
        int r = 0;

        for(float i = 0; i < roomX; i++)
        {
            for (float j = 0; j < roomY; j++)
            {
                setCube("obj" + setGridName(i, j), objTileGroup, new Vector3(i, -1f, j), Vector3.one, matGrass[r]);

                r += Random.Range(-1, 2);

                if (r < 0)
                {
                    r = 0;
                }
                else if (r > 4)
                {
                    r = 4;
                }
            }
        }
    }

    private void DoGenerateTile()
    {
        for (float i = 0; i < roomX; i++)
        {
            for (float j = 0; j < roomY; j++)
            {
                setImg("img" + setGridName(i, j), cavTileGroup, new Vector3(i, j, 0f), Vector2.one, null);
            }
        }
    }

    private string setGridName(float i, float j)
    {
        string n = null, m = null;

        if (i < 10)
        {
            n = "00" + i.ToString();
        }
        else if (i > 9 && i < 100)
        {
            n = "0" + i.ToString();
        }
        else
        {
            n = i.ToString();
        }

        if (j < 10)
        {
            m = "00" + j.ToString();
        }
        else if (j > 9 && j < 100)
        {
            m = "0" + j.ToString();
        }
        else
        {
            m = j.ToString();
        }

        return n + m;
    }

    private void setCube(string n, GameObject prt, Vector3 pos, Vector3 s, Material m)
    {
        GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
        g.name = n;
        g.transform.position = pos;
        g.transform.localScale = s;
        g.GetComponent<Renderer>().material = m;

        g.transform.SetParent(prt.transform, true);
    }

    private void setImg(string n, Canvas prt, Vector3 pos, Vector2 s, Sprite m)
    {
        GameObject i = new GameObject();
        i.AddComponent<Image>();
        i.transform.rotation = Quaternion.identity;
        i.transform.localScale = Vector3.one;
        i.name = n;
        i.transform.position = pos;
        i.GetComponent<RectTransform>().sizeDelta = s;
        i.GetComponent<Image>().sprite = m;

        Color c = i.GetComponent<Image>().color;
        c.a = 0.25f;
        i.GetComponent<Image>().color = c;

        i.transform.SetParent(prt.transform, false);
    }
}
