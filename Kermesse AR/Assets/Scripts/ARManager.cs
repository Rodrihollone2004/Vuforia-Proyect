using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ARManager : MonoBehaviour
{
    public GameObject gamesContent;
    [SerializeField] private float rotationSpeed = 5f;

    private List<GameObject> allGames = new List<GameObject>();
    private int indexGame;
    private float targetRotationZ = 0f;

    private void Start()
    {
        allGames.Clear();

        foreach (Transform child in gamesContent.transform)
        {
            allGames.Add(child.gameObject);

            child.gameObject.SetActive(true);
        }

        targetRotationZ = gamesContent.transform.localRotation.eulerAngles.z;
    }

    private void Update()
    {
        Quaternion targetTarget = Quaternion.Euler(0, 0, targetRotationZ);
        gamesContent.transform.localRotation = Quaternion.Lerp(
            gamesContent.transform.localRotation,
            targetTarget,
            Time.deltaTime * rotationSpeed
        );
    }

    public void NextGame()
    {
        indexGame++;
        if (indexGame > allGames.Count - 1)
            indexGame = 0;

        // Si tienes 4 objetos, cada paso es de 90 grados. 
        // Usamos 360 / cantidad de objetos para que sea dinámico.
        targetRotationZ -= 360f / allGames.Count;
    }

    public void PreviousGame()
    {
        indexGame--;
        if (indexGame < 0)
            indexGame = allGames.Count - 1;

        targetRotationZ += 360f / allGames.Count;
    }
}
