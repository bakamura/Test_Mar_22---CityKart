using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalResultsManager : MonoBehaviour {
    [SerializeField] private MeshRenderer[] trophies = new MeshRenderer[3];
    [SerializeField] private Transform[] playerPlaces = new Transform[4];
    [SerializeField] private GameObject Podium;

    public void SetPodium() {
        for (int i = 0; i < GameManager.finalResults.Length; i++) {
            if (i < trophies.Length - 1) trophies[i].enabled = true;
            Instantiate(GameManager.finalResults[i].GetComponent<PlayerData>().baseModel, playerPlaces[i].position, Quaternion.Euler(playerPlaces[i].forward));
            //Instantiate(GameManager.finalResults[i], playerPlaces[i]).GetComponent<PlayerData>().PodiumSetUp();
            Podium.SetActive(true);
        }
    }
}
