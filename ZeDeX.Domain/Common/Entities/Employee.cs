using ZeDeX.Domain.Common.Exceptions;

namespace ZeDeX.Domain.Common.Entities
{
    public class Employee : EntityBase
    {
        private const int _maxFirstNameLength = 30;
        private const int _maxLastNameLength = 200;
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get => firstName;
            set
            {
                if (value != null && value.Length <= _maxFirstNameLength) firstName = value;
                else throw new DomainException($"first name longer than {_maxFirstNameLength} characters");
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (value != null && value.Length <= _maxLastNameLength) lastName = value;
                else throw new DomainException($"last name longer than {_maxLastNameLength} characters");
            }
        }


    }
}
