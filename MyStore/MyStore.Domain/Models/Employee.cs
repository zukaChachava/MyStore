using System;
using System.Reflection;

namespace MyStore.Domain.Models
{
    public class Employee : BaseModel
    {
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        
        public string PersonalID { get; set; }
        
        public string Phone { get; set; }
        
        public string Email { get; set; }
        
        public string HomeAddress { get; set; }
        
        public DateTime? StartJob { get; set; }
        
        public DateTime? EndJob { get; set; }

        // TODO: Do not like this :(
        public User GenerateUser()
        {
            User user = new();
            Type userType = user.GetType();
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                PropertyInfo userProperty =  userType.GetProperty(property.Name);
                if (userProperty != null)
                    userProperty.SetValue(user, property.GetValue(this));
            }

            return user;
        }

        public override string ToString()
        {
            return $"{PersonalID} {Lastname}";
        }
    }
}