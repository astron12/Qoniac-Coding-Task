// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/convert.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace CodingTaskServer {

  /// <summary>Holder for reflection information generated from Protos/convert.proto</summary>
  public static partial class ConvertReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/convert.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ConvertReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChRQcm90b3MvY29udmVydC5wcm90bxIHY29udmVydCIkCgtXb3JkUmVxdWVz",
            "dBIVCg1udW1lcmljQW1vdW50GAEgASgJIkIKCVdvcmRSZXBseRIVCg1hbW91",
            "bnRJbldvcmRzGAEgASgJEh4KFnZhbGlkYXRlZE51bWVyaWNBbW91bnQYAiAB",
            "KAkyTwoRQ3VycmVuY3lDb252ZXJ0ZXISOgoOQ29udmVydFRvV29yZHMSFC5j",
            "b252ZXJ0LldvcmRSZXF1ZXN0GhIuY29udmVydC5Xb3JkUmVwbHlCE6oCEENv",
            "ZGluZ1Rhc2tTZXJ2ZXJiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CodingTaskServer.WordRequest), global::CodingTaskServer.WordRequest.Parser, new[]{ "NumericAmount" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CodingTaskServer.WordReply), global::CodingTaskServer.WordReply.Parser, new[]{ "AmountInWords", "ValidatedNumericAmount" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class WordRequest : pb::IMessage<WordRequest>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<WordRequest> _parser = new pb::MessageParser<WordRequest>(() => new WordRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<WordRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CodingTaskServer.ConvertReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WordRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WordRequest(WordRequest other) : this() {
      numericAmount_ = other.numericAmount_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WordRequest Clone() {
      return new WordRequest(this);
    }

    /// <summary>Field number for the "numericAmount" field.</summary>
    public const int NumericAmountFieldNumber = 1;
    private string numericAmount_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string NumericAmount {
      get { return numericAmount_; }
      set {
        numericAmount_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as WordRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(WordRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (NumericAmount != other.NumericAmount) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (NumericAmount.Length != 0) hash ^= NumericAmount.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (NumericAmount.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(NumericAmount);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (NumericAmount.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(NumericAmount);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (NumericAmount.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(NumericAmount);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(WordRequest other) {
      if (other == null) {
        return;
      }
      if (other.NumericAmount.Length != 0) {
        NumericAmount = other.NumericAmount;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            NumericAmount = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            NumericAmount = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class WordReply : pb::IMessage<WordReply>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<WordReply> _parser = new pb::MessageParser<WordReply>(() => new WordReply());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<WordReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CodingTaskServer.ConvertReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WordReply() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WordReply(WordReply other) : this() {
      amountInWords_ = other.amountInWords_;
      validatedNumericAmount_ = other.validatedNumericAmount_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WordReply Clone() {
      return new WordReply(this);
    }

    /// <summary>Field number for the "amountInWords" field.</summary>
    public const int AmountInWordsFieldNumber = 1;
    private string amountInWords_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string AmountInWords {
      get { return amountInWords_; }
      set {
        amountInWords_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "validatedNumericAmount" field.</summary>
    public const int ValidatedNumericAmountFieldNumber = 2;
    private string validatedNumericAmount_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ValidatedNumericAmount {
      get { return validatedNumericAmount_; }
      set {
        validatedNumericAmount_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as WordReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(WordReply other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (AmountInWords != other.AmountInWords) return false;
      if (ValidatedNumericAmount != other.ValidatedNumericAmount) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (AmountInWords.Length != 0) hash ^= AmountInWords.GetHashCode();
      if (ValidatedNumericAmount.Length != 0) hash ^= ValidatedNumericAmount.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (AmountInWords.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(AmountInWords);
      }
      if (ValidatedNumericAmount.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ValidatedNumericAmount);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (AmountInWords.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(AmountInWords);
      }
      if (ValidatedNumericAmount.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ValidatedNumericAmount);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (AmountInWords.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(AmountInWords);
      }
      if (ValidatedNumericAmount.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ValidatedNumericAmount);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(WordReply other) {
      if (other == null) {
        return;
      }
      if (other.AmountInWords.Length != 0) {
        AmountInWords = other.AmountInWords;
      }
      if (other.ValidatedNumericAmount.Length != 0) {
        ValidatedNumericAmount = other.ValidatedNumericAmount;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            AmountInWords = input.ReadString();
            break;
          }
          case 18: {
            ValidatedNumericAmount = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            AmountInWords = input.ReadString();
            break;
          }
          case 18: {
            ValidatedNumericAmount = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
