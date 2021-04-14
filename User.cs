using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// User class, interface for user types.
/// Author: Eric Dong
/// Date: April 13th 2021
/// Version: 1.0
/// </summary>
namespace BCITDesktop
{
    interface User
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string Gender { get; set; }
        string Phone { get; set; }
        DateTime DateOfBirth { get; set; }

        void ShowErrorMessage();

        Boolean areTheSameUsers(User user1, User user2);

        User getStudent(IFirebaseClient client, String userID);
    }
}
