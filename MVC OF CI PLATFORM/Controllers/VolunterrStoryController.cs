﻿using CI_PLATFORM.Entities.DataModels;
using CI_PLATFORM.Entities.ViewModels;
using CI_PLATFORM_.repository.Interface;
using CI_PLATFORM_.repository.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MVC_OF_CI_PLATFORM.Controllers
{
    public class VolunterrStoryController : Controller
    {
        private readonly IVolunterstoryInterface _volunterstory;

        public VolunterrStoryController(IVolunterstoryInterface volunterstory)
        {
            _volunterstory = volunterstory;       
        }
        [HttpGet]
        public IActionResult volunteerstory(int pageIndex = 1)
        {    
            var stories = _volunterstory.Getstorylist(pageIndex);
            return View(stories);
        }
        [HttpGet]
        public IActionResult Shareyourstory()
        {
            long userid = long.Parse(HttpContext.Session.GetString("userid"));
            if(userid == null)
            {
                return RedirectToAction("LOGIN","Home");
            }
            var data = _volunterstory.getData(userid);
            return View(data);
        }
        [HttpPost]
        public IActionResult Shareyourstory(long missionId, string title, DateTime date, string videoURL, string description, string[] imagePaths)
        {
            var userid = HttpContext.Session.GetString("userid");
             _volunterstory.Shareyourstory(missionId,title,date,videoURL,description,imagePaths,long.Parse(userid));
            return View();
                
        }
        public IActionResult submit(long storyId)
        {
             _volunterstory.submit(storyId);
            return Json(new { redirectUrl = Url.Action("volunteerstory", "volunterrStory") });
           
        }


        public IActionResult storydetails(int id)
        {

            storydetailviewmodel Story =_volunterstory.GetStory(id);
            return View(Story);
        }
        public string recommend(List<long> userIds, long storyId)
        {
            var userId = HttpContext.Session.GetString("userid");
            var rec = _volunterstory.recommend(userIds, storyId, userId);
            return "successfully link sent";
        }

        public JsonResult User()
        {
            var rec = _volunterstory.GetUsers();
            return Json(rec);
        }
        public JsonResult missions()
        {
            long userid = long.Parse(HttpContext.Session.GetString("userid"));
            List<Mission> missions = _volunterstory.GetMissions(userid);
            return Json(missions);
        }
    }
}
