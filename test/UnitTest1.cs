using Microsoft.VisualStudio.TestTools.UnitTesting;

using protect_inf_LR1;
using System;
using System.Collections.Generic;


namespace test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAuth()
        {
            List<User> list = new List<User>();
            list = Serializer.LoadFromFile("users.txt");
            string login = "admin";
            string password = "admin";
            bool good = false;
            foreach (var usr in list)
            {
                if (usr.login == login && usr.password == password)
                {
                    good = true;
                }
            }
            Assert.AreEqual(good, true);
        }
        [TestMethod]
        public void TestRegister()
        {
            User user = new User();
            List<User> list = new List<User>();
            list = Serializer.LoadFromFile("users.txt");
            string login = "admin1";
            string password = "admin1";
            user.login = login;
            user.password = password;
            list.Add(user);
            bool good = false;
            foreach (var usr in list)
            {
                if (usr.login == login && usr.password == password)
                {
                    good = true;
                }
            }
            Assert.AreEqual(good, true);
        }
        [TestMethod]
        public void TestAuthFalse()
        {
            List<User> list = new List<User>();
            list = Serializer.LoadFromFile("users.txt");
            string login = "admin55";
            string password = "admin55";
            bool good = false;
            foreach (var usr in list)
            {
                if (usr.login == login && usr.password == password)
                {
                    good = true;
                }
            }
            Assert.AreEqual(good, false);
        }
        [TestMethod]
        public void TestEncrypt()
        {
            char[] characters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                            'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                            'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                            'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                            '8', '9', '0' };
            string input = "человек";
            string keyword = "река";
            input = input.ToUpper();
            keyword = keyword.ToUpper();
            string expected = "8ЙЦЯЖПЫ";
            bool good = false;
            int keyword_index = 0;
            string result = "";
            int N = characters.Length;
            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(characters, symbol) +
                Array.IndexOf(characters, keyword[keyword_index])) % N;

                result += characters[c];

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }
            if (result == expected)
            {
                good = true;
            }
            Assert.AreEqual(good, true);
        }
    }
}
