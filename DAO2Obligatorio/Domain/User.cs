
using Domain.Exceptions;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Domain
{
    public class User
    {
        private const int MIN_USERNAME_LENGTH = 5;
        private const int MAX_USERNAME_LENGTH = 50;
        private const int MIN_NAME_LENGTH = 3;
        private const int MAX_NAME_LENGTH = 50;
        private const int MIN_LAST_NAME_LENGTH = 3;
        private const int MAX_LAST_NAME_LENGTH = 50;
        private const int MIN_PASSWORD_LENGTH = 8;
        private readonly DateTime MIN_BIRTH_DAY = new DateTime(1940, 1, 1);
        private string _password;
        private string _userName;
        private string _name;
        private string _lastName;
        private DateTime _birthDay;

        public User()
        {
        }

        public int Id { get; set; }

        public string Password
        {
            get => this._password;
            set
            {
                IsNullOrEmptyAndAlphaNumeric(value, "contraseña");
                ValidatePasswordLength(value);
                this._password = value;
            }
        }

        public void ValidatePasswordToSet()
        {
            IsNullOrEmptyAndAlphaNumeric(_password, "contraseña");
            ValidatePasswordLength(_password);
        }

        public void SavePasswordHashed()
        {
            _password = HashPassword(_password);
        }

        public void ValidatePasswordLength(string password)
        {
            if (password.Length < MIN_PASSWORD_LENGTH)
            {
                throw new InvalidLengthOfFieldException("La contraseña debe ser mayor o igual a: " + MIN_PASSWORD_LENGTH);
            }
        }

        public void ValidatePasword(string passwordToValidate)
        {
            var passwordToValidateHashed = HashPassword(passwordToValidate);

            StringComparer comparer = StringComparer.Ordinal;

            if (!(comparer.Compare(passwordToValidateHashed, _password) == 0))
            {
                throw new InvalidLogicException("Password incorrecta");
            }
        }

        public string UserName
        {
            get => this._userName;
            set
            {
                IsValidUserName(value);
                this._userName = value;
            }
        }

        public void IsValidUserName(string username)
        {
            IsNullOrEmptyAndAlphaNumeric(username, "nombre de usuario");
            IsValidUserNameLength(username);
        }

        public void IsNullOrEmptyAndAlphaNumeric(string value, string field)
        {
            StringUtils.IsNullOrEmpty(value, field);
            StringUtils.IsAlphaNumeric(value, field);
        }

        public void IsValidUserNameLength(string username)
        {
            if (!(username.Length >= MIN_USERNAME_LENGTH && username.Length <= MAX_USERNAME_LENGTH))
            {
                throw new InvalidLengthOfFieldException("El nombre de usuario debe ser mayor o igual que: " + MIN_USERNAME_LENGTH + " y menor o igual que: " + MAX_USERNAME_LENGTH);
            }
        }

        private string HashPassword(String passwordToHash)
        {
            var sBuilder = new StringBuilder();
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(passwordToHash));
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }
            return sBuilder.ToString();
        }

        public string Name
        {
            get => this._name;
            set
            {
                IsValidName(value);
                this._name = value;
            }
        }

        public void IsValidName(string name)
        {
            IsNullOrEmptyAndAlphaNumeric(name, "nombre");
            HasValidNameLength(name);
        }

        public void HasValidNameLength(string name)
        {
            if (!(name.Length >= MIN_NAME_LENGTH && name.Length <= MAX_NAME_LENGTH))
            {
                throw new InvalidLengthOfFieldException("El nombre debe ser mayor o igual que: " + MIN_NAME_LENGTH + " y menor o igual que: " + MAX_NAME_LENGTH);
            }
        }

        public void IsValidLastName(string name)
        {
            IsNullOrEmptyAndAlphaNumeric(name, "apellido");
            HasValidLastNameLength(name);
        }

        public void HasValidLastNameLength(string name)
        {
            if (!(name.Length >= MIN_LAST_NAME_LENGTH && name.Length <= MAX_LAST_NAME_LENGTH))
            {
                throw new InvalidLengthOfFieldException("El apellido debe ser mayor o igual que: " + MIN_LAST_NAME_LENGTH + " y menor o igual que: " + MAX_LAST_NAME_LENGTH);
            }
        }

        public string LastName
        {
            get => this._lastName;
            set
            {
                IsValidLastName(value);
                this._lastName = value;
            }
        }

        public DateTime BirthDay
        {
            get => this._birthDay;
            set
            {
                this._birthDay = value;
            }
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(MIN_BIRTH_DAY);
            hash.Add(_password);
            hash.Add(_userName);
            hash.Add(_name);
            hash.Add(_lastName);
            hash.Add(_birthDay);
            hash.Add(Id);
            hash.Add(Password);
            hash.Add(UserName);
            hash.Add(Name);
            hash.Add(LastName);
            hash.Add(BirthDay);
            return hash.ToHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            return Id == ((User)obj).Id;
        }

    }
}
