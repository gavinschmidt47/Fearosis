using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    public PlayerStartChoice playerStartChoice;
    public Sprite christmasMap;
    public Sprite halloweenMap;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        if (playerStartChoice.loading)
        {
            Saver saver = FindAnyObjectByType<Saver>();
            saver.LoadGame();
        }
        if (playerStartChoice.christmas)
        {
            GameObject.FindWithTag("Map").GetComponent<SpriteRenderer>().sprite = christmasMap;
        }
        if (playerStartChoice.halloween)
        {
            GameObject.FindWithTag("Map").GetComponent<SpriteRenderer>().sprite = halloweenMap;
        }

    }
}
