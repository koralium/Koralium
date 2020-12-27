
namespace Apache.Arrow.Types
{
    public sealed class ListType : NestedType
    {
        public override ArrowTypeId TypeId => ArrowTypeId.List;
        public override string Name => "list";

        public Field ValueField => Fields[0];

        public IArrowType ValueDataType => Fields[0].DataType;

        public ListType(Field valueField)
           : base(valueField) { }

        public ListType(IArrowType valueDataType)
            : this(new Field("item", valueDataType, true)) { }

        public override void Accept(IArrowTypeVisitor visitor) => Accept(this, visitor);
    }
}
