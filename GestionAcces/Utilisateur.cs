using System.Text.RegularExpressions;

namespace GestionAcces
{
    public class Utilisateur
    {
        #region Properties
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public bool isAuthenticated { get; set; }
        public Identity identity { get; set; }

        #endregion

        #region Functions
        public void Register(List<Utilisateur> userBank)
        {
            if (Regex.IsMatch(firstName, @"\w{3}"))
                throw new Exception("champ non valid: veiller entrez au moins trois carractères!");

            if (Regex.IsMatch(lastName, @"\w{3}"))
                throw new Exception("champ non valid: veiller entrez au moins trois carractères!");

            if (Regex.IsMatch(login, @"\w{3}"))
                throw new Exception("champ non valid: veiller entrez au moins trois carractères!");

            if (Regex.IsMatch(password, @"\w{8}"))
                throw new Exception("champ non valid: veiller entrez au moins 8 carractères!");

            identity = new Identity { login = this.login, password = this.password };
            userBank.Add(this);
        }

        public void LogIn(string login, string password, List<Utilisateur> userBank)
        {
            bool isFind = false;
            foreach(var user in userBank)
            {
                if (login == user.login && password == user.password)
                {
                    isFind = true;
                    break;
                }
            }

            if (!isFind)
                throw new Exception("password ou login incorrect");
            isAuthenticated = true;
        }
        #endregion
    }
}