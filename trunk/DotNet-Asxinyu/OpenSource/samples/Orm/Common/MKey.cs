using Lephone.Data.Definition;

namespace OrmCommon
{
    public class MKey : IDbObject
    {
        [DbKey(IsDbGenerate = false), Length(50)]
        public string Name;

        [DbKey(IsDbGenerate = false)]
        public int Age;

        public bool Gender;

        public MKey()
        {
        }

        public MKey(string name, int age, bool gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public override string ToString()
        {
            return string.Format("Item:{0},{1},{2}", Name, Age, Gender);
        }
    }
}
