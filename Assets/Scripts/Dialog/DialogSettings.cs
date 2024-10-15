using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialog", menuName = "New Dialog/Dialog")]
public class DialogSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialog")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogs = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
}

#if UNITY_EDITOR
[CustomEditor(typeof(DialogSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogSettings ds = (DialogSettings)target;

        Languages l = new Languages();
        l.portuguese = ds.sentence;

        Sentences s = new Sentences();
        s.profile = ds.speakerSprite;
        s.sentence = l;

        if(GUILayout.Button("Create Dialog"))
        {
            if(ds.sentence != "")
            {
                ds.dialogs.Add(s);

                ds.speakerSprite = null;
                ds.sentence = "";
            }
        }
    }
}


#endif