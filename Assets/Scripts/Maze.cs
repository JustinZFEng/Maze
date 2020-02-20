using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}
public class Maze : MonoBehaviour
{
    private int count;
    static private Maze S; //	a	private	Singleton
    [Header("Set in	Inspector")]
    public Text uitLevel;
    public Text winText;
    //ublic Text uitShots;
    public Vector3 mazePos; //	The	place	to	put	castles
    public GameObject[] mazes;          //	An	array	of	the	castles

    [Header("Set Dynamically")]
    public int level;                   //	The	current	level
    public int levelMax;        //	The	number	of	levels
    public GameObject maze;               //	The	current	castle
    public GameMode mode = GameMode.idle;

    void Start()
    {
        S = this; //	Define	the	Singleton
        level = 0;
        levelMax = mazes.Length;
        StartLevel();
        winText.text = "";
    }
    void StartLevel()
    {
        if (maze != null)
        {
            Destroy(maze);
        }
        maze = Instantiate<GameObject>(mazes[level]);
        maze.transform.position = mazePos;
        Goal.goalMet = false;
        UpdateGUI();
        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        uitLevel.text = "Level:	" + (level + 1) + " of " + levelMax;
    }

    void Update()
    {
        UpdateGUI();
        if ((mode == GameMode.playing) && Goal.goalMet)
        {
            mode = GameMode.levelEnd;
            NextLevel();
            count++;
            if (count == 4) 
            {
                winText.text = "You Win! Collect the cube at the bottom to restart!";
            }
            if (count == 5)
            {
                winText.text = "";
                count = -1;
            }
            //Invoke("NextLevel", 2f);
        }
        
    }
    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            level = 0;
        }
        StartLevel();
    }
}
