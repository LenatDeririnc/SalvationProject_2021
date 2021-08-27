using Managers.Scene;
using ScriptableObjects.Scenes;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Scene", "Load scene to spawnpoint", "Load scene with spawning player")]
    public class LoadSceneToSpawnpoint : Command
    {
        [SerializeField] private SpawnObject m_spawnObject;
        
        public override void OnEnter()
        {
            SceneLoaderManager.LoadSceneAndSpawnPlayer(m_spawnObject);
            
            Continue();
        }

        public override string GetSummary()
        {
            if (m_spawnObject == null)
                return $"not loaded spawn info";
            
            var scene = m_spawnObject.Scene();

            if (scene == null)
                return $"'scene' => 'null', 'spawnInfo' => {m_spawnObject}";
                
            return $"'scene' => {scene}, 'spawnInfo' => {m_spawnObject}";
        }
        
        public override Color GetButtonColor()
        {
            return new Color32(255, 181, 33, 255);
        }
    }
}