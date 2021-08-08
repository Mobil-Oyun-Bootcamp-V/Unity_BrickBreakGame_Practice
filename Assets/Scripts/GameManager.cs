using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static GameState state = GameState.NotStart;
    public enum GameState
    {
        NotStart,
        Start,
        GameOver
    }
}
