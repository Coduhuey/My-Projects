using UnityEngine;
using System;                       //new
using System.Collections.Generic; //new extension
using Random = UnityEngine.Random; //new



//Interesting functions and uses
/*
Instantiate, used to make a clone, and add, of a game object in a certain place: Instantiate(gameobject, transform.position, transform.rotation)
Random. Random.Range(minimum, maximum)

as GameObject, 

transform.SetParent(), 




Uses
class to store variables for different forms of maximum and minimum values (FoodCount and WallCount), (public Count WallCount = new Count(numbers, numbers)), (WallCount.maximum)

Gameobject arrays (public Gameobject floorTiles[])

setting the transform of a certain object to variable (private Transform boardholder; ----> boardholder = new GameObject("Board").transform







*/

public class BoardManager : MonoBehaviour {

    [Serializable] //new
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)      //counts to assign the min and max values for the arrays
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns = 8;
    public int rows = 8;                //values for the map

    public Count WallCount = new Count(5, 9);
    public Count foodCount = new Count(1, 5);           //min and max values for the following are set

    public GameObject exit;

    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] foodTiles;                  //arrays to hold sprites are defined
    public GameObject[] enemyTiles;
    public GameObject[] outerWallTiles;

    private Transform boardholder; //defined soon to be position of board
    private List<Vector3> gridPositions = new List<Vector3>(); //soon to be list of all possible positions

    void InitialiseList() //setting grid
    {
        gridPositions.Clear();

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f)); //adds to list of possible positions, for the food and other setup (not walls and floors)
            }
        }
    }

    void BoardSetup()
    {
        boardholder = new GameObject("Board").transform;

        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)]; //defines the gameobject variable from choosing a random floor tile from the array

                if (x == -1 || x == columns || y == -1 || y == rows)    // if x value is -1 or max value or y value is, then choose random outerwall from that array
                {
                    toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
                }
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject; //instantiate clones the original object

                instance.transform.SetParent(boardholder); //set the objects x and y values in refrence to the boardholder gameobject, that's what the instance was made
            }

        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count); //makes a random number from the numbered list of gridpositions array

        Vector3 randomPosition = gridPositions[randomIndex]; //takes the numbers to find and make the position

        gridPositions.RemoveAt(randomIndex);
        return randomPosition; //releases the random position
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int ObjectCount = Random.Range(minimum, maximum + 1); //spawns this many objects

        for (int i = 0; i < ObjectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            Instantiate(tileChoice, randomPosition, Quaternion.identity); //instantiate spawns the gameobject in the later specified position and rotation
        }
    }


    public void SetupScene(int level) //only public function, will be called
    {
        BoardSetup();
        InitialiseList();
        LayoutObjectAtRandom(wallTiles, WallCount.minimum, WallCount.maximum);
        LayoutObjectAtRandom(foodTiles, foodCount.minimum, foodCount.maximum);
        int enemyCount = (int)Mathf.Log(level, 2f); //continues to multiple the level by two to get the number of enemies
        LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount); //number of enemies is the same
        Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
    }

  }