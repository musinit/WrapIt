﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WrapIt
{
    internal class MethodData : IEquatable<MethodData>
    {
        public string Name { get; }

        public TypeData ReturnType { get; }

        public List<ParameterData> Parameters { get; } = new List<ParameterData>();

        public bool OverrideObject { get; }

        public TypeData? DeclaringInterfaceType { get; set; }

        public MethodData(string name, TypeData returnType, List<ParameterData> parameters, bool overrideObject)
        {
            Name = name;
            ReturnType = returnType;
            Parameters = parameters;
            OverrideObject = overrideObject;
        }

        public override int GetHashCode() => Name.GetHashCode() ^ ReturnType.GetHashCode();

        public override bool Equals(object? obj) => Equals(obj as MethodData);

        public bool Equals(MethodData? other) => other != null && Name == other.Name && ReturnType.Equals(other.ReturnType) && Parameters.Count == other.Parameters.Count && Parameters.Select((p, i) => (p, i)).All(t => t.p.Equals(other.Parameters[t.i]));
    }
}