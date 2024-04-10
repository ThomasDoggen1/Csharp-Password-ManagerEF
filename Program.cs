using System;
using System.IO;

class PasswordManager
{
    private const string dataFilePath = @"E:\password.txt";

    public void AddPassword()
    {
        Console.Write("Enter site name: ");
        string? site = Console.ReadLine();

        Console.Write("Enter email: ");
        string? email = Console.ReadLine();

        Console.Write("Enter username: ");
        string? username = Console.ReadLine();

        Console.Write("Enter password: ");
        string? password = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(site))
        {
            Console.WriteLine("No site name given");
            return;
        }
        if (string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("No Email given");
            return;
        }
        if (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("No username given");
            return;
        }
        if (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("No password given");
            return;
        }

        StorePassword(site, email, username, password);
    }

    private void StorePassword(string site, string email, string username, string password)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(dataFilePath, true))
            {
                writer.WriteLine($"Site: {site}\nEmail: {email}\nUsername: {username}\nPassword: {password}\n\n\n\n");
            }

            Console.WriteLine("Password Successfully Saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while saving password: {ex.Message}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        PasswordManager passwordManager = new PasswordManager();
        passwordManager.AddPassword();
    }
}
