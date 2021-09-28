namespace _053506_Ermolaev_Lab8.Entities
{
    class Employee
    {

        public Employee(int age, string name, bool higherEducation)
        {
            Age = age;
            Name = name;
            HigherEducation = higherEducation;
        }
        public int Age { get; set; }

        public string Name { get; set; }

        public bool HigherEducation { get; set; }

        public override string ToString()
        {
            string education = HigherEducation ? "with higher education" : "without higher education";
            return $"{Name} is {Age} years old {education}";
        }
    }
}
