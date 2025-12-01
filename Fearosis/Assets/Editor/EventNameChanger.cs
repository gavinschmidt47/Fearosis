using UnityEngine;
using UnityEditor;

public class EventNameChanger : Editor
{
    [MenuItem("Tools/Rename All Events To eventName")]
    static void RenameAllEvents()
    {
        // Find all Event components in the loaded scene(s)
        Event[] events = Resources.FindObjectsOfTypeAll<Event>();
        int count = 0;

        foreach (Event evt in events)
        {
            evt.gameObject.SetActive(true);
            // Only rename if current name differs
            if (evt.gameObject.name != evt.eventName + " Event")
            {
                Undo.RecordObject(evt.gameObject, "Rename Event GameObject");
                evt.gameObject.name = evt.eventName + " Event";

                EditorUtility.SetDirty(evt.gameObject); // Ensure the scene registers the change
                count++;
            }
        }

        // Optionally mark entire scene dirty for save
        if (count > 0)
        {
            UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
        }
    }
}
