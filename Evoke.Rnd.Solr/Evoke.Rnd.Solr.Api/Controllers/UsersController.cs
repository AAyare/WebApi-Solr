using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evoke.Rnd.Solr.Api.Models;
using Evoke.Rnd.Solr.Api;
using AutoMapper;

namespace Evoke.Rnd.Solr.Api.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/
        UsersDataContext _dataContext = new UsersDataContext();
        
        public ActionResult Index()
        {
            Mapper.CreateMap<User,Users>();
            var userDetails = from user in _dataContext.Users
                              select user;
            var users = new List<Users>();
            if (userDetails.Any())
            {
                foreach (var user in userDetails)
                {
                    Users userModel = Mapper.Map<User, Users>(user);
                    users.Add(userModel);
                }
            }

            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Users userDetails)
        {
            try
            {
                Mapper.CreateMap<Users, User>();
                var user = Mapper.Map<Users, User>(userDetails);
                _dataContext.Users.InsertOnSubmit(user);
                _dataContext.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
      
        public ActionResult Edit(int? userid)
        {
            Mapper.CreateMap<User, Users>();
            var userDetails = _dataContext.Users.FirstOrDefault(a => a.UserId == userid);
            var user = Mapper.Map<User, Users>(userDetails);
            _dataContext.SubmitChanges();
            return View(user);
        }

        public ActionResult Delete(int? userid)
        {
            Mapper.CreateMap<User, Users>();
            var userDetails = _dataContext.Users.FirstOrDefault(a => a.UserId == userid);
            var user = Mapper.Map<User, Users>(userDetails);
            return View(user);
        }

    }
}
