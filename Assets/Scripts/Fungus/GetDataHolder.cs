using ScriptableObjects.Scenes;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Data Record", "Get Data", "Get data from static map")]
    public class GetDataHolder : Command
    {
        [SerializeField] private GameObjectDataHolder holder;
        
        [VariableProperty(AllVariableTypes.VariableAny.Any)]
        [SerializeField] private Variable variable;

        private AnyVariableAndDataPair varData = new AnyVariableAndDataPair();

        public override void OnEnter()
        {
            var value = holder.Value();

            if (!(value is null))
            {
                varData.variable = variable;
                varData.data = (AnyVariableData) value;
            }
            
            Continue();
        }
    }
}