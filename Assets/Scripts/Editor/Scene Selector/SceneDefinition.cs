using Sirenix.OdinInspector;
using UnityEditor.SceneManagement;

namespace Project.Editor.Windows
{
    public struct SceneDefinition
    {
        [HideIf("@true")]
        public string Path;

        [ReadOnly, HideLabel, HorizontalGroup]
        public string Name;

        public SceneDefinition(string path)
        {
            Path = path;
            Name = System.IO.Path.GetFileNameWithoutExtension(Path);
        }

        [Button("Load"), HorizontalGroup]
        public void Load()
        {
            EditorSceneManager.OpenScene(Path, OpenSceneMode.Single);
        }
    }
}
