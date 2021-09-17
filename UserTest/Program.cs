using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class UserRepository
    {
        
        private Dictionary<int, string> users = new Dictionary<int, string> { };

        private void AddUserNoAsync(int userId, string userName)
        {
            users.Add(userId, userName);
        }

        private string GetUserNoAsync(int userId)
        {
            return users[userId];
        }

        private SortedDictionary<int, string> GetOrderedUsersNoAsync()
        {
            var sortedUsers = new SortedDictionary<int, string>(users);

            foreach (var a in sortedUsers)
            {
                Console.WriteLine(a.Key + " - " + a.Value);
            }

            return sortedUsers;
        }

        public async void AddUser(int userId, string userName)
        {
            await Task.Run(() => AddUserNoAsync(userId, userName));
        }

        public async Task<string> GetUser(int userId)
        {
            return await Task.Run(() => GetUserNoAsync(userId));
        }

        public async Task<SortedDictionary<int, string>> GetOrderedUsers()
        {
            return await Task.Run(() => GetOrderedUsersNoAsync());
        }
    }
}
