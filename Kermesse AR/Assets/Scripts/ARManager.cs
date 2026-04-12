using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ARManager : MonoBehaviour
{
    public GameObject gamesContent;

    private List<GameObject> allGames = new List<GameObject>();
    private int indexGame;

    private void Start()
    {
        allGames.Clear();

        foreach (Transform child in gamesContent.transform)
        {
            GameObject gameObj = child.gameObject;

            allGames.Add(gameObj);

            gameObj.SetActive(false);
        }

        if (allGames.Count > 0)
            allGames[indexGame].SetActive(true);
    }

    public void NextGame()
    {
        indexGame++;

        if (indexGame > allGames.Count - 1)
            indexGame = 0;

        foreach (GameObject game in allGames)
            game.SetActive(false);

        allGames[indexGame].SetActive(true);
    }

    public void PreviousGame()
    {
        indexGame--;

        if (indexGame < 0)
            indexGame = allGames.Count - 1;

        foreach (GameObject game in allGames)
            game.SetActive(false);

        allGames[indexGame].SetActive(true);
    }
}
