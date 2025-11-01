using UnityEditor;
using UnityEngine;

namespace HelpersAndExtensions.SaveSystem.Editor
{
    [CustomEditor(typeof(SaveLoadSystem))]
    public class SaveManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            SaveLoadSystem saveLoadSystem = (SaveLoadSystem) target;
            string gameName = saveLoadSystem.gameData.Name;

            DrawDefaultInspector();

            if (GUILayout.Button("New Game"))
            {
                saveLoadSystem.NewGame();
            }
            
            if (GUILayout.Button("Save Game"))
            {
                saveLoadSystem.SaveGame();
            }
            
            if (GUILayout.Button("Load Game"))
            {
                saveLoadSystem.LoadGame(gameName);
            }
            
            if (GUILayout.Button("Delete Game"))
            {
                saveLoadSystem.DeleteGame(gameName);
            }
            
            if (GUILayout.Button("Reload Game"))
            {
                saveLoadSystem.ReloadGame();
            }
            
            if (GUILayout.Button("Get Data Path"))
            {
                Debug.Log(Application.persistentDataPath);
            }
        }
    }
}
