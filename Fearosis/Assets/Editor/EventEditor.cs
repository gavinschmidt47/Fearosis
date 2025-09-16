using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Event))]
public class EventEditor : Editor
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Event myEvent = (Event)target;
        
        //labels and buttons
        EditorGUILayout.LabelField("Select one of these to see the stat/source menu");
        //toggles to use for later on
        myEvent.targetsStats = EditorGUILayout.Toggle("Targets Stats", myEvent.targetsStats);

        myEvent.targetsSource = EditorGUILayout.Toggle("Targets a Source", myEvent.targetsSource);

        //keeps stuff meant to be hidden, hidden
        if (myEvent.targetsStats == false && myEvent.targetsSource == false){
            return;
        }

        //brings up the enum menu for stats
        if (myEvent.targetsStats){
            myEvent.targetStats = (Event.TargetStats)EditorGUILayout.EnumPopup("Select Stat", myEvent.targetStats);
        }

        //brings up the enum menu for source
        if (myEvent.targetsSource){
            myEvent.targetSource = (Event.TargetSource)EditorGUILayout.EnumPopup("Select Source", myEvent.targetSource);
        }

    }

}
