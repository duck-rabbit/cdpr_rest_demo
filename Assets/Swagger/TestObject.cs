using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace cdprRestDemo.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class TestObject {
    /// <summary>
    /// Gets or Sets StringProperty
    /// </summary>
    [DataMember(Name="stringProperty", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "stringProperty")]
    public string StringProperty { get; set; }

    /// <summary>
    /// Gets or Sets IntProperty
    /// </summary>
    [DataMember(Name="intProperty", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "intProperty")]
    public long? IntProperty { get; set; }

    /// <summary>
    /// Gets or Sets FloatProperty
    /// </summary>
    [DataMember(Name="floatProperty", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "floatProperty")]
    public decimal? FloatProperty { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TestObject {\n");
      sb.Append("  StringProperty: ").Append(StringProperty).Append("\n");
      sb.Append("  IntProperty: ").Append(IntProperty).Append("\n");
      sb.Append("  FloatProperty: ").Append(FloatProperty).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
