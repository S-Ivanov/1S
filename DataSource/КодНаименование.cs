using System;

namespace DataSource
{
    public class КодНаименование : IEquatable<КодНаименование>
    {
        public int Код { get; set; }
        public string Наименование { get; set; }

        public bool Equals(КодНаименование other)
        {
            return other == null ? false : this.Код == other.Код && this.Наименование == other.Наименование;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as КодНаименование);
        }

        public override int GetHashCode()
        {
            return Код;
        }
    }
}
