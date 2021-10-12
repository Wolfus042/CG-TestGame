using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings current;
    public float tickingTimer = -1f;
    public float spawnTime = 5f;
    public List<Transform> allSpawnPoints;
    public int occupiedPoint = -1;

    public int currentFloorTint = -1;
    public Renderer floorRenderer;
    public List<Material> floorTints;

    public GameObject nextButtonObject;

    public Transform itemsTransform;

    public GameObject key;
    public GameObject exit;

    public enum GamePhase {
        Waiting,
        KeySpawned,
        ExitSpawned
    }

    public GamePhase gamePhase;

    private void Awake() {
        current = this;
    }

    public void RestartGame() {
        tickingTimer = -1f;
        gamePhase = GamePhase.Waiting;
        SelectNextLevelTint();
        nextButtonObject.SetActive(false);

    }

    public GamePhase GetGamePhase() {
        return gamePhase;
    }

    public void SpawnKey() {
        gamePhase = GamePhase.KeySpawned;
        Instantiate(key, selectSpawnPoint(allSpawnPoints, occupiedPoint).position, Quaternion.identity, itemsTransform);
    }

    public void SpawnExit() {
        gamePhase = GamePhase.ExitSpawned;
        Instantiate(exit, selectSpawnPoint(allSpawnPoints, occupiedPoint).position, Quaternion.identity, itemsTransform);
    }

    public void EndGame() {
        nextButtonObject.SetActive(true);
        Debug.Log("u good!");
    }

    public void SelectNextLevelTint() {
        if (floorTints.Count == 0) {
            Debug.LogError("not enough level tints");
        } else {
            currentFloorTint++;
            currentFloorTint %= floorTints.Count;
            floorRenderer.material = floorTints[currentFloorTint];
        }
    }

    private Transform selectSpawnPoint(List<Transform> list, int occupiedPoint) {
        int random = 0;
        int iterator = 0;

        if (list.Count > 2)
        do {
            random = Random.Range(0, list.Count);
            iterator++;
        } while ((random == occupiedPoint) || (iterator >= 50));


        Debug.Log("selected "+random.ToString()+", prev "+occupiedPoint.ToString());
        Settings.current.occupiedPoint = random;

        
        return list[random];
    }

}
