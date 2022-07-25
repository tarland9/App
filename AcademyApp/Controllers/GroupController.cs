using Core.Entities;
using Core.Helpers;
using DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage1.Controller
{
    public class GroupController
    {

        private GroupRepository _groupRepositories;

        public GroupController()
        {
            _groupRepositories = new GroupRepository();
        }

        #region CreateGroup
        public void CreateGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Name:");
            string name = Console.ReadLine();
        MaxSize: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Max Size:");
            string size = Console.ReadLine();

            int maxSize;
            bool result = int.TryParse(size, out maxSize);
            if (result)
            {
                Group group = new Group
                {
                    Name = name,
                    MaxSize = maxSize
                };
                var createdGroup = _groupRepositories.Create(group);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{createdGroup.Name} is successfully created with max size - {createdGroup.MaxSize} ");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, Enter Correct Group Max Size...");
                goto MaxSize;
            }

        }
        #endregion

        #region UpdateGroup

        public void UpdateGroup()
        {

        name: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Name");
            string name = Console.ReadLine();
            var group = _groupRepositories.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                int oldSize = group.MaxSize;
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter new group name");
                string newName = Console.ReadLine();

            size: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter new group size");
                string size = Console.ReadLine();


                int maxSize;
                bool result = int.TryParse(size, out maxSize);
                if (result)
                {
                    var newGroup = new Group
                    {
                        Id = group.Id,
                        Name = newName,
                        MaxSize = maxSize
                    };
                    _groupRepositories.Update(newGroup);
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"name:{name}, Max Size:{oldSize} is updated to Name:{newGroup.Name}, Max Size:{newGroup.MaxSize} ");

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, Enter correct Group max size");
                    goto size;
                }


            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, Enter correct Group name");
                goto name;
            }
        }
        #endregion

        #region DeleteGroup
        public void DeleteGroup()
        {
        name: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Name");
            string name = Console.ReadLine();
            var group = _groupRepositories.Get(g => g.Name.ToLower() == name.ToLower());

            if (group != null)
            {
                _groupRepositories.Delete(group);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} group is successfully deleted");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
                goto name;
            }
        }
        #endregion

        #region AllGroup

        public void AllGroup()
        {

            var groups = _groupRepositories.GetAll();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Groups:");
            foreach (var group in groups)
            {
                Console.WriteLine($"Group Name:{group.Name} , Max Size:{group.MaxSize}");
            }
        }
        #endregion

        #region GetGroupByName
        public void GetGroupByName()
        {
        name: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter group name");
            string name = Console.ReadLine();

            var group = _groupRepositories.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Name:{group.Name}, Max Size:{group.MaxSize}");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
                goto name;
            }
        }
        #endregion

        #region Exit
        public void Exit()
        {

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Thanks for using My App ");
        }
        #endregion




    }
}

