using UnityEngine;

public class DayCharacter : Character
{
    private CharacterSpriteSelector characterSpriteSelector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        characterSpriteSelector = GetComponent<CharacterSpriteSelector>();
        if (characterSpriteSelector == null)
        {
            Debug.LogError("CharacterSpriteSelector component not found on DayCharacter.");
        }
        base.Awake();
    }

    void OnEnable()
    {
        characterSpriteSelector.PickCharacter(spriteRenderer, animator);
    }
}
