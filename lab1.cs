namespace labs;
using System;

class Student : IEquatable<Student>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Patronymic { get; }
    public string Group { get; }
    public string Course { get; }

    public Student(string firstName, string lastName, string patronymic, string group, string course)
    {
        if (string.IsNullOrEmpty(firstName))
            throw new ArgumentNullException(nameof(firstName));
        if (string.IsNullOrEmpty(lastName))
            throw new ArgumentNullException(nameof(lastName));
        if (string.IsNullOrEmpty(patronymic))
            throw new ArgumentNullException(nameof(patronymic));
        if (string.IsNullOrEmpty(group))
            throw new ArgumentNullException(nameof(group));
        if (string.IsNullOrEmpty(course))
            throw new ArgumentNullException(nameof(course));

        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Group = group;
        Course = course;
    }

    public int GetCourseNumber()
    {
        var year = int.Parse(Group.Substring(Group.Length - 4, 4));
        return DateTime.Now.Year - year + 1;
    }

    public override string ToString()
    {
        return $"{LastName} {FirstName} {Patronymic}, группа: {Group}, курс: {Course}";
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        return Equals((Student)obj);
    }

    public bool Equals(Student other)
    {
        if (other == null)
            return false;

        return FirstName == other.FirstName &&
               LastName == other.LastName &&
               Patronymic == other.Patronymic &&
               Group == other.Group &&
               Course == other.Course;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, Patronymic, Group, Course);
    }
}
