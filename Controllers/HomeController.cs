using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Twilio;
using Twilio.TwiML;
using PhonePA.Models;

namespace PhonePA.Controllers
{
    public class HomeController : Controller
    {
        private ContactsContext _db;

        public HomeController()
        {
            _db = new ContactsContext();
        }

        public IActionResult Index()
        {
            return View(_db.Contacts);
        }

        // GET: /Home/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST: /Home/Create/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact contact)
        {
            ModelState.Clear();
            TryValidateModel(contact);
            if (ModelState.IsValid)
            {
                using (var db = new ContactsContext())
                {
                    db.Contacts.Add(contact);
                    var count = db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(contact);
        }

        // GET: Home/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = _db.Contacts.FirstOrDefault(s => s.ContactId == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //POST: /Home/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contact contact)
        {
            ModelState.Clear();
            TryValidateModel(contact);
            if (ModelState.IsValid)
            {
                using (var db = new ContactsContext())
                {
                    db.Contacts.Update(contact);
                    var count = db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            var contact = _db.Contacts.FirstOrDefault(s => s.ContactId == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            else
            {
                _db.Contacts.Remove(contact);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        
        [HttpPost]
        public IActionResult HandleCall(string From)
        {
            var contact = _db.Contacts.FirstOrDefault(s => s.Number == From);
            var twiml = new TwilioResponse();
            if (contact != null)
            {
                // It is a contact.
                // check whether they're allowed through
                if(!contact.Blocked){
                    return Content(twiml.Dial(Environment.GetEnvironmentVariable("MY_NUMBER")).ToString(), "text/xml");
                }
                else{
                    return Content(twiml.Say(contact.Message).ToString(), "text/xml");
                }
            }
            else{
                return Content(twiml.Say("This number is only for contacts.").ToString(), "text/xml");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
