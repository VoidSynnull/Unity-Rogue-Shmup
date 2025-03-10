using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public static CharacterSelect instance;
    public CharacterSO characterSO;
    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    public static CharacterSO GetData() {
        return instance.characterSO;
    }

    public void SelectCharacter(CharacterSO characterData) {
        characterSO = characterData;
    }

    public void DestroySingleton() {
        instance = null;
        Destroy(gameObject);
    }
}
