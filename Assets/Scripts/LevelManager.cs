﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelManager
{
    public static int level = 1;
    public static LevelState levelState;

    public enum LevelState
    {
        next,
        stop
    }
}
