using UnityEngine;
using Scene = UnityEngine.SceneManagement.Scene;

[CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObjects/SceneData", order = 1)]
public class SceneData : ScriptableObject
{
    private Scene scene;
}
