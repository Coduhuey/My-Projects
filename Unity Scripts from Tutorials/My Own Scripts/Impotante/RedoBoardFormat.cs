using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

    
public class RedoBoardFormat : MonoBehaviour {
    [Serializable]
    
    public class Range
    {
        private int minimum;
        private int maximum;

        public Range(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int rows = 8;
    public int columns = 8;

    public Range ObjectsRange = new Range(6, 10); 

    public GameObject[] Objects;
    public GameObject[] Floors;
    public GameObject[] Enemys;

    private Transform parentpos;
    private List<Vector3> Poslist = new List<Vector3>();


	void Listing()
    {
        Poslist.Clear();

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                Poslist.Add(new Vector3(r, c, 0.0f));
            }
        }

    }

    void BoardMaker()
    {
        parentpos = new GameObject("Board").transform;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                GameObject gob = Floors[Random.Range(0, Floors.Length)];

                GameObject instantiated = Instantiate(gob, new Vector3(r, c, 0f), Quaternion.identity) as GameObject;

                instantiated.transform.SetParent(parentpos);
            }
        }
    }

    Vector3 randompos()
    {
        int randomnumb = Random.Range(0, Poslist.Count);

        Vector3 position = Poslist[randomnumb];

        Poslist.RemoveAt(randomnumb);

        return position;
    }

    void RandomLayout(GameObject[] GArray, int minimum, int maximum)
    {
        int Loopage = Random.Range(minimum, maximum);

        for(int i = 0; i < Loopage; i++)
        {
            GameObject gobject = GArray[Random.Range(0, GArray.Length)];

            Vector3 position = randompos();

            Instantiate(gobject, position, Quaternion.identity);
        }
    }

    public void Setup(int level)
    {

    }
    
}
