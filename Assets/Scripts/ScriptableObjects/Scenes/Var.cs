using System;
using System.Collections.Generic;
using Managers.Data;
using UnityEngine;

namespace ScriptableObjects.Scenes
{
    public enum VarType
    {
        None,
        String,
        Int,
        Float,
        Bool,
    }

    public static class TypeConverter
    {
        public static readonly Dictionary<Type, VarType> TypeDictionary = new Dictionary<Type, VarType>
        {
            {typeof(string), VarType.String},
            {typeof(int), VarType.Int},
            {typeof(float), VarType.Float},
            {typeof(bool), VarType.Bool},
            {typeof(Nullable), VarType.None},
        };
        
        public static object CastValue(VarType T, object V)
        {
            V = T switch
            {
                VarType.None => null,
                VarType.String => (string) V,
                VarType.Int => (int) V,
                VarType.Float => (float) V,
                VarType.Bool => (bool) V,
                _ => throw new ArgumentOutOfRangeException(nameof(T), T, null)
            };

            return V;
        }
    }

    public struct CastedObject
    {
        public VarType Type { get; private set; }
        public object Value { get; private set; }

        public void SetValue(object obj)
        {
            Type = TypeConverter.TypeDictionary[obj.GetType()];
            Value = obj;
        }

        public CastedObject(VarType T, object V)
        {
            Type = T;
            Value = TypeConverter.CastValue(T, V);
        }
        
        public CastedObject(object V)
        {
            Type = TypeConverter.TypeDictionary[V.GetType()];
            Value = V;
        }

        public override string ToString()
        {
            return $"{Type}: {(string) Value}";
        }
    }

    [CreateAssetMenu(fileName = "var", menuName = "ScriptableObjects/Variable", order = 0)]
    public class Var : ScriptableObject
    {
        private static string MainContainerName = "__variables__";
        
        [SerializeField] private string startValue;
        [SerializeField] private VarType selectedType;

        public void SetValue(object V)
        {
            var varObject = new CastedObject(V);
            SceneDataManager.SetSceneValue(MainContainerName, name, varObject);
        }

        public object GetValue()
        {
            var value = SceneDataManager.SceneValue(MainContainerName, name) ?? new CastedObject(selectedType, startValue);
            var castedObject = (CastedObject) value;
            return castedObject.Value;
        }
    }
}