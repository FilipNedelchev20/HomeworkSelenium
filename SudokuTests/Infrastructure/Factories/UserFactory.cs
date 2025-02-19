using Infrastructure.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Factories
{
    using Bogus;

    public class UserFactory
    {
        public static User CreateFakeUser()
        {
            var faker = new Faker<User>()
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.Password, f => f.Internet.Password());

            return faker.Generate();
        }
    }



}
