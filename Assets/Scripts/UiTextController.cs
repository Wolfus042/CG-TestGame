using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiTextController : MonoBehaviour
{
    private Settings.GamePhase gamePhase;
    public Text textBox;
    public Text number;

    public string waitingText;
    public string keyText;
    public string exitText;



    // Update is called once per frame
    void Update() {
        gamePhase = Settings.current.GetGamePhase();

        if (gamePhase == Settings.GamePhase.Waiting) {
            number.enabled = true;
            textBox.text = waitingText;
            number.text = Settings.current.tickingTimer.ToString("G3");

            if (Settings.current.tickingTimer == -1f) {
                //SpawnCube
                Settings.current.tickingTimer = Settings.current.spawnTime;
            }
            Settings.current.tickingTimer -= Time.deltaTime;

            if (Settings.current.tickingTimer <= 0f) {
                Settings.current.SpawnKey();
                number.enabled = false;
            }
        } else if (gamePhase == Settings.GamePhase.KeySpawned) {
            textBox.text = keyText;
        } else if (gamePhase == Settings.GamePhase.ExitSpawned) {
            textBox.text = exitText;
        }
    }
}
