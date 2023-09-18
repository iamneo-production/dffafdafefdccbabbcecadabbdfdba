using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using Week4_webapi.Models;
using Week4_webapi.Controllers;

namespace TestProject
{
    public class Tests
    {
        private AdminController _controller;
        private ApplicationDbContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Use a unique database name
                .Options;

            _context = new ApplicationDbContext(options);

            _controller = new AdminController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the database context to release resources
            _context.Dispose();
        }
        [Test]
        public void Week4_day1_Player_ClassExists()
        {
            string assemblyName = "Week4_webapi";
            string typeName = "Week4_webapi.Models.Player";
            Assembly assembly = Assembly.Load(assemblyName);
            Type playerType = assembly.GetType(typeName);
            Assert.IsNotNull(playerType);
        }

        [Test]
        public void Week4_day2_Team_ClassExists()
        {
            string assemblyName = "Week4_webapi";
            string typeName = "Week4_webapi.Models.Team";
            Assembly assembly = Assembly.Load(assemblyName);
            Type playerType = assembly.GetType(typeName);
            Assert.IsNotNull(playerType);
        }

        [Test]
        public void Week4_Day1_Test_Migrationfolder_Exists()
        {

            string folderPath = @"/home/coder/project/workspace/Week4_webapi/Migrations/"; // Replace with the folder path you want to check
            bool folderExists = Directory.Exists(folderPath);

            Assert.IsTrue(folderExists, "The folder does not exist.");
        }

        [Test]
        public void Week4_day3_User_ClassExists()
        {
            string assemblyName = "Week4_webapi";
            string typeName = "Week4_webapi.Models.User";
            Assembly assembly = Assembly.Load(assemblyName);
            Type playerType = assembly.GetType(typeName);
            Assert.IsNotNull(playerType);
        }

        [Test]
        public void Week4_Day3_RegisterMethod_PlayerController_Exists()
        {

            var controllerType = typeof(UserController);
            var controller = Activator.CreateInstance(controllerType, _context);

            MethodInfo method = controllerType.GetMethod("Register", new[] { typeof(User) });


            Assert.IsNotNull(method);
        }

        [Test]
        public void Week4_Day3_LoginMethod_PlayerController_Exists()
        {

            var controllerType = typeof(UserController);
            var controller = Activator.CreateInstance(controllerType, _context);

            MethodInfo method = controllerType.GetMethod("Login", new[] { typeof(User) });


            Assert.IsNotNull(method);
        }

        [Test]
        public void Week5_Day2_GetPlayersMethod_AdminController_Exists()
        {

            var controllerType = typeof(AdminController);
            var controller = Activator.CreateInstance(controllerType, _context);

            MethodInfo method = controllerType.GetMethod("GetPlayers");


            Assert.IsNotNull(method);
        }

        [Test]
        public void Week5_Day2_GetTeamsMethod_AdminController_Exists()
        {

            var controllerType = typeof(AdminController);
            var controller = Activator.CreateInstance(controllerType, _context);

            MethodInfo method = controllerType.GetMethod("GetTeams");


            Assert.IsNotNull(method);
        }
    }
}