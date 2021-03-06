﻿using System;

namespace WrapIt
{
    internal class EventData : IEquatable<EventData>
    {
        public DelegateData Type { get; }

        public string Name { get; }

        public TypeData? DeclaringInterfaceType { get; set; }

        public EventData(DelegateData type, string name)
        {
            Type = type;
            Name = name;
        }

        public override int GetHashCode() => Name.GetHashCode() ^ Type.GetHashCode();

        public override bool Equals(object? obj) => Equals(obj as EventData);

        public bool Equals(EventData? other) => other != null && Name == other.Name && Type.Equals(other.Type);
    }
}