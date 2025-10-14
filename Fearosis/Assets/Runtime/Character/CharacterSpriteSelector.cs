using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class CharacterSpriteSelector : MonoBehaviour
{
    public List<CharacterVisuals> characterVisualsList;

    public void PickCharacter(SpriteRenderer spriteRenderer, Animator animator)
    {
        int randomIndex = Random.Range(0, characterVisualsList.Count);
        SetCharacterVisuals(characterVisualsList[randomIndex], spriteRenderer, animator);
    }

    private void SetCharacterVisuals(CharacterVisuals visuals, SpriteRenderer spriteRenderer, Animator animator)
    {
        spriteRenderer.sprite = visuals.daySprite;
        animator.runtimeAnimatorController = visuals.dayAnimation;
    }
}
