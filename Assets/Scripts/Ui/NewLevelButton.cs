using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelButton : MonoBehaviour
{
    public void NewLevel() {
        Settings.current.RestartGame();
    }
}
