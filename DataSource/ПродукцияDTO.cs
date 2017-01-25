using System;

namespace DataSource
{
    public class ПродукцияDTO : КодНаименование, IEquatable<ПродукцияDTO>
    {
        public КомпанияDTO Компания { get; set; }

        public bool Equals(ПродукцияDTO other)
        {
            bool result = (this as КодНаименование).Equals(other as КодНаименование);
            if (result && this.Компания != null && other.Компания != null)
                result = this.Компания.Equals(other.Компания);
            return result;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ПродукцияDTO);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
