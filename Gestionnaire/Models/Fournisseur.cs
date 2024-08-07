using System.Text.RegularExpressions;

namespace Models
{
    public class Fournisseur
    {
        private string _Name = "";
        private string _Email = "";
        private int _Id = -1;
        private int _Tel = -1;
        public bool Command = false;


        public string Name 
        { 
            get 
            {
                return _Name;
            }
            set
            {      
                _Name = value.ToUpper();
            } 
        }
        
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                if (Regex.IsMatch(value, "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])"))
                {
                    _Email = value;
                }
                else
                {
                    throw new Exception("Email invalide");
                }
            }
        }
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (value%1!=0)
                {
                    throw new Exception("ID invalide");
                }
                _Id = value;
            }
        }
        public int Tel
        {
            get
            {
                return _Tel;
            }
            set
            { 
                _Tel = value;
            }
        }
    }
}
