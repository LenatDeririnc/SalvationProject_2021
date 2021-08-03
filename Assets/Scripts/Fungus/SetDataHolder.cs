using ScriptableObjects.Scenes;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Data Record", "Set Data", "Set data into static map")]
    [AddComponentMenu("")]
    public class SetDataHolder : Command
    {
        [VariableProperty(AllVariableTypes.VariableAny.Any)]
        [SerializeField] protected Variable anyVar;
        
        [SerializeField] protected GameObjectDataHolder holder;

        private AnyVariableAndDataPair anyData = new AnyVariableAndDataPair();

        public override void OnEnter()
        {
            anyData.variable = anyVar;
            
            holder.SetObjectValue(anyData.data);
            
            Continue();
        }

    }
}
