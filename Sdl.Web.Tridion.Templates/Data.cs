﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sdl.Web.Common.Models.Data
{
    public class SummaryData
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("status")]
        public string Status;

        [JsonProperty("files")]
        public IEnumerable<string> Files;
    }

    public class BootstrapData
    {
        [JsonProperty("files")]
        public string[] Files;
    }


    public class VocabularyData
    {
        public string Prefix;
        public string Vocab;
    }

    public class SemanticSchemaData
    {
        public int Id;
        public string RootElement;
        public SemanticSchemaFieldData[] Fields;
        public SemanticTypeData[] Semantics;
    }

    public class SemanticTypeData
    {
        public string Prefix;
        public string Entity;

        #region Overrides
        public override bool Equals(object obj)
        {
            SemanticTypeData other = obj as SemanticTypeData;
            return other != null && other.Prefix == Prefix && other.Entity == Entity;
        }

        public override int GetHashCode()
        {
            return Prefix.GetHashCode() ^ Entity.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", Prefix, Entity);
        }
        #endregion
    }

    public class SemanticPropertyData : SemanticTypeData
    {
        [JsonProperty(Order = 1)]
        public string Property;

        #region Overrides
        public override bool Equals(object obj)
        {
            SemanticPropertyData other = obj as SemanticPropertyData;
            return other != null && base.Equals(other) && other.Property == Property;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ Property.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}", Prefix, Entity, Property);
        }
        #endregion
    }

    public class SemanticSchemaFieldData
    {
        public string Name;
        public string Path;
        public bool IsMultiValue;
        public SemanticPropertyData[] Semantics;
        public SemanticSchemaFieldData[] Fields;
    }

    public class XpmRegionData
    {
        public string Region;
        public List<XpmComponentTypeData> ComponentTypes;
    }

    public class XpmComponentTypeData
    {
        public string Schema;
        public string Template;
    }
}