using Managers.Scene;
using ScriptableObjects.Scenes;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Scene", "Load scene", "Load scene without spawning player")]
    public class LoadScene : Command
    {
        [SerializeField] private SceneInfo scene;
        
        public override void OnEnter()
        {
            SceneLoaderManager.LoadScene(scene);
            
            Continue();
        }

        public override string GetSummary()
        {
            if (scene == null)
                return $"'scene' => 'null'";
                
            return $"'scene' => {scene}";
        }
        
        public override Color GetButtonColor()
        {
            return new Color32(255, 181, 33, 255);
        }
    }
}