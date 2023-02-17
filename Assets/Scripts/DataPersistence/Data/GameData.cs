using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    public Sprite player;
    public Sprite parallax;

    public float music;
    public float sfx;

    public int highScore;
    public int gold;

    public bool[] spaceShips;
    public bool[] spaceShipsBlur;
    public bool[] galaxies;
    public bool[] galaxiesBlur;

    public GameData()
    {
        this.player = null;
        this.parallax = null;
        this.music = 1;
        this.sfx = 1;
        this.highScore = 0;
        this.gold = 0;
        this.spaceShips = new bool[5] { false, true, false, false, false };
        this.spaceShipsBlur = new bool[5] { true, false, true, true, true };
        this.galaxies = new bool[3] { true, false, false };
        this.galaxiesBlur = new bool[3] { false, true, true };
    }

}
