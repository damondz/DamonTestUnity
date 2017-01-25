using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class MapGenerator : MonoBehaviour {

    public Transform PointZero;
    //private Vector3 StartPoint;

    private Vector3 CurrLoc;

    public GameObject CBG;
    public GameObject Top;
    public GameObject Core;

    public GameObject Bomb;
    public GameObject Prize;

    bool NoPrize = false;
    int BombCount = 5;

    List<int> all = new List<int>();
    private int[,] MapList = new int[30,30];


    // Use this for initialization
    void Start ()
    {
        CurrLoc = PointZero.position;
        GenerateMatrix();
        GenerateMesh();
	}

    private void GenerateMatrix()
    {
        all.Add(3);
        all.Add(2); all.Add(2); all.Add(2); all.Add(2); all.Add(2);
        for (int i = 6; i < 437; i++)
        {
            all.Add(1);
        }
        all.Shuffle<int>();
        for (int i = 0; i < 23; i++)
        {
            for (int j = 0; j < 23; j++)
            {
                if (i < 4)
                {
                    MapList[i, j] = 1;
                }
                else
                {
                    MapList[i, j] = all.First();
                    all.RemoveAt(0);
                }
            }
        }
    }

    private void GenerateMesh()
    {
        for (int i = 0; i < 23; i++)
        {
            for (int j = 0; j < 23; j++)
            {
                if (i==0)
                {
                    GameObject current = Instantiate(Top, CurrLoc, Quaternion.identity) as GameObject;
                    current.transform.parent = PointZero;
                    current.name = current.name.Replace("(Clone)", "");
                }
                else
                {
                    if (i < 4)
                    {
                        GameObject current = Instantiate(Core, CurrLoc, Quaternion.identity) as GameObject;
                        current.transform.parent = PointZero;
                        current.name = current.name.Replace("(Clone)", "");
                    }
                    else
                    {
                        GameObject curr = GetPrefab(MapList[i, j]);
                        GameObject current = Instantiate(curr, CurrLoc, Quaternion.identity) as GameObject;
                        current.transform.parent = PointZero;
                        current.name = current.name.Replace("(Clone)", "");
                    }
                }

                Vector3 bgPosition = new Vector3(CurrLoc.x, CurrLoc.y - 0.175f, 0);

                GameObject bg = Instantiate(CBG, bgPosition, Quaternion.identity) as GameObject;
                bg.transform.parent = PointZero;
                CurrLoc = new Vector3(CurrLoc.x + bg.GetComponent<Renderer>().bounds.size.x, CurrLoc.y, 0);
            }
            CurrLoc = new Vector3(PointZero.position.x, CurrLoc.y - Core.GetComponent<Renderer>().bounds.size.y, 0);
        }
    }

    private GameObject GetPrefab(int value)
    {
        if (value == 3)
        {
            return Prize;
        }
        else if (value == 2)
        {
            return Bomb;
        }
        else
        {
            return Core;
        }
    }
}
