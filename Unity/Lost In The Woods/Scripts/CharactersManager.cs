using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharactersManager : MonoBehaviour
{
    public GameObject[] Characters;
    public TMP_Text characterCostText;

    public string gameSceneName = "CharacterMenu";
    public int selectedCharacterIndex;

    private string selectedCharacterDataName = "Selected Character";
    private string currentCharacterCost;

    private string unlockedCharactersFilePath;


    void Start()
    {
        HideAllCharacters();

        selectedCharacterIndex = PlayerPrefs.GetInt(selectedCharacterDataName, 0);

        Characters[selectedCharacterIndex].SetActive(true);

        updateCharacterCost();
/*
        if (File.Exists(unlockedCharactersFilePath))
        {
            string json = File.ReadAllText(unlockedCharactersFilePath);
            unlockedCharactersFilePath = JsonUtility.FromJson<unlockedCharacters>(.json);
        }
        else
        {
            Characters = $"{Application.persistentDataPath}/unlockedCharacters.json";
        }
*/
    }

    private void Update()
    {
        updateCharacterCost();
    }

    private void HideAllCharacters()
    {
        foreach (GameObject character in Characters)
        {
            
            character.SetActive(false);
        }
    }

    public void NextCharacter()
    {
        Characters[selectedCharacterIndex].SetActive(false);
        selectedCharacterIndex++;

        if(selectedCharacterIndex >= Characters.Length)
        {
            selectedCharacterIndex = 0;
        }

        Characters[selectedCharacterIndex].SetActive(true);

        //updateCharacterCost();
    }

    public void PreviusCharacter()
    {
        Characters[selectedCharacterIndex].SetActive(false);
        selectedCharacterIndex--;

        if (selectedCharacterIndex < 0)
        {
            selectedCharacterIndex = Characters.Length - 1;
        }

        Characters[selectedCharacterIndex].SetActive(true);

        //updateCharacterCost();
    }

    //now it's free, change it later with coins
    public void SelectCharacter()
    {
        if (Characters[selectedCharacterIndex].GetComponent<CharacterCost>().isOwnedByPlayer)
        {
            PlayerPrefs.SetInt(selectedCharacterDataName, selectedCharacterIndex);
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            //acquistalo
            if (PlayerPrefs.GetInt("TotalCoins") >= Characters[selectedCharacterIndex].GetComponent<CharacterCost>().cost)
            {
                PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - Characters[selectedCharacterIndex].GetComponent<CharacterCost>().cost);

                Characters[selectedCharacterIndex].GetComponent<CharacterCost>().isOwnedByPlayer = true;
            }
            else
            {
                //tratteggia la scritta di rosso
                characterCostText.color = Color.red;

                //riproduci suono di errore
            }
        }
    }

    private void updateCharacterCost()
    {
        if (Characters[selectedCharacterIndex].GetComponent<CharacterCost>().isOwnedByPlayer)
        {
            characterCostText.SetText("Play");

        }
        else 
        {
            currentCharacterCost = Characters[selectedCharacterIndex].GetComponent<CharacterCost>().cost.ToString();

            characterCostText.SetText(currentCharacterCost);
        }
        
    }

}
