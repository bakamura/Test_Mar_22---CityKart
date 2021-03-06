using System.Collections.Generic;
using System;
using UnityEngine;

public static class GameManager {
    [Header("Players Info")]
    [NonSerialized] public const int MaxPlayers = 4;
    [NonSerialized] public static List<GameObject> playerCars = new List<GameObject>();
    [NonSerialized] public static List<InputData> playerInputs = new List<InputData>();
    [NonSerialized] public static GameObject[] finalResults;// 0 = first place, 1 = second place...

    [Header("Base Car status")]
    public const float MaxVelocity = 2500f;
    public const float MinVelocity = 1f;
    //in degrees
    public const float MaxHandling = 90f;
    public const float MinHandling = 10f;
    //in degrees
    public const float MaxDrift = 45f;
    public const float MinDrift = 15f;

    public const float MaxWeight = 1000f;
    public const float MinWeight = 1f;

    [Header("Item Status")]
    public const float boostForce = 1.75f;
    public const float jumpForce = 15f;
    public const float teleportRange = 5f;
    public const float shieldAnimSpeed = .02f;
    public const float invertControlsEffectDuration = 3f;//The amount of time the effect lasts
    public const float invertControlsDistance = 10f;
    public const float breakEffectDuration = 2f;//The amount of time the effect lasts
    public const float drillSpeed = 5f;
    public const float drillDuration = 4f;//The amount of time the drill stays in scene
    public const float itemBoxResawnTime = 10f;
    public static List<IObjectPollingManager> OilPoolsList;
    public static List<IObjectPollingManager> DrillList;

    public static int MaxPowerUpInScene(int itemType) {//the max amount of items prefabs for each prefab item that exist
        switch (itemType) {
            case 6:
                return 4 * playerCars.Count;
            case 7:
                return 6 * playerCars.Count;
            default:
                Debug.Log("the item" + itemType + "doesnt exist");
                return 0;
        }
    }
    public static void CheckCarStatus(PlayerData status) {
        status.Velocity = Mathf.Clamp(status.Velocity, MinVelocity, MaxVelocity);
        status.ReverseVelocity = Mathf.Clamp(status.ReverseVelocity, MinVelocity, MaxVelocity);
        status.TurningDegrees = Mathf.Clamp(status.TurningDegrees, MinHandling, MaxHandling);
        status.DriftAngle = Mathf.Clamp(status.DriftAngle, MinDrift, MaxDrift);
        status.rb.mass = Mathf.Clamp(status.rb.mass, MinWeight, MaxWeight);
    }

    public static void ClearMatchInfo() {
        playerCars.Clear();
        playerInputs.Clear();
        finalResults = new GameObject[0];
    }

}