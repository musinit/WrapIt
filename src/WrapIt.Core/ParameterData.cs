﻿using System;

namespace WrapIt
{
    internal class ParameterData : IEquatable<ParameterData>
    {
        public TypeData Type { get; }

        public string Name { get; }

        public bool IsOut { get; }

        public ParameterData(TypeData type, string name, bool isOut)
        {
            Type = type;
            Name = name;
            IsOut = isOut;
        }

        public string GetAsInterfaceParameter() => $"{(Type.Type.IsByRef ? (IsOut ? "out " : "ref ") : string.Empty)}{Type.InterfaceName} {Name}";

        public string GetAsClassParameter() => $"{(Type.Type.IsByRef ? (IsOut ? "out " : "ref ") : string.Empty)}{Type.ClassName} {Name}";

        public string GetAsArgument() => $"{(Type.Type.IsByRef ? (IsOut ? "out " : "ref ") : string.Empty)}{Name}";

        public string GetCodeToConvertToActualType() => $"{(Type.Type.IsByRef ? (IsOut ? "out " : "ref ") : string.Empty)}{Type.GetCodeToConvertToActualType(Name)}";

        public string GetCodeToConvertToClassType() => $"{(Type.Type.IsByRef ? (IsOut ? "out " : "ref ") : string.Empty)}{Type.GetCodeToConvertToClassType(Name)}";

        public override int GetHashCode() => Name.GetHashCode() ^ Type.GetHashCode();

        public override bool Equals(object? obj) => Equals(obj as ParameterData);

        public bool Equals(ParameterData? other) => other != null && Name == other.Name && Type.Equals(other.Type) && IsOut == other.IsOut;
    }
}