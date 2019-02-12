﻿using System;
using NuGet.Versioning;

namespace NuGetPackageExplorer.Types
{
    public enum PackageType
    {
        LocalPackage,
        RemotePackage
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized.
    public sealed class MruItem : IEquatable<MruItem>
#pragma warning restore CS8618 // Non-nullable field is uninitialized.
    {
        public string Id { get; set; }
        public NuGetVersion Version { get; set; }
        public string Path { get; set; }
        public PackageType PackageType { get; set; }

        #region IEquatable<MruItem> Members

        public bool Equals(MruItem other)
        {
            if (other == null)
            {
                return false;
            }
            return string.Equals(Path, other.Path, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(Id, other.Id, StringComparison.OrdinalIgnoreCase) &&
                Version == other.Version;
        }

        #endregion

        public override bool Equals(object obj)
        {
            return obj is MruItem item && Equals(item);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Path, Id, Version).GetHashCode();
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                return string.Format("{0} {1}", Id, Version);
            }
            return Path ?? "MruItem";
        }
    }
}
