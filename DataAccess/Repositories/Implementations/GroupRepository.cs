﻿using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositeries.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class GroupRepository : IRepositories<Group>
    {
        private static int id;
        public Group Create(Group entity)
        {
            id++;
            entity.Id = id;
            DbContext.Groups.Add(entity);
            return entity;
        }

        public void Delete(Group entity)
        {
            DbContext.Groups.Remove(entity);
        }

        public Group Get(Predicate<Group> filter = null)
        {
            if (filter == null)
            {
                return DbContext.Groups[0];
            }
            else
            {
                return DbContext.Groups.Find(filter);
            }

        }

        public List<Group> GetAll(Predicate<Group> filter = null)
        {
            if (filter == null)
            {
                return DbContext.Groups;
            }
            else
            {
                return DbContext.Groups.FindAll(filter);
            }
        }

        public void Update(Group entity)
        {
            var group = DbContext.Groups.Find(g => g.Id == entity.Id);
            if (group != null)
            {
                group.Name = entity.Name;
                group.MaxSize = entity.MaxSize;
            }
        }
    }
}