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
                    Evoke.Rnd.Solr.Api.Models.Users userModel =
                        Mapper.Map<Evoke.Rnd.Solr.Api.User, Evoke.Rnd.Solr.Api.Models.Users>(user);
                    users.Add(userModel);
                }
            }

            return View(users);
        }

    }
}
