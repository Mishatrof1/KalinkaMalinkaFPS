using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.Collections.Generic;
using UnityEditor;

namespace Project.Editor.Windows
{
    public class SceneSelectorWindow : OdinEditorWindow
    {
        [ListDrawerSettings(HideAddButton = true, HideRemoveButton = true, Expanded = true, IsReadOnly = true, DraggableItems = false, NumberOfItemsPerPage = int.MaxValue)]
        public List<SceneDefinition> SceneNames;

        [MenuItem("Project/Scene Selector")]
        public static void Open()
        {
            GetWindow<SceneSelectorWindow>("Scene Selector");
        }

        protected override void Initialize()
        {
            Refresh();
        }

        [Button(ButtonSizes.Large)]
        private void Refresh()
        {
            SceneNames = new List<SceneDefinition>();

            for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
                SceneNames.Add(new SceneDefinition(EditorBuildSettings.scenes[i].path));
        }
    }
}
